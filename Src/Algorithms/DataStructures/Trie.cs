using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class Trie
    {
        internal class Node
        {
            internal char _ch;
            internal int count = 0;
            internal bool isWordEnding = false;
            internal Dictionary<char, Node> children = new Dictionary<char, Node>();

            public Node(char ch)
            {
                _ch = ch;
            }

            public void AddChild(Node node, char c)
            {
                children.Add(c, node);
            }
        }



        // The root character is an arbitrarily picked
        // character chosen for the root node.
        private readonly char rootCharacter;
        private Node root;


        public Trie()
        {
            rootCharacter = '\0';
            root = new Node(rootCharacter);
        }



        // Returns true if the string being inserted
        // contains a prefix already in the trie
        public bool Insert(string key, int numInserts)
        {

            if (key == null)
            {
                throw new Exception("Null not permitted in trie");
            }

            if (numInserts <= 0)
            {
                throw new Exception("numInserts has to be greater than zero");
            }

            Node node = root;
            bool created_new_node = false;
            bool is_prefix = false;

            // Process each character one at a time
            for (int i = 0; i < key.Length; ++i)
            {

                char ch = key[i];
                node.children.TryGetValue(ch, out Node nextNode);

                // The next character in this string does not yet exist in trie
                if (nextNode == null)
                {

                    nextNode = new Node(ch);
                    node.AddChild(nextNode, ch);
                    created_new_node = true;

                    // Next character exists in trie.
                }
                else
                {
                    if (nextNode.isWordEnding)
                    {
                        is_prefix = true;
                    }
                }

                node = nextNode;
                node.count += numInserts;
            }

            // The root itself is not a word ending. It is simply a placeholder.
            if (node != root)
            {
                node.isWordEnding = true;
            }

            return is_prefix || !created_new_node;
        }



        // Returns true if the string being inserted
        // contains a prefix already in the trie
        public bool Insert(string key)
        {
            return Insert(key, 1);
        }



        // This delete function allows you to delete keys from the trie
        // (even those which were not previously inserted into the trie).
        // This means that it may be the case that you delete a prefix which
        // cuts off the access to numerous other strings starting with
        // that prefix.
        public bool Delete(string key, int numDeletions)
        {

            // We cannot delete something that doesn't exist
            if (!Contains(key))
            {
                return false;
            }

            if (numDeletions <= 0)
            {
                throw new Exception("numDeletions has to be positive");
            }

            Node node = root;
            for (int i = 0; i < key.Length; i++)
            {

                char ch = key[i];
                node.children.TryGetValue(ch, out Node curNode);
                curNode.count -= numDeletions;

                // Cut this edge if the current node has a count <= 0
                // This means that all the prefixes below this point are inaccessible
                if (curNode.count <= 0)
                {
                    node.children.Remove(ch);
                    curNode.children = null;
                    curNode = null;
                    return true;
                }

                node = curNode;
            }
            return true;
        }

        public bool Delete(string key)
        {
            return Delete(key, 1);
        }

        // Returns true if this string is contained inside the trie
        public bool Contains(string key)
        {
            return Count(key) != 0;
        }

        // Returns the count of a particular prefix
        public int Count(string key)
        {

            if (key == null)
            {
                throw new Exception("Null not permitted");
            }

            Node node = root;

            // Dig down into trie until we reach the bottom or stop
            // early because the string we're looking for doesn't exist
            for (int i = 0; i < key.Length; i++)
            {
                char ch = key[i];
                if (node == null)
                {
                    return 0;
                }

                node.children.TryGetValue(ch, out node);
            }

            if (node != null)
            {
                return node.count;
            }

            return 0;
        }

        // Recursively clear the trie freeing memory to help GC
        private void Clear(Node node)
        {

            if (node == null)
            {
                return;
            }

            foreach (KeyValuePair<char, Node> ch in node.children)
            {
                node.children.TryGetValue(ch.Key, out Node nextNode);
                Clear(nextNode);
                nextNode = null;
            }

            node.children.Clear();
            node.children = null;
        }

        // Clear the trie
        public void Clear()
        {
            root.children = null;
            root = new Node(rootCharacter);
        }
    }
}

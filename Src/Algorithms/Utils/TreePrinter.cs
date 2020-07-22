using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Utils
{

    /** Node that can be printed */
    public interface IPrintableNode
    {

        // Get left child
        public IPrintableNode GetLeft();


        // Get right child
        public IPrintableNode GetRight();


        // Get text to be printed
        public string GetText();
    }


    public static class TreePrinter
    {

        // Print a binary tree.
        public static string GetTreeDisplay(IPrintableNode root)
        {

            StringBuilder sb = new StringBuilder();
            List<List<string>> lines = new List<List<string>>();
            List<IPrintableNode> level = new List<IPrintableNode>();
            List<IPrintableNode> next = new List<IPrintableNode>();

            level.Add(root);
            int nn = 1;
            int widest = 0;

            while (nn != 0)
            {
                nn = 0;
                List<string> line = new List<string>();
                foreach (IPrintableNode n in level)
                {
                    if (n is null)
                    {
                        line.Add(null);
                        next.Add(null);
                        next.Add(null);
                    }
                    else
                    {
                        string aa = n.GetText();
                        line.Add(aa);
                        if (aa.Length > widest)
                        {
                            widest = aa.Length;
                        }

                        next.Add(n.GetLeft());
                        next.Add(n.GetRight());

                        if (n.GetLeft() != null)
                        {
                            nn++;
                        }

                        if (n.GetRight() != null)
                        {
                            nn++;
                        }
                    }
                }


                if (widest % 2 == 1)
                {
                    widest++;
                }

                lines.Add(line);

                List<IPrintableNode> tmp = level;
                level = next;
                next = tmp;
                next.Clear();
            }

            int perpiece = lines[lines.Count - 1].Count * (widest + 4);
            for (int i = 0; i < lines.Count; i++)
            {
                List<string> line = lines[i];
                int hpw = (int)Math.Floor(perpiece / 2f) - 1;
                if (i > 0)
                {
                    for (int j = 0; j < line.Count; j++)
                    {

                        // split node
                        char c = ' ';
                        if (j % 2 == 1)
                        {
                            if (line[j - 1] != null)
                            {
                                c = (line[j] != null) ? '#' : '#';
                            }
                            else
                            {
                                if (j < line.Count && line[j] != null)
                                {
                                    c = '#';
                                }
                            }
                        }
                        sb.Append(c);

                        // lines and spaces
                        if (line[j] is null)
                        {
                            for (int k = 0; k < perpiece - 1; k++)
                            {
                                sb.Append(' ');
                            }
                        }
                        else
                        {
                            for (int k = 0; k < hpw; k++)
                            {
                                sb.Append(j % 2 == 0 ? " " : "#");
                            }
                            sb.Append(j % 2 == 0 ? "#" : "#");
                            for (int k = 0; k < hpw; k++)
                            {
                                sb.Append(j % 2 == 0 ? "#" : " ");
                            }
                        }
                    }
                    sb.Append('\n');
                }
                for (int j = 0; j < line.Count; j++)
                {
                    string f = line[j];
                    if (f is null)
                    {
                        f = "";
                    }

                    int gap1 = (int)Math.Ceiling(perpiece / 2f - f.Length / 2f);
                    int gap2 = (int)Math.Floor(perpiece / 2f - f.Length / 2f);

                    for (int k = 0; k < gap1; k++)
                    {
                        sb.Append(' ');
                    }
                    sb.Append(f);
                    for (int k = 0; k < gap2; k++)
                    {
                        sb.Append(' ');
                    }
                }
                sb.Append('\n');

                perpiece /= 2;
            }
            return sb.ToString();
        }
    }
}

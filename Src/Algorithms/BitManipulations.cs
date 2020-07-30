namespace Algorithms
{
    public static class BitManipulations
    {
        // Sets the i'th bit to 1
        public static int SetBit(int set, int i) => set | (1 << i);
        

        // Checks if the i'th is set
        public static bool IsSet(int set, int i) => (set & (1 << i)) != 0;
        

        // Sets the i'th bit to zero
        public static int ClearBit(int set, int i) => set & ~(1 << i);
        

        // Toggles the i'th bit from 0 -> 1 or 1 -> 0
        public static int ToggleBit(int set, int i) => set ^ (1 << i);
        

        // Returns a number with the first n bits set to 1
        public static int SetAll(int n) => (1 << n) - 1;
        

        // Verifies if a number n is a power of two
        public static bool IsPowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;
        
    }
}

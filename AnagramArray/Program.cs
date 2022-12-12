using System;

namespace anagram
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] words = new string[] { "cook", "save", "taste", "aves", "vase", "state", "map" };

            Console.Write("[");
            foreach (string word in words) Console.Write("'" + word + "',");
            Console.Write("]\n");

            process(words);
        }

        static void process(string[] param)
        {
            //init flags, represent a word that already have a group
            bool[] flags = new bool[param.Length];

            Console.Write("[\n");
            //Compare each word
            for (int i = 0; i < param.Length; i++)
            {
                if (!flags[i])
                {
                    Console.Write(" ['" + param[i] + "' ");
                }
                for (int j = i + 1; j < param.Length; j++)
                {
                    if (!flags[j])
                    {
                        if (compare(param[i], param[j]))
                        {
                            flags[j] = true;
                            Console.Write("'" + param[i] + "' ");
                        }
                    }
                }
                if (!flags[i])
                {
                    Console.Write("],\n");
                    flags[i] = true;
                }
            }
            Console.Write("]\n");
        }

        static bool compare(string a, string b)
        {
            //check if the word is the same length
            if (a.Length != b.Length) return false;

            //init flags, represent a char in string b that already have couple in string a
            bool[] flags = new bool[b.Length];

            //find couple char within string a and string b
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (!flags[j])
                    {
                        if (a[i] == b[j])
                        {
                            flags[j] = true;
                        }
                    }
                }
            }

            //check if all of the chars b have couple
            foreach (bool f in flags)
            {
                if (f == false) return false;
            }
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfStudyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello Strings!");

            Console.WriteLine("\nGet the index of the last solo character in a string:");
            Console.WriteLine($"The last solo character index of abcc is {GetLastSoloCharIndex("abcc")}");
            Console.WriteLine($"The last solo character index of abc is {GetLastSoloCharIndex("abc")}");
            Console.WriteLine($"The last solo character index of aaa is {GetLastSoloCharIndex("aaa")}");
            Console.WriteLine($"The last solo character index of abb is {GetLastSoloCharIndex("abb")}");

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static object GetLastSoloCharIndex(string str)
        {
            // Check for null or empty
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String cannot be null or empty");
            }

            // Create and populate dictionary with str chars
            var dictionary = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (dictionary.ContainsKey(c)) // ContainsKey() is O(1)
                {
                    ++dictionary[c];
                }
                else
                {
                    dictionary.Add(c, 1); // Add() is O(N) if capacity must be increased. Otherwise, O(1)
                }
            }

            // Traverse str backward, looking for 1st solo char
            for (int index = str.Length - 1; index >= 0; --index)
            {
                if (dictionary[str[index]] == 1)
                {
                    return index;
                }
            }

            // If this point reached, there are no solo chars
            return -1;
        }
    }
}

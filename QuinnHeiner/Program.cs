using System;
using System.Collections.Generic;

/*
Week 1:

We are going to kick this off with an easy one.  The challenge for the first week will be the following:
 
You are given a list of strings that are made up of letters and numbers.  Sort them first according to the letters and then according to the numbers.
 
If you have an array of the following values
a1, b1, a20, a2, a12, c5
 
Sort them so they are sorted first by letter and then by number like:
a1, a2, a12, a20, b1, c5
 */

// Author: Quinn Heiner
namespace CodeChallenge01_AlphanumericSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("\n\n\nEnter the alphanumeric strings you want to sort, separated by spaces or commas (q to quit)");
                userInput = Console.ReadLine();
                Console.WriteLine("\nResults Sorted (using built-in list.Sort() implementation): " + PrintStringsSorted1(userInput));
                Console.WriteLine("\nResults Sorted (manual sort implementation): " + PrintStringsSorted1(userInput));
            } while (userInput != "q");
        }

        // Implementation #1: utilizes the List.Sort() method with a custom IComparer<string> object for integer comparisons within the string
        public static string PrintStringsSorted1(string userInput)
        {
            var unsortedStrings = userInput.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stringList = new List<string>(unsortedStrings);
            var stringCompareObj = new CompareAlphanumericString();
            stringList.Sort(stringCompareObj);
            var sortedStringsJoined = String.Join(", ", stringList);
            return sortedStringsJoined;
        }

        // Implementation #2: same as implementation #1 above, but instead of List.Sort(), I manually sort the list via the SortStringsByLetterThenNumber() method
        public static string PrintStringsSorted2(string userInput)
        {
            var unsortedStrings = userInput.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sortedStrings = SortStringsByLetterThenNumber(unsortedStrings);
            var sortedStringsJoined = String.Join(", ", sortedStrings);
            return sortedStringsJoined;
        }

        // NOTE: This method is only needed for implementation #2 above
        /// <summary>
        /// Orders alphanumeric string array first by letter, then by number, e.g. a2 would come before a12
        /// </summary>
        /// <param name="strings">array of unordered alphanumeric strings</param>
        /// <returns>array of alphanumeric strings, ordered first by letter, then by number</returns>
        public static string[] SortStringsByLetterThenNumber(string[] strings)
        {
            var stringCompareObj = new CompareAlphanumericString();
            for (int i = 0; i < strings.Length - 1; i++)
            {
                for (int j = 0; j < strings.Length - 1; j++)
                {
                    var firstString = strings[j];
                    var secondString = strings[j + 1];

                    if (stringCompareObj.Compare(firstString, secondString) > 0)
                    {
                        // swap order of the two strings in array if first > second
                        strings[j] = secondString;
                        strings[j + 1] = firstString;
                    }
                }
            }
            return strings;
        }
    }
    
    /// <summary>
    /// Compares an alphanumeric string by letter then number, e.g. a2 would come before a12
    /// </summary>
    public class CompareAlphanumericString : IComparer<string>
    {
        /// <summary>
        /// Compares an alphanumeric string by letter then number, e.g. a2 would come before a12
        /// </summary>
        /// <param name="x">The first string to compare (x)</param>
        /// <param name="y">The second string to compare (y)</param>
        /// <returns> -1 if x &lt; y, 0 if equal, and 1 if x &gt; y</returns>
        public int Compare(string firstString, string secondString)
        {
            var string1 = firstString.Trim();
            var string2 = secondString.Trim();
            var xyLargestLength = Math.Max(string1.Length, string2.Length);

            for (int i = 0; i < xyLargestLength; i++)
            {
                char? c1 = null;
                char? c2 = null;
                c1 = string1.Length > i ? string1[i] : c1;
                c2 = string2.Length > i ? string2[i] : c2;
 
                // COMPARISON CASE 1: both chars are letters and equal, so let's move on to the next char
                if (!CharIsNumber(c1) && !CharIsNumber(c2) && c1 == c2)
                {
                    continue;
                }
                // COMPARISON CASE 2: at least one of the chars is a letter, and they're not equal, so we can go ahead and do a standard comparison
                else if ( (!CharIsNumber(c1) || !CharIsNumber(c2)) && c1 != c2)
                {
                    return string1.CompareTo(string2);
                }
                // COMPARISON CASE 3: both chars are numbers, so let's do an integer comparison of the numbers
                else if (CharIsNumber(c1) && CharIsNumber(c2))
                {
                    Int64 c1Nums = ExtractNums(string1, i);
                    Int64 c2Nums = ExtractNums(string2, i);
                    if (c1Nums != c2Nums)
                    {
                        return c1Nums.CompareTo(c2Nums);
                    }
                }
            }
            // COMPARISON CASE 4 (of 4): if none of the above cases ever returns a comparison result, let's default to the standard string comparison
            return string1.CompareTo(string2);
        }
        
        /// <summary>
        /// Unlike Char.IsDigit() and Char.IsNumber() functions, this method only returns true for chars that are in the ASCII range of 0x30 to 0x39
        /// </summary>
        /// <param name="c">the character to test</param>
        /// <returns>true if in ASCII range of 0x30 to 0x39</returns>
        public bool CharIsNumber(char? c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// Extracts digits from string at the specified index and exits when a non-digit is reached, e.g. abc456abc789 at index 0 would return 456
        /// </summary>
        /// <param name="s">the alphanumeric string from which to extract the numbers</param>
        /// <param name="index">the specified index from which to start extraction, 0 is default</param>
        /// <returns>single integer (Int64) representing the extracted numbers</returns>
        public Int64 ExtractNums(string s, int index = 0)
        {
            string num = "0";
            for (int i = index; i < s.Length; i++)
            {
                if (!CharIsNumber(s[i]))
                    break;
                else
                    num += s[i];
            }
            return Convert.ToInt64(num);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace TroyFillerupChallenge01
{
    public class Sorter
    {
        public List<string> Sort(string elementString)
        {
            //Requires a comma separated string of letters and numbers
            var elements = elementString.Split(',').ToList();
            return Sort(elements);
        }

        public List<string> Sort(List<string> elements)
        {
            //Send in a generic list of letter/number combinations
            var comparer = new ChallengeComparer();
            elements.Sort(comparer);

            return elements;
        }
    }

    public class ChallengeComparer : System.Collections.Generic.IComparer<string>
    {
        public int Compare(string x, string y)
        {
            //Get the letters out of the string
            var letter1 = Regex.Match(x.ToString(), "[A-Za-z]*");
            var letter2 = Regex.Match(y.ToString(), "[A-Za-z]*");

            //Get the number portion out of the string
            int int1 = 0;
            int.TryParse(Regex.Match(x.ToString(), "[0-9]+").Value, out int1);
            int int2 = 0;
            int.TryParse(Regex.Match(y.ToString(), "[0-9]+").Value, out int2);

            //Compare the letters.  If the letter is different then we don't need to even compare the numbers.
            var letterCompare = string.Compare(letter1.Value, letter2.Value);

            return letterCompare != 0 ? letterCompare : int1.CompareTo(int2);
        }

    }
}

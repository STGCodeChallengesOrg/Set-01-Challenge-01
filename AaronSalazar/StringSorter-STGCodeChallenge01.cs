/*
 * STG Code Challenge #1
 * Aaron Salazar
 * 11/18/14
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		var strToSort = new List<string>(){ "a1", "b1", "a20", "a2", "a12", "c5" };
			
		var sorter = new StringSorter();
		strToSort.Sort(sorter);
		
		strToSort.Dump();
	}
}

/************************************************************
 * Here is the sorter.  It implements IComparer which helps *
 * with the sorting by comparing its two parameters.        *
 ************************************************************/
public class StringSorter : IComparer<string>
{
	public int Compare(string a, string b)
	{
		// Parsing the strings for numbers and letters
		string aLetters = Regex.Replace(a, @"[^a-zA-Z]+", String.Empty);
		string bLetters = Regex.Replace(b, @"[^a-zA-Z]+", String.Empty);
		int aNumbers = Int32.Parse(Regex.Replace(a, @"[^0-9]+", String.Empty));
		int bNumbers = Int32.Parse(Regex.Replace(b, @"[^0-9]+", String.Empty));
		
		// The comparison
		var letterSort = string.Compare(aLetters, bLetters);
		if(letterSort == 0)
		{
			if(aNumbers > bNumbers)
				return 1;
			if(aNumbers < bNumbers)
				return -1;
			else
				return 0;
		}
		return letterSort;
	}
}
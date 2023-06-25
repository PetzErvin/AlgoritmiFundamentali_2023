using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string romanianText = "șățâ";
        string latinText = "sat";

        string transformedToLatin = RomanianToLatin(romanianText);
        string transformedToRomanian = LatinToRomanian(latinText);

        Console.WriteLine("Romanian to Latin:");
        Console.WriteLine(transformedToLatin);

        Console.WriteLine("Latin to Romanian:");
        Console.WriteLine(transformedToRomanian);
    }

    static string RomanianToLatin(string romanianText)
    {
        Dictionary<char, char> romanianToLatinMap = new Dictionary<char, char>()
        {
            { 'ș', 's' },
            { 'ă', 'a' },
            { 'ț', 't' },
            { 'â', 'a' }
        };

        string latinText = "";

        foreach (char c in romanianText)
        {
            if (romanianToLatinMap.ContainsKey(c))
            {
                latinText += romanianToLatinMap[c];
            }
            else
            {
                latinText += c;
            }
        }

        return latinText;
    }

    static string LatinToRomanian(string latinText)
    {
        Dictionary<char, char> latinToRomanianMap = new Dictionary<char, char>()
        {
            { 's', 'ș' },
            { 'a', 'ă' },
            { 't', 'ț' },
            { 'â', 'â' }
        };

        string romanianText = "";

        foreach (char c in latinText)
        {
            if (latinToRomanianMap.ContainsKey(c))
            {
                romanianText += latinToRomanianMap[c];
            }
            else
            {
                romanianText += c;
            }
        }

        return romanianText;
    }
}
using System;
using System.Collections.Generic;

public class Combinations
{
    private static List<List<int>> combinations;

    public static List<List<int>> FindCombinations(List<int> numbers, int k)
    {
        combinations = new List<List<int>>();
        List<int> currentCombination = new List<int>();
        GenerateCombinations(numbers, k, 0, currentCombination);
        return combinations;
    }

    private static void GenerateCombinations(List<int> numbers, int k, int startIndex, List<int> currentCombination)
    {
        if (currentCombination.Count == k)
        {
            if (IsPrimeSum(currentCombination))
            {
                combinations.Add(new List<int>(currentCombination));
            }
            return;
        }

        for (int i = startIndex; i < numbers.Count; i++)
        {
            currentCombination.Add(numbers[i]);
            GenerateCombinations(numbers, k, i + 1, currentCombination);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }

    private static bool IsPrimeSum(List<int> combination)
    {
        int sum = 0;
        foreach (int num in combination)
        {
            sum += num;
        }
        return IsPrime(sum);
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 17, 18, 19, 20, 21, 22, 23 };
        int k = 5;

        List<List<int>> combinations = Combinations.FindCombinations(numbers, k);

        Console.WriteLine($"Combinations of {k} numbers with prime sum:");
        foreach (List<int> combination in combinations)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
    }
}

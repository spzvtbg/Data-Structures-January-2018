using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var inputWords = Console.ReadLine().Split().ToList();
        inputWords.Sort();
        Console.WriteLine(string.Join(" ", inputWords));
    }
}

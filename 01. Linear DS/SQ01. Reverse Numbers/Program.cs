using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var stack = new Stack<int>();
        Console.ReadLine()
            .Split().Select(x => Convert.ToInt32(x))
            .ToList()
            .ForEach(e => stack.Push(e));

        stack.ToList().ForEach(e => Console.Write($"{e} "));
        Console.WriteLine();
    }
}

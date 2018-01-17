namespace _01.Sum_and_Average
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine().Split().Select(x => Convert.ToDouble(x)).ToList();
            Console.WriteLine($"Sum={inputNumbers.Sum()}; Average={inputNumbers.Average():F2}");
        }
    }
}

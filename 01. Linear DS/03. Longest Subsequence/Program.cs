using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var inputNumbers = Console.ReadLine().Split().Select(x => Convert.ToDouble(x)).ToList();
        
        double occuredNumber = inputNumbers[0]; 
        double occurance = 1;
        double temporaryOccuredNumber = inputNumbers[0];
        double temporaryOccurance = 1;

        for (int i = 1; i < inputNumbers.Count; i++)
        {
            var nextNumber = inputNumbers[i];

            if (temporaryOccuredNumber != nextNumber)
            {
                SetOccurance(ref occuredNumber, ref occurance, temporaryOccuredNumber, temporaryOccurance);

                temporaryOccurance = 1;
                temporaryOccuredNumber = nextNumber;

                continue;
            }

            temporaryOccurance++;
        }

        SetOccurance(ref occuredNumber, ref occurance, temporaryOccuredNumber, temporaryOccurance);

        for (int i = 0; i < occurance; i++)
        {
            Console.Write(occuredNumber + " ");
        }
    }

    public static void SetOccurance(
        ref double occuredNumber, 
        ref double occurance, 
        double temporaryOccuredNumber, 
        double temporaryOccurance)
    {
        if (temporaryOccurance > occurance)
        {
            occurance = temporaryOccurance;
            occuredNumber = temporaryOccuredNumber;
        }
    }
}

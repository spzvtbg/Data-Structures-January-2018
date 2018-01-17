using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var collection = Console.ReadLine().Split().Select(x => Convert.ToDouble(x)).ToArray();
        var kvps = new List<KVP>();
        foreach (var number in collection)
        {
            KVP @new;
            if (!kvps.Any(x => x.K == number))
            {
                @new = new KVP(number, 1);
                kvps.Add(@new);
                continue;
            }

            @new = kvps.FirstOrDefault(x => x.K == number);
            if (@new != null)
            {
                @new.V++;
            }
        }

        kvps.ForEach(x => Console.WriteLine($"{x.K} -> {x.V} times"));
    }
}

public class KVP
{
    public KVP(double k, int v)
    {
        this.K = k;
        this.V = v;
    }

    public double K { get; set; }

    public int V { get; set; }
}

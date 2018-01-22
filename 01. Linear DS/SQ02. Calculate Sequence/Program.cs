using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int firstElement = Convert.ToInt32(Console.ReadLine());

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(firstElement);
        Console.Write($"{firstElement}, ");

        int count = 0;

        while (queue.Count > 0)
        { 
            int n = queue.Dequeue();

            count++;
            int expresion1 = n + 1;
            queue.Enqueue(expresion1);
            Console.Write(expresion1);
            Console.Write(count == 49? "": ", ");

            if (count == 49)
            {
                return;
            }

            count++;
            int expresion2 = n * 2 + 1;
            queue.Enqueue(expresion2);
            Console.Write(expresion2);
            Console.Write(count == 49 ? "" : ", ");

            if (count == 49)
            {
                return;
            }

            count++;
            int expresion3 = n + 2;
            queue.Enqueue(expresion3);
            Console.Write(expresion3);
            Console.Write(count == 49 ? "" : ", ");

            if (count == 49)
            {
                return;
            }
        }
    }
}

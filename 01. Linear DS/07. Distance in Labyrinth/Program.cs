using System;
using System.Linq;

public class Program
{
    public static int row = -1;

    public static int tempRow;

    public static int col = -1;

    public static int tempCol;

    public static int count = 0;

    public static string[][] LabirintMatrix;

    public static void Main()
    {
        InitializeQuadraticMatrixField(Convert.ToInt32(Console.ReadLine()));
        GetNextCell(row, col, count);

        for (int row = 0; row < LabirintMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < LabirintMatrix.GetLength(1); col++)
            {
                if (LabirintMatrix[row][col] == "0")
                {
                    LabirintMatrix[row][col] = "u";
                }
                Console.Write(LabirintMatrix[row][col]);
            }
        }
    }

    public static void GetNextCell(int row, int col, int count)
    {
        count++;
        GetNextCell(row++, col, count);
        GetNextCell(row, col++, count);
        GetNextCell(row--, col, count);
        GetNextCell(row, col--, count);
    }

    public static void InitializeQuadraticMatrixField(int size)
    {
        LabirintMatrix = new string[size][];

        for (int index = 0; index < size; index++)
        {
            var currentSymbols = Console.ReadLine();
            var temporaryIndex = currentSymbols.IndexOf('*');

            if (temporaryIndex > col)
            {
                row = index;
                col = temporaryIndex;
            }

            LabirintMatrix[index] = currentSymbols
                .ToCharArray()
                .Select(x => x.ToString())
                .ToArray();
        }
    }

    public static bool IsValidIndex(int index) => index >= 0 && index < LabirintMatrix.Length;

    public static bool IsValidRoute(string symbol) => symbol != "x"; 
}

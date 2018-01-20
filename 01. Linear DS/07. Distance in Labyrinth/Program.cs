using System;
using System.Collections.Generic;

public class Program
{ 
    public const int forbidenCell = -2;
    public const int reachableCell = -1;
    public const int startPosition = 0;
    
    public static int labirintLength;
    public static int[,] labirintMatrix;

    public static Queue<Position> backPoints = new Queue<Position>();

    public static void Main()
    {
        InitializeQuadraticMatrixField(Convert.ToInt32(Console.ReadLine()));
        FindPathsFromStartPosition();
        PrintFoundetPaths();
    }

    public static void InitializeQuadraticMatrixField(int size)
    {
        labirintLength = size;
        labirintMatrix = new int[size, size];

        for (int row = 0; row < size; row++)
        {
            string currentRowValue = Console.ReadLine();

            for (int col = 0; col < size; col++)
            {
                if (currentRowValue[col] == '0')
                {
                    labirintMatrix[row, col] = reachableCell;
                }
                else if (currentRowValue[col] == 'x')
                {
                    labirintMatrix[row, col] = forbidenCell;
                }
                else if (currentRowValue[col] == '*')
                {
                    labirintMatrix[row, col] = startPosition;
                    backPoints.Enqueue(new Position(row, col, startPosition));
                }
            }
        }
    }

    public static void FindPathsFromStartPosition()
    {
        while (backPoints.Count > 0)
        {
            Position currentPosition = backPoints.Dequeue();

            int currentRow = currentPosition.Row;
            int currentCol = currentPosition.Col;

            int left = currentCol - 1;
            int up = currentRow - 1;
            int right = currentCol + 1;
            int down = currentRow + 1;

            int value = currentPosition.Value + 1;

            if (left >= 0 && labirintMatrix[currentRow, left] == reachableCell)
            {
                labirintMatrix[currentRow,left] = value;
                backPoints.Enqueue(new Position(currentRow, left, value));
            }
            if (up >= 0 && labirintMatrix[up, currentCol] == reachableCell)
            {
                labirintMatrix[up, currentCol] = value;
                backPoints.Enqueue(new Position(up, currentCol, value));
            }
            if (right < labirintLength && labirintMatrix[currentRow, right] == reachableCell)
            {
                labirintMatrix[currentRow, right] = value;
                backPoints.Enqueue(new Position(currentRow, right, value));
            }
            if (down < labirintLength && labirintMatrix[down, currentCol] == reachableCell)
            {
                labirintMatrix[down, currentCol] = value;
                backPoints.Enqueue(new Position(down, currentCol, value));
            }
        }
    }

    public static void PrintFoundetPaths()
    {
        for (int row = 0; row < labirintLength; row++)
        {
            for (int col = 0; col < labirintLength; col++)
            {
                int currentValue = labirintMatrix[row, col];

                if (currentValue > startPosition)
                {
                    Console.Write(currentValue);
                }
                else if (currentValue == reachableCell)
                {
                    Console.Write('u');
                }
                else if (currentValue == forbidenCell)
                {
                    Console.Write('x');
                }
                else if (currentValue == startPosition)
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();
        }
    }
}

public class Position
{
    public Position(int row, int col, int value)
    {
        this.Row = row;
        this.Col = col;
        this.Value = value;
    }

    public int Row { get; set; }

    public int Col { get; set; }

    public int Value { get; set; }
}

using System;

public class CircularQueue<T>
{
    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.capacity = capacity;
        this.workArray = new T[capacity];
        this.Count = this.headIndex = this.teilIndex = 0;
    }

    private const int DefaultCapacity = 4;

    private T[] workArray;

    private int headIndex;

    private int teilIndex;

    private int capacity;

    private void Resize()
    {
        T[] temporary = new T[this.capacity * 2];
        this.workArray = this.CopyAllElements(temporary);
        this.capacity *= 2;
    }

    private T[] CopyAllElements(T[] temporary)
    {
        for (int i = 0; i < this.Count; i++)
        {
            int index = (this.headIndex + i) % this.capacity;
            temporary[i] = this.workArray[index];
            this.teilIndex = this.Count;
            this.headIndex = 0;
        }
        return temporary;
    }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count >= this.capacity)
        {
            this.Resize(); // 4 8 16 32 64 128 256 512
        }

        this.workArray[this.teilIndex] = element;
        this.teilIndex = (this.teilIndex += 1) % this.capacity;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException();
        }

        T value = this.workArray[this.headIndex];

        this.headIndex = (this.headIndex += 1) % this.capacity;
        this.Count--;

        return value;
    }

    public T[] ToArray()
    {
        T[] temporary = new T[this.Count];
        return this.CopyAllElements(temporary);
    }
}


public class Example
{
    public static void Main()
    {
        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Stack<int> stack = new Stack<int>();
        //ArrayStack<int> stack = new ArrayStack<int>();
        //stack.Push(1);
        //stack.Push(2);
        //stack.Push(3);
        //stack.Push(4);
        //stack.Push(5);
        //stack.Push(6);
        //stack.Push(7);

        //Console.WriteLine(stack.Pop());

        //Console.WriteLine(stack.Count);

        //Console.WriteLine(string.Join(", ", stack.ToArray()));
    }
}

public class ArrayStack<T>
{
    private const int InitialCapacity = 16;

    private T[] elements;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException();
        }

        this.Count--;
        T element = this.elements[this.Count];
        this.elements[this.Count] = default(T);

        return element;
    }

    public T[] ToArray()
    {
        T[] temporary = new T[this.Count];

        for (int index = 0; index < this.Count; index++)
        {
            temporary[index] = this.elements[this.Count - 1 - index];
        }

        return temporary;
    }

    private void Grow()
    {
        T[] temporary = new T[this.elements.Length * 2];
        Array.Copy(this.elements, temporary, this.Count);
        this.elements = temporary;
    }
}
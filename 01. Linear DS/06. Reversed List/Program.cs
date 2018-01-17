using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        
    }
}

public class ReversedList<T> : IEnumerable<T>
{
    public ReversedList()
    {
        this.capacity = 2;
        this.workArray = new T[this.capacity];
    }

    private int capacity;

    private T[] workArray;

    private bool isValid(int index) => index >= 0 && index < this.Count;

    public int Capacity => this.capacity;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            int reversedIndex = this.Count - 1 - index;

            if (this.isValid(reversedIndex))
            {
                return this.workArray[reversedIndex];
            }

            throw new InvalidOperationException();
        }
        set
        {
            int reversedIndex = this.Count - 1 - index;

            if (!this.isValid(reversedIndex))
            {
                throw new InvalidOperationException();
            }

            this.workArray[reversedIndex] = value;
        }
    }

    public void Add(T value)
    {
        if (this.capacity <= this.Count)
        {
            this.Resize();
        }
        
        this.workArray[this.Count] = value;
        this.Count++;
    }

    public void RemoveAt(int index)
    {
        int reversedIndex = this.Count - 1 - index;

        if (this.isValid(reversedIndex))
        {
            this.ShiftLeft(reversedIndex);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.workArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Resize()
    {
        var oldCapacity = this.capacity;
        var temporaryArray = new T[this.capacity *= 2];

        for (int i = 0; i < this.workArray.Length; i++)
        {
            temporaryArray[i] = this.workArray[i];
        }

        this.workArray = temporaryArray;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.workArray[i] = this.workArray[i + 1];
        }

        this.workArray[this.Count - 1] = default(T);
        this.Count--;
    }
}
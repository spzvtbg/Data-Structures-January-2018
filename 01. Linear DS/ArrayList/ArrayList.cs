using System;

public class ArrayList<T>
{
    public ArrayList(int capacity = 2)
    {
        this.currentArray = new T[capacity];
        this.capacity = capacity;
        this.Count = 0;
    }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            this.EnsureIsValidIndex(index);
            return this.currentArray[index];
        }

        set
        {
            this.EnsureIsValidIndex(index);
            this.currentArray[index] = value;
        }
    }

    public void Add(T element)
    {
        if (this.nextIndex >= this.capacity)
        {
            this.ResizeCurrentArray(this.capacity *= 2);
        }

        this.currentArray[this.Count] = element;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        T element = this[index];

        this[index] = default(T);

        this.ShiftElementsToLeft(index);

        if (this.Count <= this.capacity / 3)
        {
            this.ResizeCurrentArray(this.capacity /= 2);
        }

        this.Count--;
        return element;
    }

    private int capacity;

    private T[] currentArray;

    private int nextIndex => this.Count + 1;

    private void EnsureIsValidIndex(int index)
    {
        if (index < 0 || this.Count < index)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private void ResizeCurrentArray(int newCapacitet)
    {
        T[] temporaryArray = new T[newCapacitet];
        Array.Copy(this.currentArray, temporaryArray, this.Count);
        this.currentArray = temporaryArray;
    }

    private void ShiftElementsToLeft(int index)
    {
        for (int count = index; count < this.Count - 1; count++)
        {
            this[count] = this[count + 1];
        }
    }
}

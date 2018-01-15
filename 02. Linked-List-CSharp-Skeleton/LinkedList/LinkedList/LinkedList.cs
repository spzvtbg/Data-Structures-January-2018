using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = this.head;

        this.head = new Node(item) { Next = old };

        if (this.IsEmpty())
        {
            this.tail = this.head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = this.tail;

        this.tail = new Node(item);

        if (this.IsEmpty())
        {
            this.head = this.tail;
        }
        else
        {
            old.Next = this.tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.head.Value;

        this.head = this.head.Next;

        this.Count--;

        if (this.IsEmpty())
        {
            this.tail = null;
        }

        return item;
    }

    public T RemoveLast()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.tail = newTail;
        }

        this.Count--;

        return item;
    }
   
    public IEnumerator<T> GetEnumerator()
    {
        Node curr = this.head;

        while (curr != null)
        {
            yield return curr.Value;

            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    private Node GetSecondToLast()
    {
        Node node = this.head;

        while (node.Next != this.tail)
        {
            node = node.Next;
        }

        return node;
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node Next { get; set; }
        public T Value { get; }

    }
}

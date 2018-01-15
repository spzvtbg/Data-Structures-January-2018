using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;

    private Node teil;

    private bool IsEmpty => this.Count == 0;

    private Node GetBeforLast()
    {
        Node temporaryNode = this.head;

        while (temporaryNode.Next != this.teil)
        {
            temporaryNode = this.head.Next;
        }

        return temporaryNode;
    }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node first = this.head;

        this.head = new Node(item, first);

        if (this.IsEmpty)
        {
            this.teil = this.head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node last = this.teil;

        this.teil = new Node(item);

        if (this.IsEmpty)
        {
            this.head = this.teil;
        }
        else
        {
            last.Next = this.teil;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.IsEmpty)
        {
            throw new InvalidOperationException();
        }

        T value = this.head.Value;

        this.head = this.head.Next;
        this.Count--;

        if (this.IsEmpty)
        {
            this.teil = null;
        }

        return value;
    }

    public T RemoveLast()
    {
        if (this.IsEmpty)
        {
            throw new InvalidOperationException();
        }

        T value = this.teil.Value;

        if (this.Count == 1)
        {
            this.head = this.teil = null;

            return value;
        }
        else
        {
            Node newTeil = this.GetBeforLast();
            newTeil.Next = null;

            this.teil = newTeil;
        }
        
        this.Count--;

        return value;
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

    private class Node
    {
        internal Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }

        internal T Value { get; set; }

        internal Node Next { get; set; }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.teil = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newHead = new ListNode<T>(element);
            newHead.NextNode = this.head;
            this.head.PreviousNode = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.teil = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newTeil = new ListNode<T>(element);
            newTeil.PreviousNode = this.teil;
            this.teil.NextNode = newTeil;
            this.teil = newTeil;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T firstElement = this.head.Value;
        this.head = this.head.NextNode;

        if (this.head != null)
        {
            this.head.PreviousNode = null;
        }
        else
        {
            this.teil = null;
        }

        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T lastElement = this.teil.Value;
        this.teil = this.teil.PreviousNode;

        if (this.teil != null)
        {
            this.teil.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {

        T[] array = new T[this.Count];
        int index = 0;

        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            array[index] = currentNode.Value;
            currentNode = currentNode.NextNode;
            index++;
        }

        return array;
    }

    private class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PreviousNode { get; set; }
    }

    private ListNode<T> head;
    private ListNode<T> teil;
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}

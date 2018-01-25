using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //LinkedStack<int> stack = new LinkedStack<int>();
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

public class LinkedStack<T>
{
    private Node<T> firstNode { get; set; }

    private Node<T> lastNode { get; set; }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (firstNode == null)
        {
            this.firstNode = new Node<T>(element);
            this.lastNode = new Node<T>(element);
        }
        else
        {
            Node<T> temporary = this.firstNode;
            firstNode = new Node<T>(element, temporary);
        }

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;

        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        Node<T> copy = this.firstNode;
        T[] temporary = new T[this.Count];

        int index = 0;

        while (copy != null)
        {
            T element = temporary[index] = copy.Value;
            copy = copy.NextNode;
            index++;
        }

        return temporary;
    }

    private class Node<T>
    {
        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value { get; set; }

        public Node<T> NextNode { get; set; }
    }
}

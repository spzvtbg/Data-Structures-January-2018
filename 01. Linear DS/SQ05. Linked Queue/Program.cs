using System;

public class Program
{
    public static void Main(string[] args)
    {
        //LinkedQueue<int> queue = new LinkedQueue<int>();
        //queue.Enqueue(1);
        //queue.Enqueue(2);
        //queue.Enqueue(3);
        //queue.Enqueue(4);
        //queue.Enqueue(5);
        //queue.Enqueue(6);

        //Console.WriteLine(queue.Count);
        //Console.WriteLine(queue.Dequeue());
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
    }
}

public class LinkedQueue<T>
{
    private QueueNode<T> head;

    private QueueNode<T> teil;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count <= 0)
        {
            this.head = this.teil = new QueueNode<T>(element);
        }
        else
        {
            var temporary = this.teil;
            this.teil = new QueueNode<T>(element);
            this.teil.PrevNode = temporary;
            temporary.NextNode = this.teil;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count <= 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.head.Value;
        this.head = this.head.NextNode;

        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        QueueNode<T> copy = this.head;
        T[] temporary = new T[this.Count];

        int index = 0;
        while (copy != null)
        {
            temporary[index] = copy.Value;
            copy = copy.NextNode;
            index++;
        }

        return temporary;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }
}

public class Node<T>
{
    public Node(T val)
    {
        this.Value = val;
        this.Next = null;
        this.Previous = null;
    }

    public T Value { get; set; }

    public Node<T> Next { get; set; }

    public Node<T> Previous { get; set; }

    public bool HasNext()
    {
        return (Next == null) ? false : true;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> Head { get; set; }
    private Node<T> Tail { get; set; }
    private int Count { get; set; }

    public DoublyLinkedList()
    {
        this.Head = null;
        this.Tail = null;
        this.Count = 0;
    }

    public void Add(T value)
    {
        Node<T> node = new Node<T>(value);
        switch (Head)
        {
            case null:
                this.Head = node;
                break;
            default:
                Node<T> head = this.Head;
                while (head.HasNext())
                {
                    head = head.Next;
                }
                head.Next = node;
                node.Previous = head;
                break;
        }
        this.Count++;
        this.SetTail();
    }

    public void Clear()
    {
        this.Head = null;
        this.Tail = null;
        this.Count = 0;
    }

    public T Get(int index)
    {
        if (Head == null)
        {
            throw new NullReferenceException();
        }
        Node<T> head = this.Head;
        int num = this.Count - 1;
        if ((index > num) || (index < 0))
        {
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < index; i++)
        {
            head = head.Next;
        }
        return head.Value;
    }

    public void Insert(T val, int index)
    {
        if (Head == null)
        {
            throw new NullReferenceException();
        }
        int num = this.Count - 1;
        Node<T> node = new Node<T>(val);
        if ((index > num) || (index < 0))
        {
            throw new IndexOutOfRangeException();
        }
        if (index == 0)
        {
            node.Next = this.Head;
            this.Head.Previous = node;
            this.Head = node;
        }
        else
        {
            Node<T> head = this.Head;
            Node<T> node3 = this.Head;
            int num2 = 0;
            while (true)
            {
                if (num2 == index)
                {
                    node.Next = head;
                    node3.Next = node;
                    break;
                }
                if (num2 == (index - 1))
                {
                    node3 = head;
                }
                head = head.Next;
                num2++;
            }
        }
        this.Count++;
    }

    public T Remove()
    {
        if (Head == null)
        {
            throw new NullReferenceException();
        }
        Node<T> head = this.Head;
        Node<T> previous = head;
        if (Head.HasNext())
        {
            this.Head = this.Head.Next;
            previous = head;
        }
        else
        {
            previous.Next = null;
            this.SetTail();
        }
        this.Count--;
        return head.Value;
    }

    public T RemoveAt(int index)
    {
        if (Head == null)
        {
            throw new NullReferenceException();
        }
        Node<T> head = this.Head;
        Node<T> node2 = this.Head;
        int num = this.Count - 1;
        if ((index > num) || (index < 0))
        {
            throw new IndexOutOfRangeException();
        }
        int num2 = 0;
        while (true)
        {
            if (num2 >= index)
            {
                Node<T> temp = head.Next;
                node2.Next = temp;
                temp.Previous = node2;
                this.Count--;
                return head.Value;
            }
            node2 = head;
            head = head.Next;
            num2++;
        }
    }

    public T RemoveLast()
    {
        if (Head == null)
        {
            throw new NullReferenceException();
        }
        if (Count == 1)
        {
            T val = Head.Value;
            Head = null;
            Tail = null;
            Count = 0;
            return val;
        }
        else
        {
            Node<T> temp = this.Tail;
            Tail.Previous.Next = null;
            Count--;
            SetTail();
            return temp.Value;
        }
    }

    public int Search(T val)
    {
        int index = 0;
        int notFound = -1;

        Node<T> head = this.Head;
        while (head.HasNext())
        {
            if (head.Value.Equals(val))
            {
                return index;
            }
            else
            {
                head = head.Next;
                index++;
            }
        }
        return notFound;
    }

    private void SetTail()
    {
        Node<T> head = this.Head;
        while (head.HasNext())
        {
            head = head.Next;
        }
        this.Tail = head;
    }
    public override string ToString()
    {
        string str = "";
        if (Count == 1)
        {
            str = str + this.Head.Value.ToString();
        }
        else if (Count > 1)
        {
            Node<T> head = this.Head;
            while (Head.HasNext())
            {
                str = str + head.Value.ToString() + ", ";
                head = head.Next;
            }
            str = str + head.Value.ToString();
        }
        return str;
    }
}
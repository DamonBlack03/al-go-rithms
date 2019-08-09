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
public class LinkedList<T>
{
    private Node<T> Head { get; set; }
    private Node<T> Tail { get; set; }
    private int Count { get; set; }

    public LinkedList()
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
            this.Head = node;
        }
        else
        {
            Node<T> head = this.Head;
            Node<T> node3 = this.Head;
            int num2 = 0;
            while (true)
            {
                if (num2 > index)
                {
                    node.Next = node3.Next;
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
        if (Head.HasNext())
        {
            this.Head = this.Head.Next;
        }
        else
        {
            this.Head = null;
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
                node2.Next = head.Next;
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
        Node<T> head = this.Head;
        Node<T> temp = Tail;
        while (true)
        {
            if (head.Next == this.Tail)
            {
                head.Next = null;
                this.Count--;
                this.SetTail();
                return temp.Value;
            }
            head = head.Next;
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
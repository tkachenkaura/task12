using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode First { get; private set; }
        public SinglyLinkedListNode Last { get; private set; }
        public int Count { get; private set; }

        public void Add(object value)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(value);
            if (First == null)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
            }
            Last = node;
            Count++;
        }

        public void AddFirst(object value)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(value);
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                node.Next = First;
                First = node;
            }
            Count++;
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Count)
            {
                Add(value);
            }
            else
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(value);
                SinglyLinkedListNode current = First;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;
                Count++;
            }
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(object value)
        {
            SinglyLinkedListNode current = First;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public object[] ToArray()
        {
            object[] array = new object[Count];
            SinglyLinkedListNode current = First;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }

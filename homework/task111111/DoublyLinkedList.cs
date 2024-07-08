using DataStructuresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task111111
{
    
        namespace DataStructuresLib
    {
        public class DoublyLinkedList : SinglyLinkedList
        {
            private DoublyLinkedListNode _first;
            private DoublyLinkedListNode _last;

            public new DoublyLinkedListNode First => _first;
            public new DoublyLinkedListNode Last => _last;

            public new void Add(object value)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(value);
                if (_first == null)
                {
                    _first = node;
                    _last = node;
                }
                else
                {
                    _last.Next = node;
                    node.Previous = _last;
                    _last = node;
                }
                Count++;
            }

            public new void AddFirst(object value)
            {
                DoublyLinkedListNode node = new DoublyLinkedListNode(value);
                if (_first == null)
                {
                    _first = node;
                    _last = node;
                }
                else
                {
                    node.Next = _first;
                    _first.Previous = node;
                    _first = node;
                }
                Count++;
            }

            public new bool Remove(object value)
            {
                DoublyLinkedListNode current = _first;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        if (current.Previous != null)
                        {
                            current.Previous.Next = current.Next;
                        }
                        else
                        {
                            _first = current.Next;
                        }

                        if (current.Next != null)
                        {
                            current.Next.Previous = current.Previous;
                        }
                        else
                        {
                            _last = current.Previous;
                        }

                        Count--;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            public void RemoveFirst()
            {
                if (_first != null)
                {
                    _first = _first.Next;
                    if (_first != null)
                    {
                        _first.Previous = null;
                    }
                    else
                    {
                        _last = null;
                    }
                    Count--;
                }
            }

            public void RemoveLast()
            {
                if (_last != null)
                {
                    _last = _last.Previous;
                    if (_last != null)
                    {
                        _last.Next = null;
                    }
                    else
                    {
                        _first = null;
                    }
                    Count--;
                }
            }

            public new object[] ToArray()
            {
                object[] array = new object[Count];
                DoublyLinkedListNode current = _first;
                int index = 0;
                while (current != null)
                {
                    array[index++] = current.Value;
                    current = current.Next;
                }
                return array;
            }
        }
    }

}

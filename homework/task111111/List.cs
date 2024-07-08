using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

    public class List
    {
        private object[] _items;
        private int _count;

        public List()
        {
            _items = new object[4];
            _count = 0;
        }

        public List(int capacity)
        {
            _items = new object[capacity];
            _count = 0;
        }

        public int Count => _count;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(object item)
        {
            EnsureCapacity(_count + 1);
            _items[_count++] = item;
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();
            EnsureCapacity(_count + 1);
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            _count++;
        }

        public bool Remove(object item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[--_count] = null;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = null;
            }
            _count = 0;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i] == null && item == null) return i;
                if (_items[i] != null && _items[i].Equals(item)) return i;
            }
            return -1;
        }

        public object[] ToArray()
        {
            object[] array = new object[_count];
            Array.Copy(_items, array, _count);
            return array;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
            {
                object temp = _items[i];
                _items[i] = _items[j];
                _items[j] = temp;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (min > _items.Length)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if (newCapacity < min) newCapacity = min;
                object[] newItems = new object[newCapacity];
                Array.Copy(_items, newItems, _count);
                _items = newItems;
            }
        }
    }


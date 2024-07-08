using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLib
{
    public class DoublyLinkedListNode
    {
        public object Value { get; set; }
        public DoublyLinkedListNode Next { get; set; }
        public DoublyLinkedListNode Previous { get; set; }

        public DoublyLinkedListNode(object value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}

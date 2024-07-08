using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class BinaryTree
    {
        public TreeNode Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                AddTo(Root, value);
            }
            Count++;
        }

        private void AddTo(TreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(int value)
        {
            return Find(value) != null;
        }

        private TreeNode Find(int value)
        {
            TreeNode current = Root;
            while (current != null)
            {
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else if (value > current.Value)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            int index = 0;
            ToArray(Root, result, ref index);
            return result;
        }

        private void ToArray(TreeNode node, int[] array, ref int index)
        {
            if (node == null) return;
            ToArray(node.Left, array, ref index);
            array[index++] = node.Value;
            ToArray(node.Right, array, ref index);
        }
    }


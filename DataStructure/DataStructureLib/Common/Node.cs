using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        private T data;
        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        private Node<T> next;
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public Node()
        {
            data=default(T);
            next = null;
        }

        public Node(T data,Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public Node(Node<T> node)
        {
            //为什么不是
            //this.data = node.data;
            //this.next = node.next;
            

            this.next = node.next;
        }

        public Node(T node)
        {
            this.data = node;
            this.next = null;
        }
    }
}

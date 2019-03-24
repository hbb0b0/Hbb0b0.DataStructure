using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.BinaryTree
{
    
        /// <summary>
        /// 二叉树节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Node<T>
        {
            /// <summary>
            /// 左孩子
            /// </summary>
            private Node<T> leftChild;

            public Node<T> LeftChild
            {
                get { return leftChild; }
                set { leftChild = value; }
            }

            /// <summary>
            /// 右孩子
            /// </summary>
            private Node<T> rightChild;

            public Node<T> RightChild
            {
                get { return rightChild; }
                set { rightChild = value; }
            }

            /// <summary>
            /// 节点数据
            /// </summary>
            private T data;

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            /// <summary>
            /// 节点构造函数
            /// </summary>
            /// <param name="data">节点数据</param>
            /// <param name="leftChild">左孩子</param>
            /// <param name="rightChild">右孩子</param>
            public Node(T data,Node<T> leftChild,Node<T> rightChild)
            {
                this.data = data;
                this.leftChild = leftChild;
                this.rightChild = rightChild;
            }

            public Node():this(default(T), null, null)
            {
            }

            public Node(T data):this(data, null, null)
            {
                
            }

            public Node(Node<T> leftChild, Node<T> rightChild):this(default(T),leftChild ,rightChild)
            {
               
            }
        }
    
}

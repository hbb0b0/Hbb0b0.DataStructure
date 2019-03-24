using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 链式队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkQueue<T>:IQueue<T>
    {
        /// <summary>
        /// 队列头
        /// </summary>
        private Node<T> front;

        public Node<T> Front
        {
            get
            {
                return front;
            }
        }
        
        /// <summary>
        /// 队列尾
        /// </summary>
        private Node<T> rear;

        public Node<T> Rear
        {
            get
            {
                return rear;
            }
        }
        /// <summary>
        /// 节点个数
        /// </summary>
        private int num;

        #region IQueue<T> 成员

        public int GetLength()
        {
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(num==0)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            front = rear = null;
            num = 0;
        }

        public void In(T item)
        {
            Node<T> current = new Node<T>(item);

            if (rear == null)
            {
                //队尾
                rear = current;
                
                //队头
                front = rear;
            }
            else
            {
                rear.Next = current;
                rear = current;
            }
            ++num;
        }

        public T Out()
        {
            if (IsEmpty())
            {
                throw new DataStructureException("链式队列为空");
            }
            Node<T> current = front;
            front = front.Next;
            --num;
            return current.Data;
        }

        public T GetFront()
        {
            if(IsEmpty())
            {
                throw new DataStructureException("链式队列为空");
            }
            
            return front.Data;
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public LinkQueue()
        {
            front = rear = null;
            num = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 顺序队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceQueue<T>:IQueue<T> 
    {
        //存放队列元素的数组
        private T[] data=null;

        //队首指针
        int front = 0;

        public int Front
        {
            get
            {
                return front;
            }
        }

        //队尾指针
        int rear = 0;

        public int Rear
        {
            get
            {
                return rear;
            }
        }

        //最大容量
        int maxSize = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size"></param>
        public SequenceQueue(int size)
        {
            maxSize = size;
            data = new T[size];
            front = rear = -1;

        }

        /// <summary>
        /// 是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if((rear-front)==maxSize)
            {
                return true;
            }
            return false;
        }

        #region IQueue 成员

        public int GetLength()
        {
            return (rear-front);
        }

        public bool IsEmpty()
        {
           if(rear==front)
           {
               return true ;
           }
           return false ;
        }

        public void Clear()
        {
            data = null;
            front = rear = -1;
        }

        public void In(T item)
        {
            if (!IsFull())
            {
                data[++rear] = item;
            }
            else
            {
                throw new DataStructureException("队列已满");
            }
        }

        public T Out()
        {
            if (!IsEmpty())
            {
                return data[++front];
            }
            else
            {
                throw new DataStructureException("队列已空");
            }
            //return default(T);
        }

        public T GetFront()
        {
            if (!IsEmpty())
            {
                return data[front+1];
            }
            else
            {
                throw new DataStructureException("队列已空");
            }
            //return default(T);
        }

        #endregion
    }
}

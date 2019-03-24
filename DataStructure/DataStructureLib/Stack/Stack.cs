using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    public class Stack<T>:IStack<T>
    {
        private int  currentIndex=0;
        private int maxSize = 0;
        private T[] data = null;

        public int MaxSize
        {
            get
            {
                return maxSize;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
        }

        public bool IsFull()
        {
            if(currentIndex==maxSize-1)
            {
                return true;
            }
            return false;
        }

        public Stack(int size)
        {
            currentIndex = -1;
            maxSize = size;
            data = new T[maxSize]; 
        }

        public Stack()
        {
            currentIndex = -1;
            maxSize = 10;
            data = new T[maxSize];
        }

        #region IStack<T> 成员

        public bool IsEmpty()
        {
            if(currentIndex==-1)
            {
                return true;
            }
            return false;
        }

        public T Pop()
        {
            if (!IsEmpty())
            {
                T tmp = data[currentIndex];
                currentIndex--;
                return tmp;
            }
            else
            {
                throw new DataStructureException("栈已空");
            }
        }

        public void Push(T p)
        {
            if (!IsFull())
            {
                currentIndex++;
                data[currentIndex] = p;
            }
            else
            {
                throw new DataStructureException("栈已满");
            }

        }

        public int GetLength()
        {
            return currentIndex+1;
        }

        public T GetPop()
        {
            return data[currentIndex];
        }

        public void Clear()
        {
            data = null;
            currentIndex = -1;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 链栈
    /// </summary>
    /// <remarks>栈的链式存贮</remarks>
    public class LinkStack<T>:IStack<T>
    {

        private Node<T> m_top;
        private int m_count;

        public LinkStack()
        {
            m_top = null;
            m_count = 0;
        }

        public Node<T> Top
        {
            get
            {
                return m_top;
            }

            set
            {
                m_top = value;
            }
        }

        public  int Count
        {
            get
            {
                return m_count;
            }
        }

        #region IStack<T> 成员

        public bool IsEmpty()
        {
            if(m_top==null && m_count==0)
            {
                return true;
            }
            return false;
        }

        public T Pop()
        {
            if (!IsEmpty())
            {
                //获取 数据
                T current = m_top.Data;

                //当前节点指向当前节点的上一个节点
                m_top = m_top.Next;

                //长度递减1

                --m_count;

                return current;
            }
            else
            {
                throw new DataStructureException("链栈已空！");
            }
        }

        public void Push(T p)
        {
            Node<T> current = new Node<T>(p);

            if (m_top == null)
            {
                m_top = current;
            }
            else
            {
                current.Next = m_top;
                m_top = current;
            }
            ++m_count;
        }

        public int GetLength()
        {
            return m_count;
        }

        public T GetPop()
        {
            if (!IsEmpty())
            {
                return Top.Data;
            }
            else
            {
                throw new DataStructureException("链栈已空！");
            }
        }

        public void Clear()
        {
            m_top = null;
            m_count = 0;
        }

        #endregion
    }
}

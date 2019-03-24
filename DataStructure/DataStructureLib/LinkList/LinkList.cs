using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class LinkList<T>:IListDS<T>,ICloneable
    {
        public LinkList()
        {
            head = null;
        }

        private Node<T> head;
        public Node<T> Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }
        #region IListDS<T> 成员

        public int GetLength()
        {

            int len = 0;
            Node<T> currentHead = head;
            while (currentHead != null)
            {
                len++ ;
                currentHead = currentHead.Next;
                
            }
            return len;
        }

        public void Clear()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            if(head==null )
            {
                return true;
            }
            return false;
        }

        public void Insert(T node, int i)
        {
            if(IsEmpty ())
            {
                throw new DataStructureException("列表为空不能插入！");
            }
            if(i<0)
            {
                throw new DataStructureException("插入位置不能小于0！");
            }
            
            //找到插入位置
            Node<T> current=head;
            int currentIndex = 0;
            while (current!=null)
            {
                if(currentIndex==i)
                {
                    break;
                }
                currentIndex++;
                current = current.Next;
            }

            if(current !=null)
            {
                Node<T> insertNode=new Node<T>(node);

                Node<T> tmp = current.Next;
                current.Next = insertNode;
                insertNode.Next = tmp;
            }
            
        }

        public void Delete(int i)
        {
            if(IsEmpty())
            {
                return;
            }

            if (i < 0 )
            {
                throw new DataStructureException("删除位置不能小于0！");
            }
            if(i>GetLength())
            {
                return;
            }

            //删除头
            if(i==0)
            {
                head = head.Next;
                return;
            }
           

            //找出删除位置的前一个位置
            int currentIndex = 0;
            Node<T> currentHead = head;
            while (currentHead!= null )
            {
                if(currentIndex==i-1)
                {
                    break;
                }
                currentIndex++;
                currentHead = currentHead.Next;
            }

            if (currentHead.Next != null)
            {
                currentHead.Next = currentHead.Next.Next;
            }

           

        }

        public int Locate(T node)
        {
            int currentIndex = 0;
            bool hasNode = false;
            Node<T> currentHead = head;

            T data = new Node<T>(node).Data;
            while (currentHead!= null )
            {
                if (data.Equals(currentHead.Data))
                {
                    hasNode = true;
                    break;
                }
                currentIndex++;

                currentHead = currentHead.Next;
            }

            if (hasNode)
            {
                return currentIndex;
            }
            else
            {
                return -1;
            }
            
        }

        public T GetElement(int i)
        {
            int currentIndex = 0;

            Node<T> currentHead = head;

            while (currentHead.Next != null && currentIndex<i)
            {
                currentIndex++;

                currentHead = currentHead.Next;
            }

            return currentHead.Data;

        }

        public void Append(T node)
        {
            if (head == null)
            {
                head = new Node<T>(node);
                return;
            }
            Node<T> currentHead = head;

            while (currentHead.Next != null )
            {
                currentHead = currentHead.Next;
            }

            currentHead.Next = new Node<T>(node );

        }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            LinkList<T> newList = new LinkList<T>();

            Node<T> currentNode=head ;
            while (currentNode !=null)
            {
                newList.Append( currentNode.Data );
                currentNode = currentNode.Next;
            }

            return newList;
        }

        #endregion
    }
}

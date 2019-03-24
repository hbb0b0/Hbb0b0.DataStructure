using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    public class SequenceList<T>:IListDS<T>
    {
        
        /// <summary>
        /// 数据
        /// </summary>
        private T[] data;

        public T[] Data
        {
            get
            {
                return data;
            }
           
        }

        /// <summary>
        /// 最大长度
        /// </summary>

        private int maxSize;

        public int MaxSize
        {
            get
            {
                return maxSize;
            }

            
        }


        //最后的位置
        private int last;

        public int Last
        {
            get
            {
                return last;
            }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index1"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return data[index];
            }
        }


        #region IListDS<T> 成员

        public int GetLength()
        {
            return last + 1;
        }

        public void Clear()
        {
            last = -1;
        }

        public bool IsEmpty()
        {
            if(last==-1)
            {
                return true;
            }
            return false;
        }

        public void Insert(T node, int locate)
        {
            //插入位置的验证
            if (locate < 0 || locate > maxSize - 1)
            {
                throw new DataStructureException("插入位置不正确");
            }

            if(IsFull ())
            {
                throw new DataStructureException("顺序表已满");
            }

         
            //插入位置是中间节点
            if (locate >= 0 && locate <=last)
            {
                //i之后的节点顺次向后移
                for (int currentIndex =last+1 ; currentIndex >locate; currentIndex--)
                {
                    data[currentIndex] = data[currentIndex - 1];
                }
                //插入位置放入新节点
                data[locate] = node;
                //最后位置+1
                last++;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="i">删除位置</param>
        public void Delete(int localte)
        {
            //删除位置的验证
            if(localte<0||localte>maxSize-1)
            {
                throw new DataStructureException("索引位置不正确");
            }

            T[] newData=new T[last-1];
            //删除的中间节点
            if(localte>=0 && localte<=last )
            {
                //locate之后的节点依次前移
                for (int currentIndex =localte ; currentIndex  < last;currentIndex ++ )
                {
                    data[currentIndex] = data[currentIndex + 1];  
                }
                data[last] = default(T);
                //最后位置-1
                last--;
            }
           
        }

        /// <summary>
        /// 定位节点的位置
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Locate(T node)
        {
            //如果为空，报异常
            if(IsEmpty ())
            {
                throw new DataStructureException("顺序表为空");
            }

            //查找位置
            int result = -1;
            for (int i = 0; i <=last; i++)
            {
              if(data[i].Equals(node))
              {
                  result = i;
                  break;
              }
            }

            return result;
        }

        /// <summary>
        /// 获取某一索引的节点
        /// </summary>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public T GetElement(int i)
        {
            var result = default(T);
         
            if (i >= 0 && i <=last)
            {
                result = data[i];
            }
            return result;
        }

        public void Append(T node)
        {
            if(IsFull())
            {
                throw  new DataStructureException("表已满");
            }

            last++;
            data[last] = node;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public SequenceList(int size)
        {
            data = new T[size];
            maxSize = size;
            last = -1;
        }

        /// <summary>
        /// 是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if(last==maxSize-1)
            {
                return true;
            }
            return false;
        }

    }
}

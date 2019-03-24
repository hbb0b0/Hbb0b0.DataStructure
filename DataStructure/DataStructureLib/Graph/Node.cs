using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.Graph
{
    /// <summary>
    /// 顶点
    /// </summary>
    public class Node<T> 
    {
        /// <summary>
        /// 顶点信息
        /// </summary>
        private T data;

        public Node(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        
        public override bool Equals(object obj)
        {
            if(obj ==null || GetType()!=obj.GetType() )
            {
                return false;
            }

            Node<T> current = obj as Node<T>;

            //运算符“==”无法应用于"T"和"T"类型的操作数
            //return (data == current.data);

            //这种写法就没有问题
            return data.Equals(current.data);
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}

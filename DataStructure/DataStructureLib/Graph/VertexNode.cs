using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.Graph
{
    /// <summary>
    /// 邻接节点
    /// </summary>
    public class VertexNode<T>
    {
        /// <summary>
        /// 图顶点
        /// </summary>
        private Node<T> data;

        /// <summary>
        /// 图顶点
        /// </summary>
        public Node<T> Data
        {
            get { return data; }
            set { data = value; }
        }
        /// <summary>
        /// 第一个邻接表节点
        /// </summary>
        private AdjacentListNode firstAdjacentListNode;

        /// <summary>
        /// 第一个邻接表节点
        /// </summary>
        public AdjacentListNode FirstAdjacentListNode
        {
            get { return firstAdjacentListNode; }
            set { firstAdjacentListNode = value; }
        }

        public VertexNode():this(null,null)
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adjListNode"></param>
        public VertexNode(Node<T> data,AdjacentListNode adjListNode)
        {
            this.data = data;
            this.firstAdjacentListNode = adjListNode;
        }

        public VertexNode(Node<T> data):this(data,null)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.Graph
{
    /// <summary>
    /// 邻接表
    /// </summary>
    public class AdjacentListNode
    {
        /// <summary>
        /// 邻接顶点序号
        /// </summary>
        private int adjacentVertexNodeIndex;

        /// <summary>
        /// 邻接顶点序号
        /// </summary>
        public int AdjacentVertexNodeIndex
        {
            get { return adjacentVertexNodeIndex; }
            set { adjacentVertexNodeIndex = value; }
        }

        /// <summary>
        /// 下一个邻接表节点字段
        ///</summary>
        private AdjacentListNode next;

        /// <summary>
        /// 下一个邻接表节点
        ///</summary>
        public AdjacentListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="adjVertextNode"></param>
        public AdjacentListNode(int adjVertextNodeIndex):this(adjVertextNodeIndex,null)
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="adjVertextNodeIndex">节点序号</param>
        /// <param name="next">下一邻接表节点</param>
        public AdjacentListNode(int adjVertextNodeIndex,AdjacentListNode next)
        {
            this.adjacentVertexNodeIndex = adjVertextNodeIndex;
            this.next = next;
        }
    }
}

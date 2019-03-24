using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.Graph
{
    /// <summary>
    /// 无向图邻接矩阵类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GraphAdjMatrix<T>:IGraph<T>
    {
        /// <summary>
        /// 顶点数组
        /// </summary>
        private DataStructureLib.Graph.Node<T>[] nodes;
        /// <summary>
        /// 邻接矩阵
        /// </summary>
        private int[,] matrix;
        /// <summary>
        /// 边的数目
        /// </summary>
        private int edgeNum;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">顶点数</param>
        public GraphAdjMatrix(int n)
        {
            nodes = new Node<T>[n];

            matrix = new int[n, n];

            edgeNum = 0;
            
        }

        /// <summary>
        /// 是否是图的顶点
        /// </summary>
        public bool IsNode(Node<T> v)
        {
            foreach (var item in nodes)
            {
                if(item.Equals(v))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取索引为index的顶点
        /// </summary>
        /// <param name="index1">顶点索引</param>
        public Node<T> GetNode(int index)
        {
            return nodes[index];
        }

        /// <summary>
        /// 设置索引为index的顶点信息
        /// </summary>
        /// <param name="index1">顶点索引</param>
        /// <param name="node">顶点信息</param>
        public void SetNode(int index, Node<T> node)
        {
            nodes[index] = node;
        }

        /// <summary>
        /// 获取索引为[index1,index2]的邻接矩阵值
        /// </summary>
        public int GetMatrix(int index1, int index2)
        {
            return matrix[index1, index2];
        }

        /// <summary>
        /// 设置索引为[v1,v2]邻接矩阵的值
        /// </summary>
        public void SetMatrix(int index1, int index2, int val)
        {
            matrix[index1, index2] = val;
        }

        /// <summary>
        /// 获取顶点的索引
        /// </summary>
        /// <param name="node">顶点</param>
        public int GetNodeIndex(Node<T> node)
        {
            int index = -1;
            for (int i = 0; i < nodes.Length;i++ )
            {
                if(nodes[i].Equals (node))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// 设置无向图顶点关系
        /// </summary>
        /// <param name="v1">顶点v1</param>
        /// <param name="v2">顶点v2</param>
        /// <param name="val">
        /// 0代表无连接
        /// 1代表连接
        /// </param>
        private void SetEdge(Node<T> v1,Node<T> v2,int val)
        {
            //判断顶点是否是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                return;
            }

            //获取顶点索引
            int index1 = -1, index2 = -1;
            index1 = GetNodeIndex(v1);
            index2 = GetNodeIndex(v2);

            //设置邻接矩阵中的值
            if (matrix[index1, index2] != val)
            {
                matrix[index1, index2] = val;

                matrix[index2, index1] = val;
                if (val == 1)
                {
                    edgeNum++;
                }
                else
                {
                    edgeNum--;
                }
            }

        }

        #region IGraph<T> 成员

        public int GetNumOfVertex()
        {
            return nodes.Length;
        }

        public int GetNumOfEdge()
        {
            return edgeNum;
        }

        public void AddEdge(Node<T> v1, Node<T> v2 ,int val )
        {
            SetEdge(v1,v2,1 );
            
        }

        public void DeleteEdge(Node<T> v1, Node<T> v2)
        {
            SetEdge(v1, v2, 0);
            
        }

        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            bool result=false;
            //判断顶点是否是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
               return result ;
            }

            //获取顶点索引
            int index1 = -1, index2 = -1;
            index1 = GetNodeIndex(v1);
            index2 = GetNodeIndex(v2);
            
            if(matrix[index1,index2]==1)
            {
                result = true;
            }
            return result;

        }

        #endregion

    }
}

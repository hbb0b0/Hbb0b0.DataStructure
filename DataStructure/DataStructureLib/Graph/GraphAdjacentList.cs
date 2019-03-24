using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataStructureLib.Graph
{
    /// <summary>
    /// 图邻接表
    /// </summary>
    /// <remarks></remarks>
    public class GraphAdjacentList<T> : IGraph<T>
    {
        /// <summary>
        /// 邻接节点数组
        /// </summary>
        private VertexNode<T>[] vertexNodeList;

        /// <summary>
        /// 存储是否已访问过节点数组
        /// </summary>
        private int[] visited;

        /// <summary>
        /// 遍历路线
        /// </summary>
        private List<string> path;

        /// <summary>
        /// 路线分隔符
        /// </summary>
        private char pathSplitchar = ',';

        /// <summary>
        /// 路线分隔符
        /// </summary>
        public char PathSplitchar
        {
            get
            {
                return pathSplitchar;
            }

            set
            {
                pathSplitchar = value;
            }
        }

        /// <summary>
        /// 路径
        /// </summary>
        public List<string> Path
        {
            get {
                List<string> realPath = new List<string>();
                for (int i = 0; i < path.Count; i++)
                {
                    if(path[i]!=string.Empty )
                    {
                        if(path[i].EndsWith(pathSplitchar.ToString()))
                        {
                            string currenPath = path[i].Substring(0, path[i].Length - pathSplitchar.ToString().Length);
                            realPath.Add(currenPath);
                        }
                    }
                }
                return realPath; 
            }

        }

        public VertexNode<T>[] VertexNodeList
        {
            get { return vertexNodeList; }
            set { vertexNodeList = value; }
        }

        /// <summary>
        /// 邻接点索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public VertexNode<T> this[int index]
        {
            get
            {
                return vertexNodeList[index];
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nodes"></param>
        public GraphAdjacentList(Node<T>[] nodes)
        {
            //初始化临界点数组
            vertexNodeList = new VertexNode<T>[nodes.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                vertexNodeList[i] = new VertexNode<T>(nodes[i]);
            }

            //初始化已访问数据
            visited = new int[nodes.Length];

            //初始化遍历路线
            path = new List<string>();
        }

        /// <summary>
        /// 是否是图的顶点
        /// </summary>
        public bool IsNode(Node<T> v)
        {
            bool result = false;
            for (int i = 0; i < vertexNodeList.Length; i++)
            {
                VertexNode<T> current = vertexNodeList[i];
                if (current.Data.Equals(v))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// 获取顶点的索引
        /// </summary>
        /// <param name="node">顶点</param>
        public int GetNodeIndex(Node<T> node)
        {
            int index = -1;
            for (int i = 0; i < vertexNodeList.Length; i++)
            {
                if (vertexNodeList[i].Data.Equals(node))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// 相邻接节点添加节点
        /// </summary>
        /// <param name="v1">邻接节点</param>
        /// <param name="node">节点</param>
        /// <remarks>
        /// 邻接节点vertexNode1添加 node
        /// 1判断FirstAdjacentNode是不是空，如果是空直接把node设为FirstAdjacentNode,返回
        /// 2如果不为空判断node插入位置是不是FirstAdjacentNode，
        ///  (a)如果是，VertextNode需要调整FirstAdjacentNode与FirstAdjacentNode的Next;
        ///  (b)如果否，VetextNode需要调整FirstAdjacentNode的Next节点
        /// </remarks>
        private void AddNodeToVertexNode(VertexNode<T> v1, Node<T> node)
        {
            int index2 = GetNodeIndex(node);

            if (v1.FirstAdjacentListNode == null)
            {
                v1.FirstAdjacentListNode = new AdjacentListNode(index2);
                return;
            }


            if (v1.FirstAdjacentListNode.AdjacentVertexNodeIndex > index2)
            {
                AdjacentListNode firstAdj = new AdjacentListNode(index2, v1.FirstAdjacentListNode);
                v1.FirstAdjacentListNode = firstAdj;
            }
            else
            {

                AdjacentListNode p = v1.FirstAdjacentListNode;
                AdjacentListNode front = v1.FirstAdjacentListNode;

                //查找插入位置
                while (p != null)
                {
                    if (p.AdjacentVertexNodeIndex > index2)
                    {
                        break;
                    }
                    front = p;
                    p = p.Next;
                }
                //插入最后
                if (p == null)
                {
                    front.Next = new AdjacentListNode(index2);
                }
                //插入中间
                else
                {
                    front.Next = new AdjacentListNode(index2, p);
                }
            }

        }

        /// <summary>
        /// 删除相邻接节点v1中的节点node
        /// </summary>
        /// <param name="v1">邻接节点</param>
        /// <param name="node">节点</param>
        /// <remarks>
        /// 邻接节点vertexNode1删除 node
        /// 1判断FirstAdjacentNode是不是空，如果是空，直接返回
        /// 2 判断node是不是FirstAdjacentNode，
        ///  (a)如果是，VertextNode需要调整FirstAdjacentNode与FirstAdjacentNode的Next;
        ///  (b)如果否，VetrextNode需要调整FirstAdjacentNode的Next节点
        /// </remarks>
        private void DeleteNodeToVertexNode(VertexNode<T> v1, Node<T> node)
        {
            int index2 = GetNodeIndex(node);

            if (v1.FirstAdjacentListNode == null)
            {
                return;
            }

            AdjacentListNode p = v1.FirstAdjacentListNode;
            if (p.AdjacentVertexNodeIndex == index2)
            {
                if (p.Next != null)
                {
                    AdjacentListNode firstAdj = new AdjacentListNode(p.Next.AdjacentVertexNodeIndex, p.Next.Next);
                    v1.FirstAdjacentListNode = firstAdj;
                }
                else
                {
                    v1.FirstAdjacentListNode = null;
                }
            }
            else
            {
                AdjacentListNode front = v1.FirstAdjacentListNode;
                //查找node位置
                while (p != null)
                {
                    if (p.AdjacentVertexNodeIndex == index2)
                    {
                        break;
                    }
                    front = p;
                    p = p.Next;
                }

                if (p != null)
                {
                    //为什么front=p.next是错误的？？？
                    front.Next = p.Next;
                }

            }

        }

        #region IGraph<T> 成员

        /// <summary>
        /// 获取顶点数
        /// </summary>
        /// <returns></returns>
        public int GetNumOfVertex()
        {
            return vertexNodeList.Length;
        }

        /// <summary>
        /// 获取边数
        /// </summary>
        /// <returns></returns>
        public int GetNumOfEdge()
        {

            int sum = 0;

            for (int i = 0; i < vertexNodeList.Length; i++)
            {
                //当前邻接节点
                VertexNode<T> current = vertexNodeList[i];

                if (current.FirstAdjacentListNode != null)
                {
                    sum++;
                    AdjacentListNode adjNode = current.FirstAdjacentListNode.Next;
                    //如果下一个邻接节点不为空，那么就有一条边
                    while (adjNode != null)
                    {
                        sum++;
                        adjNode = adjNode.Next;
                    }
                }
            }


            return sum / 2;
        }

        /// <summary>
        /// v1,v2顶点之间添加权重为val的边
        /// </summary>
        /// <remarks></remarks>
        /// <param name="v1">v1顶点</param>
        /// <param name="v2">v2顶点</param>
        /// <param name="val">权重</param>
        public void AddEdge(Node<T> v1, Node<T> v2, int val)
        {
            //判断v1,v2是否是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                return;
            }
            //判断v1,v2之间是否已存在边
            if (IsEdge(v1, v2))
            {
                return;
            }
            //获取v1,v2的顶点索引
            int index1 = GetNodeIndex(v1);
            int index2 = GetNodeIndex(v2);

            //获取v1,v2对应的邻接点
            VertexNode<T> vertexNode1 = this[index1];
            VertexNode<T> vertexNode2 = this[index2];
            //v1-v2邻接表之间加边
            AddNodeToVertexNode(vertexNode1, v2);
            //v2-v1邻接表之间加边
            AddNodeToVertexNode(vertexNode2, v1);
        }

        /// <summary>
        /// v1，v2之间删除边
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void DeleteEdge(Node<T> v1, Node<T> v2)
        {
            //判断v1,v2是否是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                return;
            }
            //判断v1,v2之间是否已存在边
            if (!IsEdge(v1, v2))
            {
                return;
            }
            //获取v1,v2的顶点索引
            int index1 = GetNodeIndex(v1);
            int index2 = GetNodeIndex(v2);

            //获取v1,v2对应的邻接点
            VertexNode<T> vertexNode1 = this[index1];
            VertexNode<T> vertexNode2 = this[index2];
            //vertexNode1邻接表删除v2
            DeleteNodeToVertexNode(vertexNode1, v2);
            //vertexNode2邻接表删除v1
            DeleteNodeToVertexNode(vertexNode2, v1);
        }

        /// <summary>
        /// 顶点 v1,v2之间是否存在边
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            bool result = false;
            //首先判断v1,v2是否是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                return result;
            }

            //获取v1,v2的顶点索引
            int index1 = GetNodeIndex(v1);
            int index2 = GetNodeIndex(v2);

            //获取v1,v2对应的邻接点
            VertexNode<T> vertexNode1 = this[index1];
            VertexNode<T> vertexNode2 = this[index2];
            /*
            //对于大图来说，可以考虑多线程查找。
            //同时开始v1的邻接点是否包含v2;
            /同时开始v2的邻接点是否包含v1;
             任何一个找到则停止查找
            */

            if (vertexNode1.FirstAdjacentListNode != null)
            {
                //查询vertexNode1第一个邻接点是不是v2
                if (vertexNode1.FirstAdjacentListNode.AdjacentVertexNodeIndex == index2)
                {
                    return true;
                }
                //依次查找第一个邻接点的下一个节点是不是v2
                AdjacentListNode p = vertexNode1.FirstAdjacentListNode.Next;
                while (p != null)
                {
                    if (p.AdjacentVertexNodeIndex == index2)
                    {
                        return true;
                    }
                    p = p.Next;
                }
            }
            return result;
        }

        #endregion

        /// <summary>
        /// 深度优先遍历图的顶点
        /// </summary>
        public void DeepFirstSearchAll()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    string currentPath = string.Empty;

                    DeepFirstSearch(i, ref currentPath);

                    path.Add(currentPath);
                }
            }
        }

        /// <summary>
        /// 深度优先遍历图当前邻接点
        /// </summary>
        /// <param name="vertexNode">当前邻接点</param>
        public void DeepFirstSearch(int currentIndex, ref  string currenNodeData)
        {

            visited[currentIndex] = 1;

            VertexNode<T> currentVertextNode = vertexNodeList[currentIndex];

            currenNodeData += currentVertextNode.Data.Data.ToString();

            currenNodeData += pathSplitchar ;

            AdjacentListNode p = currentVertextNode.FirstAdjacentListNode;
            while (p != null)
            {
                if (visited[p.AdjacentVertexNodeIndex] == 0)
                {
                    DeepFirstSearch(p.AdjacentVertexNodeIndex, ref  currenNodeData);
                    
                }
                p = p.Next;

            }
        }

        /// <summary>
        /// 广度优先遍历图的顶点
        /// </summary>
        public void BreadthFirstSearchAll()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    string currentPath = string.Empty;

                    BreadthFirstSearch (i, ref currentPath);

                    path.Add(currentPath);
                }
            }
        }

        /// <summary>
        /// 广度优先遍历当前点的邻接点
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="currenNodeData"></param>
        public void BreadthFirstSearch(int currentIndex, ref  string currenNodeData)
        {
            visited[currentIndex] = 1;

            #region path
            currenNodeData += vertexNodeList[currentIndex].Data.Data.ToString();

            currenNodeData += pathSplitchar;
            #endregion
            //队列
            SequenceQueue<int> queue = new SequenceQueue<int>(visited.Length);

            queue.In(currentIndex );

            while (!queue.IsEmpty())
            {
                int currentVertexNodeIndex = queue.Out();

                //取出当前邻接节点的第一个邻接点
                AdjacentListNode  p = vertexNodeList[currentVertexNodeIndex].FirstAdjacentListNode ;

                //邻接表的
                while (p !=null)
                {
                    if(visited[p.AdjacentVertexNodeIndex]==0)
                    {
                        visited[p.AdjacentVertexNodeIndex] = 1;

                        #region path
                        currenNodeData += vertexNodeList[p.AdjacentVertexNodeIndex].Data.Data.ToString();

                        currenNodeData += pathSplitchar;
                        #endregion
                        queue.In(p.AdjacentVertexNodeIndex);
                    }
                    p = p.Next;
                }
            }
            



        }
    }
}

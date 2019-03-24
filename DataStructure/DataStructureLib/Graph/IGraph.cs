using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.Graph
{
    public interface IGraph<T> 
    {
        /// <summary>
        /// 获取顶点个数
        /// </summary>
        /// <returns>顶点个数</returns>
        int GetNumOfVertex();

        /// <summary>
        /// 获取边或弧的个数
        /// </summary>
        /// <returns>边或弧的个数</returns>
        int GetNumOfEdge();

        /// <summary>
        /// 添加顶点之间权为val的边或弧
        /// </summary>
        /// <param name="v1">顶点v1</param>
        /// <param name="v2">顶点v2</param>
        /// <param name="val">权</param>
        void AddEdge(Node<T> v1,Node<T> v2,int val);

        /// <summary>
        /// 删除顶点之间的边或弧
        /// </summary>
        /// <param name="v1">顶点v1</param>
        /// <param name="v2">顶点v2</param>
        void DeleteEdge(Node<T> v1, Node<T> v2);

        /// <summary>
        /// 判断顶点之间是否有边或弧
        /// </summary>
        bool IsEdge(Node<T> v1, Node<T> v2);

        
    }
}

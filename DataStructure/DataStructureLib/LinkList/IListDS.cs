using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 线性表接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListDS<T>
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 向后插入
        /// </summary>
        /// <param name="node">插入数据</param>
        /// <param name="i">插入位置</param>
        void Insert(T node,int i);

        /// <summary>
        /// 删除指定位置的节点
        /// </summary>
        /// <param name="i">指定位置</param>
        void Delete(int i);

        /// <summary>
        /// 定位树居所在的节点位置
        /// </summary>
        /// <param name="node">数据</param>
        /// <returns>节点位置</returns>
        int  Locate(T node);


        /// <summary>
        /// 获取指定位置节点的数据
        /// </summary>
        /// <param name="i">指定节点</param>
        /// <returns>位置</returns>
        T GetElement(int i);

        /// <summary>
        /// 附加节点数据
        /// </summary>
        /// <param name="node">节点数据</param>
        void Append(T node);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStack<T>
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="p">入栈元素</param>
        void Push(T p);

        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        T  GetPop();

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();
    }
}

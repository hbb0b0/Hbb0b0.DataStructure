using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 队列接口
    /// </summary>
    public interface IQueue<T>
    {
        //求队列的长度
        int GetLength();

        //判断队列是否为空
        bool IsEmpty();
        
        //清空
        void Clear();
        
        //入队
        void In(T item);

        //出队
        T Out();
        
        //获取第一个
        T GetFront();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyMathLib
{
    /// <summary>
    /// 排序算法
    /// </summary>
    public class SortHelper
    {
        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="sortArray"></param>
        /// <returns></returns>
        public static int[] SwapSort(int[] sortArray)
        {
            int[] result = new int[sortArray.Length];
            int tmp=0;
            for (int i = 0; i < sortArray.Length; i++)
            {
                result[i] = sortArray[i];
                for (int j = i+1; j < sortArray.Length; j++)
                {
                    if(sortArray[j]<result[i])
                    {
                        tmp = result[i];
                        result[i] = sortArray[j];
                        sortArray[j] = tmp;
                    }
                }
            }

            return result;
        }
    }
}

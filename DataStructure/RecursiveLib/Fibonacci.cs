using System;

namespace MyMathLib
{
    /// <summary>
    /// 斐波那契数列
    /// </summary>
    public class Fibonacci
    {
        public static int GetNumber(int n)
        {
            if(n<=2)
            {
                return 1;
            }
            else
            {
                return  GetNumber(n-2)+GetNumber(n-1);
            }
        }
    }
}

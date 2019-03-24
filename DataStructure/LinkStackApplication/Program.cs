using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataStructureLib;
namespace LinkStackApplication
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("input your number convert to 2:");

            long currentNumber = long.Parse(Console.ReadLine());
            while (currentNumber!=-1)
            {
                 ConvertTo(currentNumber);
                 Console.WriteLine();
                 Console.WriteLine("input your number convert to 2:");
                 currentNumber= int.Parse (Console.ReadLine());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 二进制转换
        /// </summary>
        /// <param name="number">被转换的10进制数</param>
        static void ConvertTo(long number)
        {
            LinkStack<long> myLinkStack = new LinkStack<long>();

            Console.WriteLine("input number:{0}:", number);
            while(number>0)
            {
                myLinkStack.Push(number % 2);
                number = number / 2;
            }

            Console.Write("Result:");
            while(!myLinkStack .IsEmpty())
            {
                Console.Write(myLinkStack.Pop());
            }

        }

        /// <summary>
        /// 检查列表中括号是否匹配
        /// </summary>
        /// <remarks>
        /// 括号匹配算法说明：
        /// 如果括号序列不为空，执行处理步骤 a：
        /// 处理步骤a:
        /// 1 如果栈为空，将括号入栈
        /// 2 如果序列中的括号与栈顶括号匹配，出栈
        /// 3 如果序列中的括号与栈顶括号不匹配，入栈
        /// 步骤b:
        /// 如果栈为空则匹配，否则不匹配
        /// </remarks>
        /// <param name="list">被检查列表</param>
        /// <returns>是否匹配</returns>
        static bool MachBracket(char[] list)
        {
            
            DataStructureLib.Stack<char> myStatck = new DataStructureLib.Stack<char>(50);

            for (int i = 0; i < list.Length;i++ )
            {

                if (myStatck.IsEmpty())
                {
                    myStatck.Push(list[i]);
                }
                else
                {
                    if (
                    (myStatck.GetPop() == '{' && list[i] == '}')
                    ||
                    (myStatck.GetPop() == '[' && list[i] == ']')
                    ||
                    (myStatck.GetPop() == '(' && list[i] == ')')
                    )
                    {
                        myStatck.Pop();
                    }
                    else
                    {
                        myStatck.Push(list[i]);
                    }
                }

            }

            if(myStatck.IsEmpty())
            {
                return true;
            }

            return false;
        }

    }
}

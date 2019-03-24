using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataStructureLib;
using Hbb0b0.Trace;
namespace SequeceListApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseListTest();

            MergeListTest();

            MergeListProTest();

            PurgeListTest();

            Console.Read();
        }

        private static void PurgeListTest()
        {
            Console.WriteLine();
            Console.WriteLine(Hbb0b0.Trace.FunctionCallHelper.GetCurrentCallFunctionName(null));
            Console.WriteLine();

            SequenceList<int> purgeList = new SequenceList<int>(20);
            purgeList.Append(1);
            purgeList.Append(9);
            purgeList.Append(7);
            purgeList.Append(3);
            purgeList.Append(2);
            purgeList.Append(1);
            purgeList.Append(3);
            purgeList.Append(4);
            purgeList.Append(3);

            Console.WriteLine("----Input data begin-----");
            Show<int>(purgeList);
            Console.WriteLine();
            Console.WriteLine("---End-----");

            SequenceList<int> result= PurgeList(purgeList);

            Show<int>(result);


        }

        private static void MergeListTest()
        {
            Console.WriteLine();
            Console.WriteLine(Hbb0b0.Trace.FunctionCallHelper.GetCurrentCallFunctionName(null));
            Console.WriteLine();

            SequenceList<int?> La = new SequenceList<int?>(3);
            La.Append(1);
            La.Append(5);
            La.Append(8);

            SequenceList<int?> Lb = new SequenceList<int?>(5);
            Lb.Append(1);
            Lb.Append(2);
            Lb.Append(7);
            Lb.Append(8);
            Lb.Append(9);

            Console.WriteLine("----Input data begin-----");
            Show<int?>(La);
            Console.WriteLine();
            Show<int?>(Lb);
            Console.WriteLine();
            Console.WriteLine("---End-----");


            SequenceList<int?> result = MergeList(La, Lb);
            Show<int?>(result);

        }

        private static void MergeListProTest()
        {
            Console.WriteLine();
        
            Console.WriteLine(Hbb0b0.Trace.FunctionCallHelper.GetCurrentCallFunctionName(null));
           
            Console.WriteLine();

            SequenceList<int?> La = new SequenceList<int?>(3);
            La.Append(1);
            La.Append(5);
            La.Append(8);

            SequenceList<int?> Lb = new SequenceList<int?>(5);
            Lb.Append(1);
            Lb.Append(2);
            Lb.Append(7);
            Lb.Append(8);
            Lb.Append(9);

            Console.WriteLine("----Input data begin-----");
            Show<int?>(La);
            Console.WriteLine();
            Show<int?>(Lb);
            Console.WriteLine();
            Console.WriteLine("---End-----");

            SequenceList<int?> result= MergeListPro(La, Lb);

            Show<int?>(result);
        }

        private static void ReverseListTest()
        {
            Console.WriteLine();
            Console.WriteLine(Hbb0b0.Trace.FunctionCallHelper.GetCurrentCallFunctionName(null));
            Console.WriteLine();

            SequenceList<int> sqList = new SequenceList<int>(10);
            for (int i = 0; i < 10; i++)
            {
                sqList.Append(i);
            }

            Console.WriteLine("----Input data begin-----");
            Show<int>(sqList);
            Console.WriteLine();
            Console.WriteLine("---End-----");

            SequenceList<int> result=ReverseList(sqList);

            Show<int>(result);
        }

        /// <summary>
        /// 倒置顺序表
        /// </summary>
        /// <param name="sqList"></param>
        static SequenceList<int> ReverseList(SequenceList<int> sqList)
        {
            SequenceList<int> myList = new SequenceList<int>(sqList.MaxSize);
            int length = sqList.GetLength();
            for (int i = 1; i <=length ;i++ )
            {
                myList.Append(sqList[length-i]);
            }
            return myList;
        }

        /// <summary>
        /// 显示顺序表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myList"></param>
        private static void Show<T>(SequenceList<T> myList)
        {
            Console.WriteLine();
            for (int i = 0; i <= myList.Last;i++ )
            {
                Console.Write(myList[i]+ ","); ;
            }
            
        }

        /// <summary>
        /// 合并顺序表
        /// </summary>
        /// <param name="la"></param>
        /// <param name="lb"></param>
        static SequenceList<int?> MergeList(SequenceList<int?> la, SequenceList<int?> lb)
        {
            //合并后的表长度 length=la.MaxSize+lb.MaxSize-1
            int length=la.MaxSize+lb.MaxSize;
            SequenceList<int?> lc = new SequenceList<int?>(length );


            //复制La到myList
            for (int i = 0; i < la.GetLength(); i++)
            {
                lc.Append(la[i]);
            }

            //Lb中的值与myList比较，如果当前值Lb[i]比myList的某个位置的值相等或等于，
            //那么lb[i]插入到mylist对应的位置中，否则lb[i]放到mylist的末尾。
            for (int i = 0; i < lb.GetLength(); i++)
            {
                //是否找到lb[i]<=mylist[j]的标志
                bool find = false;

                //开始查找位置
                int startLocation = 0;

                for (int j = startLocation; j < length;j++ )
                {
                    if(lc[j].HasValue && lb[i]<=lc[j])
                    {
                        find = true;
                        lc.Insert(lb[i], j);
                        startLocation = j;
                        break;
                    }
                }
                //如果找不到
                if (!find)
                {
                    lc.Append(lb[i]);
                }
            }

            return lc;
           

        }

        /// <summary>
        /// 倒置顺序表
        /// </summary>
        /// <param name="la">顺序表la</param>
        /// <param name="lb">顺序表lb</param>
        static SequenceList<int?> MergeListPro(SequenceList<int?> la, SequenceList<int?> lb)
        {
            SequenceList<int?> lc = new SequenceList<int?>(la.MaxSize+lb.MaxSize);

            int a =0,b= 0;

            //注意：一次循环插入la,lb中各一个数据
            while(a<la.GetLength() && b<lb.GetLength())
            {
                if (la[a] < lb[b])
                {
                    lc.Append(la[a++]);
                }
                else
                {
                    lc.Append(lb[b++]);
                }
            }

            //la 没有循环完毕，把剩余的la添加到lc中
            while(a<la.GetLength())
            {
                lc.Append(la[a++]);
            }

            //lb 没有循环完毕，把剩余的lb添加到lc中
            while(b<lb.GetLength())
            {
                lc.Append(lb[b++]);
            }

            return lc;

           
        }

        /// <summary>
        /// 去除顺序表的重复项
        /// </summary>
        /// <param name="la"></param>
        static  SequenceList<int> PurgeList(SequenceList<int> la)
        {
            SequenceList<int> myList = new SequenceList<int>(la.MaxSize);

            int j=0;
            bool ifHas = false;
            for (int i = 0; i < la.GetLength(); i++)
            {
                j = 0;
                ifHas = false;
                while( j<la.GetLength())
                {
                    if( i!=j && la[i]==la[j])
                    {
                        ifHas = true;
                        break;
                    }
                    j++;
                    
                }
                if (ifHas==false)
                {
                    myList.Append(la[i]);
                }
            }

            return myList;
        }


    }
}

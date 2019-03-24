using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DataStructureLib;
using System.IO;
namespace LinkListApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read the old LinkList:");
            LinkList<string> myList = new LinkList<string>();
            ReadLinkListXmlFile<string>(ref myList );

            if (myList.IsEmpty() )
            {
                CreatNewLinkList(ref myList);
            }
            Show<string>(myList);

            if (!myList.IsEmpty())
            {
                Save<string>(myList);
            }
            Console.ReadLine();
        }

        private static void CreatNewLinkList(ref LinkList<string> myList)
        {
            Console.WriteLine("Input your string To Create LinkList:");
            string currentNumber = Console.ReadLine();
            while (currentNumber != "")
            {
                myList.Append(currentNumber);
                Console.WriteLine("Input your string:");
                currentNumber = Console.ReadLine();
            }
        }

        /// <summary>
        /// 显示链表节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        static void Show<T>(LinkList<T> list)
        {
            Console.WriteLine();
            Node<T> current=list.Head;
            while(current!=null)
            {
                Console.Write(current.Data);
                current = current.Next;
                if (current!= null)
                {
                    Console.Write("---->");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 保存链表节点信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        static void Save<T>(LinkList<T> list)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "linklist.xml";
            string fullPath = Path.Combine(filePath, fileName);
            XmlSerializer xml = new XmlSerializer(list.GetType());
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                xml.Serialize(fs, list);
                fs.Close();
            }
        }

        /// <summary>
        /// 读取序列化文件链表信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hasXmlObject"></param>
        /// <param name="xmlList">必须是ref，否则传入的xmlList仅仅是个拷贝</param>
        static void  ReadLinkListXmlFile<T>(ref LinkList<T> xmlList)
        {
            try
            {
                LinkList<T> list = new LinkList<T>();
                string filePath = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "linklist.xml";
                string fullPath = Path.Combine(filePath, fileName);
                XmlSerializer xml = new XmlSerializer(list.GetType());
                using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                {
                    list = (LinkList<T>)xml.Deserialize(fs);
                    xmlList = (LinkList<T>)list.Clone();
                    fs.Close();
                }
                
            }
            catch(Exception myEx)
            {
                Console.WriteLine(myEx.Message );
            }


        }
    }
}
 
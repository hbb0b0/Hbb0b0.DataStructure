using System;
using System.Text;
using G=System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructureLib;

namespace LinkListTest
{
    /// <summary>
    /// LinkListTest 的摘要说明
    /// </summary>
    [TestClass]
    public class LinkListTest
    {
        LinkList<int> TestList = null;
        public LinkListTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        //
        // 编写测试时，还可使用以下附加属性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
         //在运行每个测试之前，使用 TestInitialize 来运行代码
         [TestInitialize()]
         public void MyTestInitialize() {
             TestList = new LinkList<int>();
             TestList.Append(1);
             TestList.Append(100);
             TestList.Append(40);

            
         
         }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

       
        /// <summary>
        ///Locate 的测试
        ///</summary>
        public void LocateTestHelper<T>()
        {
            LinkList<int> target = TestList; // TODO: 初始化为适当的值
            int  node = 123; // TODO: 初始化为适当的值
            int expected = -1; // TODO: 初始化为适当的值
            int actual;
            actual = target.Locate(node);
            Assert.AreEqual(expected, actual);

            node = 1;
            expected = 0;
            actual = target.Locate(node);
            Assert.AreEqual(expected, actual);

            node = 100;
            expected = 1;
            actual = target.Locate(node);
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void LocateTest()
        {
            LocateTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            LinkList<int> target = TestList;
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            IsEmptyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Insert 的测试
        ///</summary>
        public void InsertTestHelper<T>()
        {
            

            LinkList<int> target =( LinkList<int>)TestList.Clone() ; // TODO: 初始化为适当的值

            //头
            int node = -1; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            int expected = 0;
            target.Insert(node, i);
            Assert.AreEqual<int>(4, target.GetLength ());
            Assert.AreEqual<int>(-1, target.Head.Next.Data  );

            target = (LinkList<int>)TestList.Clone();
            node = 2;
            i = 1;
            target.Insert(node,i);
            Assert.AreEqual<int>(4, target.GetLength());
            Assert.AreEqual<int>(0, target.Locate(1));
            Assert.AreEqual<int>(1, target.Locate(100));
            Assert.AreEqual<int>(2, target.Locate(2));
            Assert.AreEqual<int>(3, target.Locate(40));


            
        }

        [TestMethod()]
        public void InsertTest()
        {
            InsertTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            LinkList<int> target = TestList ; // TODO: 初始化为适当的值
            int expected = 3; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetLength();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetElement 的测试
        ///</summary>
        public void GetElementTestHelper<T>()
        {
            LinkList<int> target = TestList; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            int expected = 1; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetElement(i);
            Assert.AreEqual(expected, actual);

            i = 1; // TODO: 初始化为适当的值
            expected = 100; // TODO: 初始化为适当的值
            actual = target.GetElement(i);
            Assert.AreEqual(expected, actual);

            i = 2; // TODO: 初始化为适当的值
            expected = 40; // TODO: 初始化为适当的值
            actual = target.GetElement(i);
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void GetElementTest()
        {
            GetElementTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Delete 的测试
        ///</summary>
        public void DeleteTestHelper<T>()
        {
            LinkList<int> target =TestList; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            target.Delete(i);
            
            Assert.AreEqual<int>(2,target.GetLength());
            Assert.AreEqual<int>(100, target.GetElement(0));

            target.Delete(0);
            Assert.AreEqual<int>(1, target.GetLength());
            Assert.AreEqual<int>(40, target.GetElement(0));

        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeleteTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            LinkList<int> target = TestList; // TODO: 初始化为适当的值
            target.Clear();
             Assert.AreEqual<int>(0, target.GetLength());

        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Append 的测试
        ///</summary>
        public void AppendTestHelper<T>()
        {
            LinkList<int> target =TestList; // TODO: 初始化为适当的值
            int  node = 154; // TODO: 初始化为适当的值
            target.Append(node);
            Assert.AreEqual<int>(4, target.GetLength());
            Assert.AreEqual<int>(3, target.Locate(154));
        }

        [TestMethod()]
        public void AppendTest()
        {
            AppendTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///LinkList`1 构造函数 的测试
        ///</summary>
        public void LinkListConstructorTestHelper<T>()
        {
            LinkList<int> target = new LinkList<int>();
            Assert.IsNull(target.Head);
            Assert.IsTrue (target.IsEmpty());
        }

        [TestMethod()]
        public void LinkListConstructorTest()
        {
            LinkListConstructorTestHelper<GenericParameterHelper>();
        }
    }
}

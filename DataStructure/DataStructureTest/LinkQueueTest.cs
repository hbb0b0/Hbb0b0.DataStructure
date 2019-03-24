using DataStructureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 LinkQueueTest 的测试类，旨在
    ///包含所有 LinkQueueTest 单元测试
    ///</summary>
    [TestClass()]
    public class LinkQueueTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
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
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


       
        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            LinkQueue<T> target = new LinkQueue<T>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);

            target.In(default(T));
            Assert.IsFalse(target.IsEmpty());

           
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            IsEmptyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///In 的测试
        ///</summary>
        public void In_OutTestHelperString()
        {
            LinkQueue<string> target = new LinkQueue<string>(); // TODO: 初始化为适当的值

            List<string> list = new List<string>() { "aa", "bb", "cc", "dd", "ee" };

            foreach(string item in list)
            {
                target.In(item);
            }

            foreach (string item in list)
            {
                Assert.AreEqual(item, target.Out());
            }

            try
            {
                target.Out();
            }
            catch (Exception myEx)
            {
                Assert.IsInstanceOfType(myEx ,typeof(DataStructureException));
            }


            
        }

        [TestMethod()]
        public void In_OutTest()
        {
            In_OutTestHelperString();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            LinkQueue<T> target = new LinkQueue<T>(); // TODO: 初始化为适当的值
            
            Assert.AreEqual(0, target.GetLength());

            target.In(default(T));
            Assert.AreEqual(1, target.GetLength());

            target.In(default(T));
            Assert.AreEqual(2, target.GetLength());
            
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetFront 的测试
        ///</summary>
        public void GetFrontTestHelperInt()
        {
            LinkQueue<int> target = new LinkQueue<int>(); // TODO: 初始化为适当的值

            target.In(100);

            target.In(1);

            Assert.AreEqual(100,target.GetFront());
            Assert.AreEqual(100, target.GetFront());
            
        }

        [TestMethod()]
        public void GetFrontTest()
        {
            GetFrontTestHelperInt();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            LinkQueue<T> target = new LinkQueue<T>(); // TODO: 初始化为适当的值

            target.In(default(T));

            target.In(default(T));

            Assert.IsNotNull(target.Front);
            Assert.IsNotNull(target.Rear);


            target.Clear();
            Assert.IsNull(target.Front);
            Assert.IsNull(target.Rear);
            Assert.AreEqual(0,target.GetLength());


        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///LinkQueue`1 构造函数 的测试
        ///</summary>
        public void LinkQueueConstructorTestHelper<T>()
        {
            LinkQueue<T> target = new LinkQueue<T>();

            Assert.IsNull(target.Front);

            Assert.IsNull(target.Rear);

            Assert.AreEqual(0,target.GetLength());
        }

        [TestMethod()]
        public void LinkQueueConstructorTest()
        {
            LinkQueueConstructorTestHelper<GenericParameterHelper>();
        }
    }
}

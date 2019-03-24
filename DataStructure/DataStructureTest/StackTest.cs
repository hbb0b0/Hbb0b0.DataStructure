using DataStructureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 StackTest 的测试类，旨在
    ///包含所有 StackTest 单元测试
    ///</summary>
    [TestClass()]
    public class StackTest
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

        //Stack<T> MyStatck = null;
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    MyStatck = new Stack<T>();
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
        ///Push 的测试
        ///</summary>
        public void PushTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(10); // TODO: 初始化为适当的值
            T p = default(T); // TODO: 初始化为适当的值
            target.Push(p);
            Assert.AreEqual<T>(default(T), (T)target.Pop());
        }

        [TestMethod()]
        public void PushIntTest()
        {
            Stack<int> target = new Stack<int>(5); // TODO: 初始化为适当的值

            target.Push(0);
            target.Push(1);
            target.Push(2);
            target.Push(3);
            Assert.AreEqual<int>(3, target.Pop());
            Assert.AreEqual<int>(2, target.Pop());
            Assert.AreEqual<int>(1, target.Pop());
            Assert.AreEqual<int>(0, target.Pop());
            try
            {
                target.Pop();
                Assert.Fail("设计异常无效");
            }
            catch (Exception myEx)
            {
                Assert.IsInstanceOfType(myEx, typeof(DataStructureException));
            }

        }

        [TestMethod()]
        public void PushFullTest()
        {
            Stack<int> target = new Stack<int>(5); // TODO: 初始化为适当的值

            try
            {
                target.Push(0);
                target.Push(1);
                target.Push(2);
                target.Push(3);
                target.Push(4);
                target.Push(5);
                Assert.Fail("设计异常无效");
            }
            catch (Exception myEx)
            {
                Assert.IsInstanceOfType(myEx, typeof(DataStructureException));
            }
            
          

        }
       

        [TestMethod()]
        public void PushGernericTest()
        {
            //PushTestHelper<GenericParameterHelper>();
            PushTestHelper<string>();
            PushTestHelper<int>();
            

        }

        /// <summary>
        ///Pop 的测试
        ///</summary>
        public void PopTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(); // TODO: 初始化为适当的值
            T expected = default(T); // TODO: 初始化为适当的值
            T actual;
            target.Push(expected);
            actual = target.Pop();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void PopTest()
        {
            PopTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
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
        ///GetPop 的测试
        ///</summary>
        public void GetPopTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(); // TODO: 初始化为适当的值
           
            T actual;

            target.Push(default(T));
            Assert.AreEqual(0, target.CurrentIndex);
            target.Push(default(T));
            Assert.AreEqual(1, target.CurrentIndex);

            actual = target.GetPop();
            actual = target.GetPop();
            actual = target.GetPop();
            actual = target.GetPop();
            Assert.AreEqual(1, target.CurrentIndex);
           
          
        }

        [TestMethod()]
        public void GetPopTest()
        {
            GetPopTestHelper<int >();
            GetPopTestHelper<string>();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(); // TODO: 初始化为适当的值
            
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetLength();
            Assert.AreEqual(expected, actual);

            target.Push(default(T));
            actual = target.GetLength();
            Assert.AreEqual(1, actual);
            target.Push(default(T));
            actual = target.GetLength();
            Assert.AreEqual(2, actual);

            target.Pop();
            actual = target.GetLength();
            Assert.AreEqual(1, actual);

            target.Pop();
            actual = target.GetLength();
            Assert.AreEqual(0, actual);
            
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<int>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            Stack<T> target = new Stack<T>(); // TODO: 初始化为适当的值
            target.Clear();

            Assert.AreEqual(-1, target.CurrentIndex);

        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Stack`1 构造函数 的测试
        ///</summary>
        public void StackConstructorTestHelper<T>()
        {
            Stack<T> target = new Stack<T>();

            Assert.IsNotNull(target);

            Assert.AreEqual(10, target.MaxSize);

            Assert.IsTrue(target.IsEmpty());
        }

        [TestMethod()]
        public void StackConstructorTest()
        {
            StackConstructorTestHelper<GenericParameterHelper>();
        }
    }
}

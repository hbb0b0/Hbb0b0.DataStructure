using DataStructureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 LinkStackTest 的测试类，旨在
    ///包含所有 LinkStackTest 单元测试
    ///</summary>
    [TestClass()]
    public class LinkStackTest
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
        ///Push 的测试
        ///</summary>
        public void PushTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>(); // TODO: 初始化为适当的值
            T p = default(T); // TODO: 初始化为适当的值
            target.Push(p);

            Assert.AreEqual(1, target.Count);
            Assert.AreEqual(p, target.Pop());
        }

        public void PushTestHelperString()
        {
            LinkStack<string> target = new LinkStack<string>(); // TODO: 初始化为适当的值
           


            target.Push("A");

            target.Push("B");

            target.Push("C");

            Assert.AreEqual(3, target.Count);
            Assert.AreEqual<string>("C", target.Pop());
            Assert.AreEqual<string>("B", target.Pop());
            Assert.AreEqual<string>("A", target.Pop());
        }

        [TestMethod()]
        public void PushTest()
        {
            PushTestHelper<int>();
            PushTestHelperString();
        }

        
        [TestMethod()]
        public void PopStringTest()
        {
            LinkStack<string> target = new LinkStack<string>(); // TODO: 初始化为适当的值

            target.Push("A");

            target.Push("B");

            target.Push("C");

            Assert.AreEqual<string>("C", target.Pop());
            Assert.AreEqual<string>("B", target.Pop());
            Assert.AreEqual<string>("A", target.Pop());

            Assert.AreEqual(0, target.Count);


        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>(); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);

            target.Push(default(T));
            Assert.IsFalse(target.IsEmpty());

        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            IsEmptyTestHelper<string>();
            IsEmptyTestHelper<int>();
        }

        /// <summary>
        ///GetPop 的测试
        ///</summary>
        public void GetPopTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>(); // TODO: 初始化为适当的值
            T expected = default(T); // TODO: 初始化为适当的值
            T actual;

            target.Push(expected);
            actual = target.GetPop();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual<int>(1,target.Count);
          
        }

        [TestMethod()]
        public void GetPopTest()
        {
            GetPopTestHelper<string>();
            GetPopTestHelper<int>();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetLength();
            Assert.AreEqual(expected, actual);

            target.Push(default(T));
            target.Push(default(T));

            Assert.AreEqual<int>(2,target.GetLength());
            
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<string>();
            GetLengthTestHelper<int>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>(); // TODO: 初始化为适当的值

            
            target.Clear();

            Assert.AreEqual(0, target.Count);
            Assert.IsNull(target.Top);
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<int>();
            ClearTestHelper<string>();
        }

        /// <summary>
        ///LinkStack`1 构造函数 的测试
        ///</summary>
        public void LinkStackConstructorTestHelper<T>()
        {
            LinkStack<T> target = new LinkStack<T>();

            Assert.IsNotNull(target);

            Assert.IsNull(target.Top);

            Assert.AreEqual(0, target.Count);
        }

        [TestMethod()]
        public void LinkStackConstructorTest()
        {
            LinkStackConstructorTestHelper<int>();
            LinkStackConstructorTestHelper<string>();
        }
    }
}

using DataStructureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 SequenceQueueTest 的测试类，旨在
    ///包含所有 SequenceQueueTest 单元测试
    ///</summary>
    [TestClass()]
    public class SequenceQueueTest
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
        ///Out 的测试
        ///</summary>
        public void OutTestHelperString()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceQueue<string> target = new SequenceQueue<string>(size); // TODO: 初始化为适当的值

            for (int i = 0; i < size;i++ )
            {
                target.In(i.ToString());
            }

            for (int i = 0; i < size;i++ )
            {
               Assert .AreEqual(i.ToString(),  target.Out());
            }

            try
            {
                target.Out();
            }
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex,typeof(DataStructureException));
            }
        }

        [TestMethod()]
        public void OutTest()
        {
            OutTestHelperString();
        }

        /// <summary>
        ///IsFull 的测试
        ///</summary>
        public void IsFullTestHelper<T>()
        {
            int size = 3; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值
            Assert.IsFalse(target.IsFull());

            target.In(default(T));
            Assert.IsFalse(target.IsFull());

            target.In(default(T));
            Assert.IsFalse(target.IsFull());

            target.In(default(T));
            Assert.IsTrue(target.IsFull());

           
          
        }

        [TestMethod()]
        public void IsFullTest()
        {
            IsFullTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SequenceQueue`1 构造函数 的测试
        ///</summary>
        public void SequenceQueueConstructorTestHelper<T>()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size);

            Assert.AreEqual(-1, target.Front);
            Assert.AreEqual(-1, target.Rear);
            
        }

        [TestMethod()]
        public void SequenceQueueConstructorTest()
        {
            SequenceQueueConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            int size = 10;// TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值

            target.In(default(T));
            target.In(default (T));

            Assert.AreEqual(-1,target.Front );
            Assert.AreEqual(1,target.Rear);
            target.Clear();

            Assert.AreEqual(-1, target.Front);
            Assert.AreEqual(-1, target.Rear);
        
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetFront 的测试
        ///</summary>
        public void GetFrontTestHelper<T>()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值
            T expected = default(T); // TODO: 初始化为适当的值
            T actual=default(T);
            target.In(default(T));
            actual = target.GetFront();
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void GetFrontTest()
        {
            GetFrontTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值
            int expected = 2; // TODO: 初始化为适当的值
            int actual;

            target.In(default(T));
            target.In(default(T));
            actual = target.GetLength();
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///In 的测试
        ///</summary>
        public void InTestHelper<T>()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值
            T item = default(T); // TODO: 初始化为适当的值
            target.In(item);
           
        }

        /// <summary>
        ///In 的测试
        ///</summary>
        public void InTestHelperString()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceQueue<string> target = new SequenceQueue<string>(size); // TODO: 初始化为适当的值

            for (int i = 0; i < 5;i++ )
            {
                target.In(i.ToString());

                Assert.AreEqual(i,target.Rear);
            }

            Assert.AreEqual(-1, target.Front);
        }


        [TestMethod()]
        public void InTest()
        {
            InTestHelper<GenericParameterHelper>();
            InTestHelperString();
        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            int size = 2; // TODO: 初始化为适当的值
            SequenceQueue<T> target = new SequenceQueue<T>(size); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);

            target.In(default(T));

            Assert.AreEqual(false, target.IsEmpty());
            
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            IsEmptyTestHelper<GenericParameterHelper>();
        }
    }
}

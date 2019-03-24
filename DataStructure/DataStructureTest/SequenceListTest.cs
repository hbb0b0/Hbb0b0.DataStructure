using DataStructureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace ApplicationTestProject
{
    
    
    /// <summary>
    ///这是 SequenceListTest 的测试类，旨在
    ///包含所有 SequenceListTest 单元测试
    ///</summary>
    [TestClass()]
    public class SequenceListTest
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
        ///MaxSize 的测试
        ///</summary>
        public void MaxSizeTestHelper<T>()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            int expected = 5; // TODO: 初始化为适当的值
            int actual;
            
            actual = target.MaxSize;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void MaxSizeTest()
        {
            MaxSizeTestHelper<GenericParameterHelper>();
          
        }

        /// <summary>
        ///Last 的测试
        ///</summary>
        public void LastTestHelper<T>()
        {
            int size = 0; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            int expected = -1; // TODO: 初始化为适当的值
            int actual;
        
            actual = target.Last;
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///Last 的测试
        ///</summary>
        public void LastTestHelperString()
        {
            int size = 3; // TODO: 初始化为适当的值
            SequenceList<string> target = new SequenceList<string>(size); // TODO: 初始化为适当的值
            int expected = -1; // TODO: 初始化为适当的值
            int actual;
         
            actual = target.Last;
            Assert.AreEqual(expected, actual);

            target.Append("a");
            Assert.AreEqual(0,target.Last);

            target.Append("b");
            Assert.AreEqual(1, target.Last);


        }

        [TestMethod()]
        public void LastTest()
        {
            LastTestHelper<GenericParameterHelper>();
            LastTestHelperString();
        }

       
        /// <summary>
        ///Data 的测试
        ///</summary>
        public void DataTestHelper<T>()
        {
            int size = 2; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            T[] expected = new T[2]; // TODO: 初始化为适当的值
            T[] actual;
           
            actual = target.Data;
            Assert.AreEqual(expected.Length, actual.Length);
           
        }

        [TestMethod()]
        public void DataTest()
        {
            DataTestHelper<GenericParameterHelper>();
            
        }

        /// <summary>
        ///Locate 的测试
        ///</summary>
        public void LocateTestHelper<T>()
        {
            int size = 0; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            T node = default(T); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;

            try
            {
                actual = target.Locate(node);
            }
            catch(Exception myEx)
            {
                Assert.IsInstanceOfType(myEx, typeof(DataStructureException ));
            }
            
        }

        /// <summary>
        ///Locate 的测试
        ///</summary>
        public void LocateTestHelperString()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceList<string> target = new SequenceList<string >(size); // TODO: 初始化为适当的值

            string str1="AAA";
            string str2 = "aaa";

            target.Append(str1);
            target.Append(str2);
            target.Append(str2);

           

            Assert.AreEqual(0,target.Locate(str1));
            Assert.AreEqual(1, target.Locate(str2));

            Assert.AreEqual(1,target.Locate("aaa"));

            Assert.AreEqual(-1, target.Locate("a"));
        }

        [TestMethod()]
        public void LocateTest()
        {
            LocateTestHelper<GenericParameterHelper>();
            LocateTestHelperString();
        }

        /// <summary>
        ///IsFull 的测试
        ///</summary>
        public void IsFullTestHelper<T>()
        {
            int size = 0; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            bool expected = true ; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsFull();
            Assert.AreEqual(expected, actual);

           
            
            
        }
        public void IsFullTestHelperInt()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceList<int> target = new SequenceList<int>(size); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsFull();
            Assert.AreEqual(expected, actual);

            for (int i = 0; i < size;i++ )
            {
                target.Append(i);
            }

            Assert.IsTrue(target.IsFull());

        }

        [TestMethod()]
        public void IsFullTest()
        {
            IsFullTestHelper<GenericParameterHelper>();
            IsFullTestHelperInt();
        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        public void IsEmptyTestHelper<T>()
        {
            int size = 1; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty();
            Assert.AreEqual(expected, actual);

            target.Append(default(T));

            Assert.AreEqual(false, target.IsEmpty());

            
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            IsEmptyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///InsertAfter 的测试
        ///</summary>
        public void InsertTestHelperString()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceList<string> target = new SequenceList<string>(size); // TODO: 初始化为适当的值

            try
            {
                target.Insert("A", -1);
            }
            catch(Exception myEx)
            {
                Assert.IsInstanceOfType(myEx, typeof(DataStructureException));
            }

            try
            {
                target.Insert("A", 10);
            }
            catch (Exception myEx)
            {
                Assert.IsInstanceOfType(myEx, typeof(DataStructureException));
            }

            target.Append("a");
            target.Append("d");
            target.Append("f");

            target.Insert("b", 0);
            target.Insert("c", 1);
            target.Insert("x", 4);

            List<string> list = new List<string>() {"b","c","a","d","x","f" };

            for (int i = 0; i < list.Count ; i++)
            {
                Assert.AreEqual(list[i], target[i]);
            }

           
        }

        [TestMethod()]
        public void InsertTest()
        {
            InsertTestHelperString();
        }

        /// <summary>
        ///GetLength 的测试
        ///</summary>
        public void GetLengthTestHelper<T>()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetLength();
            Assert.AreEqual(expected, actual);

            target.Append(default(T));
            Assert.AreEqual(1, target.GetLength());

            target.Append(default(T));
            Assert.AreEqual(2, target.GetLength());

        }

        [TestMethod()]
        public void GetLengthTest()
        {
            GetLengthTestHelper<GenericParameterHelper>();
        }

        
        /// <summary>
        ///GetElement 的测试
        ///</summary>
        public void GetElementTestHelperString()
        {
            int size = 4; // TODO: 初始化为适当的值
            SequenceList<string> target = new SequenceList<string>(size); // TODO: 初始化为适当的值

            List<string> mylist = new List<string>() { "1", "2", "3", "4" };

            foreach (string item in mylist)
            {
                target.Append(item);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(mylist[i], target.GetElement(i));
            }

            Assert.IsNull(target.GetElement(10));
            Assert.IsNull(target.GetElement(-100));

        }

        [TestMethod()]
        public void GetElementTest()
        {
            GetElementTestHelperString();
        }

        /// <summary>
        ///Delete 的测试
        ///</summary>
        public void DeleteTestHelperString()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceList<String > target = new SequenceList<string >(size); // TODO: 初始化为适当的值

            List<string> list = new List<string>() { "0","1","2","3","4","5"};

            foreach (var item in list)
            {
                target.Append(item);
            }

            target.Delete(0);

            target.Delete(2);

            target.Delete(3);

            Assert.AreEqual(3, target.GetLength());
            Assert.AreEqual("1", target[0]);
            Assert.AreEqual("2", target[1]);
            Assert.AreEqual("4", target[2]);
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeleteTestHelperString();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<T>()
        {
            int size = 10; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            

            target.Append(default(T));

            target.Clear();

            Assert.AreEqual(-1, target.Last);

            Assert.AreEqual(0, target.GetLength());

            //Assert.IsNull(target.Data);
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
            int size = 0; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size); // TODO: 初始化为适当的值
            T node = default(T); // TODO: 初始化为适当的值

            try
            {
                target.Append(node);
            }
            catch(Exception  ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DataStructureException));
            }

        }

        public void AppendTestHelperString()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceList<string > target = new SequenceList<string >(size); // TODO: 初始化为适当的值
            
            List<string> myList = new List<string>() { "a","b","c","d"};

           

            foreach(string item in myList)
            {
                target.Append(item);
            }

            Assert.AreEqual (myList.Count, target.GetLength());

            for(int i=0;i<myList.Count;i++)
            {
                Assert.AreEqual(myList[i], target[i]);
            }

        }

        [TestMethod()]
        public void AppendTest()
        {
            AppendTestHelper<GenericParameterHelper>();
            AppendTestHelperString();
        }

        /// <summary>
        ///SequenceList`1 构造函数 的测试
        ///</summary>
        public void SequenceListConstructorTestHelper<T>()
        {
            int size = 5; // TODO: 初始化为适当的值
            SequenceList<T> target = new SequenceList<T>(size);
            //Assert.Inconclusive("TODO: 实现用来验证目标的代码");
            Assert.AreEqual(-1, target.Last);
        }

        [TestMethod()]
        public void SequenceListConstructorTest()
        {
            //SequenceListConstructorTestHelper<GenericParameterHelper>();
            SequenceListConstructorTestHelper<int>();
        }
    }
}

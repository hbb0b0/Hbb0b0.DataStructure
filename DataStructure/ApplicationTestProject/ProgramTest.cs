using LinkStackApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ApplicationTestProject
{
    
    
    /// <summary>
    ///这是 ProgramTest 的测试类，旨在
    ///包含所有 ProgramTest 单元测试
    ///</summary>
    [TestClass()]
    public class ProgramTest
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
        ///ConvertTo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LinkStackApplication.exe")]
        public void ConvertToTest()
        {
            long number = 0; // TODO: 初始化为适当的值
            Program_Accessor.ConvertTo(number);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///MachBracket 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LinkStackApplication.exe")]
        public void MachBracketTest()
        {
            char[] list = new char[]{'[',']','{'}; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Program_Accessor.MachBracket(list);
            Assert.AreEqual(expected, actual);

            list = new char []{'{','[','(',')',']','}' };
            expected = true ;
            actual = Program_Accessor.MachBracket(list);
            Assert.AreEqual(expected, actual);

            list = new char[] { '{', '{', '(', ')', ']', '}' };
            expected = false ;
            actual = Program_Accessor.MachBracket(list);
            Assert.AreEqual(expected, actual);

            list = new char[] { '}', '{', '(', ')', ']', '}' };
            expected = false;
            actual = Program_Accessor.MachBracket(list);
            Assert.AreEqual(expected, actual);


            
        }
    }
}

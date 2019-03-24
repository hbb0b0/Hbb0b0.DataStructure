using DataStructureLib.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 BinaryTreeTest 的测试类，旨在
    ///包含所有 BinaryTreeTest 单元测试
    ///</summary>
    [TestClass()]
    public class BinaryTreeTest
    {


        private TestContext testContextInstance;

        private static BinaryTree<string> binaryTree;

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
                  /*
            
                          A
             *           /  \
             *           B   C
             *          /\   /
             *          D E F
             *             / 
             *            G
                         
            */

            binaryTree = new BinaryTree<string>("A");

            //A node
            Node<string> currentNode = binaryTree.GetRoot();

            binaryTree.InsertLeftChild("B", currentNode);

            //B node
            currentNode = currentNode.LeftChild;

            //insert D
            binaryTree.InsertLeftChild("D", currentNode);

            //insert E
            binaryTree.InsertRightChild("E", currentNode);

            //A 
            currentNode = binaryTree.GetRoot();

            //insert C
            binaryTree.InsertRightChild("C", currentNode);

            //C
            currentNode = binaryTree.GetRightChild(currentNode);

            //Insert F
            binaryTree.InsertLeftChild("F", currentNode);

            //F
            currentNode= binaryTree.GetLeftChild (currentNode);

            //insert G

            binaryTree.InsertLeftChild("G", currentNode);
        }
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
        ///GetHeight 的测试
        ///</summary>
        public void GetHeightTestHelperString()
        {
            Assert.AreEqual(4, binaryTree.GetHeight(binaryTree.GetRoot()));
        }

        [TestMethod()]
        public void GetHeightTest()
        {
            GetHeightTestHelperString();
        }

        /// <summary>
        ///CountLeafNode 的测试
        ///</summary>
        public void CountLeafNodeTestHelperString()
        {
            Assert.AreEqual(3, binaryTree.CountLeafNode(binaryTree.GetRoot()));
        }

        [TestMethod()]
        public void CountLeafNodeTest()
        {
            CountLeafNodeTestHelperString();
        }

        [TestMethod ]
        public void SearchTestHelperString()
        {

           Node<string> node = null;
           binaryTree.Search(binaryTree.GetRoot(), "F",ref node );

           Assert.IsNotNull(node);

           Assert.AreEqual("F",node.Data);
        }

       
    }
}

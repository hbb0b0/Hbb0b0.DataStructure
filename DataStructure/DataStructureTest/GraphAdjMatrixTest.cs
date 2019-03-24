using DataStructureLib.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 GraphAdjMatrixTest 的测试类，旨在
    ///包含所有 GraphAdjMatrixTest 单元测试
    ///</summary>
    [TestClass()]
    public class GraphAdjMatrixTest
    {


        private TestContext testContextInstance;

        private GraphAdjMatrix<string > graphAdjMatrix = null;

        Node<string> v1=null;
        Node<string> v2 =null;
        Node<string> v3 =null;
        Node<string> v4=null;
        Node<string> v5 = null;

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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //设置这样的图
            /*
             *       v1-----v2
             *       |     /  |
             *       |    v4  |
             *       |   /  \ |
             *       |  /    \|   
             *       v3/      v5
             * 
             */

            graphAdjMatrix = new GraphAdjMatrix<string>(5);

            //设置节点
            v1 = new Node<string>("v1");
            v2 = new Node<string>("v2");
            v3 = new Node<string>("v3");
            v4 = new Node<string>("v4");
            v5 = new Node<string>("v5");

            graphAdjMatrix.SetNode(0, v1);
            graphAdjMatrix.SetNode(1, v2);
            graphAdjMatrix.SetNode(2, v3);
            graphAdjMatrix.SetNode(3, v4);
            graphAdjMatrix.SetNode(4, v5);

            //设置边
            graphAdjMatrix.AddEdge(v1, v2, 1);
            graphAdjMatrix.AddEdge(v1, v3, 1);

            graphAdjMatrix.AddEdge(v2, v4, 1);
            graphAdjMatrix.AddEdge(v2, v5, 1);


            graphAdjMatrix.AddEdge(v1, v2, 1);
            graphAdjMatrix.AddEdge(v1, v3, 1);


            graphAdjMatrix.AddEdge(v3, v4, 1);
            graphAdjMatrix.AddEdge(v4, v5, 1);

        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


       
        /// <summary>
        ///SetNode 的测试
        ///</summary>
        public void SetNodeTestHelper<T>()
        {
            int n = 3; // TODO: 初始化为适当的值
            GraphAdjMatrix<T> target = new GraphAdjMatrix<T>(n); // TODO: 初始化为适当的值
            int index = 0; // TODO: 初始化为适当的值
            Node<T> node = null; // TODO: 初始化为适当的值
            target.SetNode(index, node);

            Assert.IsNull(target.GetNode(0));

            
           
        }

        [TestMethod()]
        public void SetNodeTest()
        {
            SetNodeTestHelper<GenericParameterHelper>();
        }

        

        [TestMethod()]
        public void SetMatrixTest()
        {
            

            graphAdjMatrix.SetMatrix(0, 1, 1000);

            Assert.AreEqual(1000, graphAdjMatrix.GetMatrix(0, 1));


        }

        

       
        [TestMethod()]
        public void IsNodeTest()
        {
            Assert.IsFalse( graphAdjMatrix.IsNode(new Node<string>("")));
            Assert.IsTrue(graphAdjMatrix.IsNode(v1));
        }

      

        [TestMethod()]
        public void IsEdgeTest()
        {
           Assert.IsTrue (  graphAdjMatrix.IsEdge(v1, v2));

           Assert.IsFalse(graphAdjMatrix.IsEdge(v1, v5));
        }

        

        [TestMethod()]
        public void GetNumOfVertexTest()
        {
            Assert.AreEqual(5, graphAdjMatrix.GetNumOfVertex());
        }

        

        [TestMethod()]
        public void GetNumOfEdgeTest()
        {
            Assert.AreEqual(6, graphAdjMatrix.GetNumOfEdge());
        }

       
        [TestMethod()]
        public void GetNodeTest()
        {
            for (int i = 0; i <5;i++)
            {
                string data = string.Format("v{0}", (i+1).ToString());

                Assert.AreEqual(data,graphAdjMatrix.GetNode(i).Data);
            }
        }

       

        [TestMethod()]
        public void GetMatrixTest()
        {
           int [,] resultMatrix=new int[5,5]{
           {0,1,1,0,0},

           {1,0,0,1,1},

           {1,0,0,1,0},

           {0,1,1,0,1},

           {0,1,0,1,0},
           }; 
           int n=5;
           for (int i = 0; i < n;i++ )
           {
               for (int j = 0; j < n; j++)
               {
                   Assert.AreEqual(resultMatrix[i,j], graphAdjMatrix.GetMatrix(i, j));
                   
               }
           }
        }

       

        [TestMethod()]
        public void GetIndexTest()
        {

            Assert.AreEqual(0, graphAdjMatrix.GetNodeIndex(v1));
            Assert.AreEqual(1, graphAdjMatrix.GetNodeIndex(v2));
            Assert.AreEqual(2, graphAdjMatrix.GetNodeIndex(v3));
            Assert.AreEqual(3, graphAdjMatrix.GetNodeIndex(v4));
            Assert.AreEqual(4, graphAdjMatrix.GetNodeIndex(v5));

            Assert.AreEqual(-1,graphAdjMatrix.GetNodeIndex(new Node<string>("")));
        }

        

        [TestMethod()]
        public void DeleteEdgeTest()
        {
            graphAdjMatrix.DeleteEdge(v1, v4);
            graphAdjMatrix.DeleteEdge(v1, v4);
            Assert.AreEqual(6, graphAdjMatrix.GetNumOfEdge());
            int[,] resultMatrix = new int[5, 5]{
           {0,1,1,0,0},

           {1,0,0,1,1},

           {1,0,0,1,0},

           {0,1,1,0,1},

           {0,1,0,1,0},
           };
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Assert.AreEqual(resultMatrix[i, j], graphAdjMatrix.GetMatrix(i, j));

                }
            }

            //delete v1,v2
            graphAdjMatrix.DeleteEdge(v1, v2);
            resultMatrix = new int[5, 5]{
           {0,0,1,0,0},

           {0,0,0,1,1},

           {1,0,0,1,0},

           {0,1,1,0,1},

           {0,1,0,1,0},
           };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Assert.AreEqual(resultMatrix[i, j], graphAdjMatrix.GetMatrix(i, j));

                }
            }

            Assert.AreEqual(5, graphAdjMatrix.GetNumOfEdge());
        }

       

        [TestMethod()]
        public void AddEdgeTest()
        {
            //重复连边
            graphAdjMatrix.AddEdge(v1, v2, 1);

            graphAdjMatrix.AddEdge(v1, v2, 1);



            Assert.AreEqual(6, graphAdjMatrix.GetNumOfEdge());

            int[,] resultMatrix = new int[5, 5]{
           {0,1,1,0,0},

           {1,0,0,1,1},

           {1,0,0,1,0},

           {0,1,1,0,1},

           {0,1,0,1,0},
           };
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Assert.AreEqual(resultMatrix[i, j], graphAdjMatrix.GetMatrix(i, j));

                }
            }

            //新连接边(v1,v4)
            graphAdjMatrix.AddEdge(v1, v4, 1);

            Assert.AreEqual(7, graphAdjMatrix.GetNumOfEdge());
            Assert.AreEqual(5, graphAdjMatrix.GetNumOfVertex ());

           resultMatrix = new int[5, 5]{
           {0,1,1,1,0},

           {1,0,0,1,1},

           {1,0,0,1,0},

           {1,1,1,0,1},

           {0,1,0,1,0},
           };
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Assert.AreEqual(resultMatrix[i, j], graphAdjMatrix.GetMatrix(i, j));

                }
            }

        }

        /// <summary>
        ///GraphAdjMatrix`1 构造函数 的测试
        ///</summary>
        public void GraphAdjMatrixConstructorTestHelper<T>()
        {
            int n = 5; // TODO: 初始化为适当的值
            GraphAdjMatrix<T> target = new GraphAdjMatrix<T>(n);

            Assert.AreEqual(target.GetNumOfEdge(), 0);

        }

        [TestMethod()]
        public void GraphAdjMatrixConstructorTest()
        {
            GraphAdjMatrixConstructorTestHelper<GenericParameterHelper>();
        }
    }
}

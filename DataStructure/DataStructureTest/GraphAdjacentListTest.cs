using DataStructureLib.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace DataStructureTest
{
    
    
    /// <summary>
    ///这是 GraphAdjacentListTest 的测试类，旨在
    ///包含所有 GraphAdjacentListTest 单元测试
    ///</summary>
    [TestClass()]
    public class GraphAdjacentListTest
    {


        private TestContext testContextInstance;

        private GraphAdjacentList<string> graph;

        Node<string> v1 = null;
        Node<string> v2 = null;
        Node<string> v3 = null;
        Node<string> v4 = null;
        Node<string> v5 = null;

        Node<string>[] nodes = null;

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
             *       v3/     v5
             * 
             */
            
            nodes=new Node<string>[5];

            //设置节点
            v1 = new Node<string>("v1");
            v2 = new Node<string>("v2");
            v3 = new Node<string>("v3");
            v4 = new Node<string>("v4");
            v5 = new Node<string>("v5");

            nodes[0]=v1;
            nodes[1]=v2;
            nodes[2]=v3;
            nodes[3]=v4;
            nodes[4]=v5 ;


           graph =new  GraphAdjacentList<string>(nodes);

           
            //设置边
            graph.AddEdge(v1, v2, 1);
            graph.AddEdge(v1, v3, 1);

            graph.AddEdge(v2, v4, 1);
            graph.AddEdge(v2, v5, 1);


            graph.AddEdge(v3, v4, 1);
            graph.AddEdge(v4, v5, 1);
          
           
            
        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


      
        [TestMethod()]
        public void ItemTest()
        {
            for (int i = 0; i < graph.VertexNodeList.Length;i++ )
            {
                VertexNode<string> current = graph[i];

                Assert.AreEqual(nodes[i], current.Data);

                
            }
        }

        
        [TestMethod()]
        public void IsNodeTest()
        {
            Assert.IsFalse( graph.IsNode(new Node<string>("ddd")));
            for (int i = 0; i < graph.VertexNodeList.Length; i++)
            {
                Assert.IsTrue(graph.IsNode(nodes[i]));
            }
        }

        

        [TestMethod()]
        public void IsEdgeTest()
        {
            /*
              *       v1-----v2
              *       |     /  |
              *       |    v4  |
              *       |   /  \ |
              *       |  /    \|   
              *       v3/     v5
              * 
              */
           Assert.IsTrue ( graph.IsEdge(v1, v2));
           Assert.IsTrue ( graph.IsEdge(v1, v3));

           Assert.IsTrue(graph.IsEdge(v2, v4));
           Assert.IsTrue(graph.IsEdge(v2, v5));

           Assert.IsTrue(graph.IsEdge(v3, v4));
           Assert.IsFalse(graph.IsEdge(v3, v5));

           Assert.IsTrue(graph.IsEdge(v4, v5));


        }

        
        [TestMethod()]
        public void GetNumOfVertexTest()
        {
            Assert.AreEqual(5,graph.GetNumOfVertex());
        }

        

        [TestMethod()]
        public void GetNumOfEdgeTest()
        {
            Assert.AreEqual(6, graph.GetNumOfEdge());
        }

        
        [TestMethod()]
        public void GetNodeIndexTest()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                Assert.AreEqual(i, graph.GetNodeIndex(nodes[i]));
            }
        }

      

        [TestMethod()]
        public void DeleteEdgeTest()
        {
            /*
             *      A-----B\
             *      |\     E
             *      | \   /
             *      C-  D/
             */

            Node<string> a = new Node<string>("A");
            Node<string> b = new Node<string>("B");
            Node<string> c = new Node<string>("C");
            Node<string> d = new Node<string>("D");
            Node<string> e = new Node<string>("E");

            Node<string>[] myNodes = new Node<string>[]{
            
                a,b,c,d,e

            };
            GraphAdjacentList<string> gh = new GraphAdjacentList<string>(myNodes);

            gh.AddEdge(a, b, 1);
            gh.AddEdge(a, b, 1);

            gh.AddEdge(b, e, 1);
            gh.AddEdge(e, d, 1);
            gh.AddEdge(d, c, 1);
            gh.AddEdge(c, a, 1);
            gh.AddEdge(a, d, 1);

            Assert.AreEqual(6, gh.GetNumOfEdge());


            gh.DeleteEdge(a, e);
            Assert.AreEqual(6, gh.GetNumOfEdge());

            gh.DeleteEdge(a, b);
            Assert.AreEqual(5, gh.GetNumOfEdge());

            gh.DeleteEdge(b, e);
            Assert.AreEqual(4, gh.GetNumOfEdge());


            gh.DeleteEdge(e, d);
            Assert.AreEqual(3, gh.GetNumOfEdge());


            gh.DeleteEdge(d, c);
            Assert.AreEqual(2, gh.GetNumOfEdge());

            gh.DeleteEdge(c, a);
            Assert.AreEqual(1, gh.GetNumOfEdge());

            gh.DeleteEdge(a, d);
            Assert.AreEqual(0, gh.GetNumOfEdge());


            


        }

       

        [TestMethod()]
        public void AddEdgeTest()
        {
            /*
             *      A-----B\
             *      |\     E
             *      | \   /
             *      C-  D/
             */

            Node<string> a=  new Node<string>("A");
            Node<string> b=  new Node<string>("B");
            Node<string> c=  new Node<string>("C");
            Node<string> d=  new Node<string>("D");
            Node<string> e=  new Node<string>("E");
               
            Node<string>[] myNodes=new Node<string>[]{
            
                a,b,c,d,e

            };
            GraphAdjacentList<string> gh = new GraphAdjacentList<string>(myNodes );

            gh.AddEdge(a, b,1);
            gh.AddEdge(a, b, 1);

            gh.AddEdge(b, e, 1);
            gh.AddEdge(e, d, 1);
            gh.AddEdge(d, c, 1);
            gh.AddEdge(c, a, 1);
            gh.AddEdge(a, d, 1);

            AdjacentListNode  p=gh[0].FirstAdjacentListNode; 
            Assert.IsNotNull(p);
            Assert.AreEqual(1, p.AdjacentVertexNodeIndex );
            p = p.Next;
            Assert.IsNotNull(p);
            Assert.AreEqual(2, p.AdjacentVertexNodeIndex);

            p = p.Next;
            Assert.IsNotNull(p);
            Assert.AreEqual(3, p.AdjacentVertexNodeIndex);


        }

        
        
        

        [TestMethod()]
        public void DeepFirstSearchAllTest()
        {
            //设置这样的图
            /*
             *       v1-----v2
             *       |     /  |
             *       |    v4  |
             *       |   /  \ |
             *       |  /    \|   
             *       v3/     v5
             * 
             */

            graph.DeepFirstSearchAll();

            List<string> path = new List<string>();
            path.Add("v1,v2,v4,v3,v5");

            Assert.IsNotNull(graph.Path);

            Assert.AreEqual(path.Count, graph.Path.Count);

            Assert.AreEqual(path[0], graph.Path[0]);

        }

       
        [TestMethod()]
        public void BreadthFirstSearchAllTest()
        {
            /*
             *             v1
             *            /\
             *           v2 v3 
             *          /\    /\  
             *         v4 v5 v6-v7
             *         \  /
             *         v8    
             * 
             * 
             */

            Node<string> v1 = new Node<string>("v1");
            Node<string> v2 = new Node<string>("v2");
            Node<string> v3 = new Node<string>("v3");
            Node<string> v4 = new Node<string>("v4");
            Node<string> v5 = new Node<string>("v5");
            Node<string> v6 = new Node<string>("v6");
            Node<string> v7 = new Node<string>("v7");
            Node<string> v8 = new Node<string>("v8");

            Node<string>[] myNodes = new Node<string>[]{
            
                v1,v2,v3,v4,v5,v6,v7,v8

            };
            GraphAdjacentList<string> gh = new GraphAdjacentList<string>(myNodes);

            gh.AddEdge(v1, v2, 1);

            gh.AddEdge(v2, v4, 1);
            gh.AddEdge(v2, v5, 1);

            gh.AddEdge(v4, v8, 1);

            gh.AddEdge(v5, v8, 1);

            gh.AddEdge(v1, v3, 1);
            gh.AddEdge(v3, v6, 1);
            gh.AddEdge(v3, v7, 1);
            gh.AddEdge(v6, v7, 1);


            gh.BreadthFirstSearchAll();

            List<string> path = new List<string>();
            path.Add("v1,v2,v3,v4,v5,v6,v7,v8");

            Assert.IsNotNull(gh.Path);

            Assert.AreEqual(path.Count, gh.Path.Count);

            Assert.AreEqual(path[0], gh.Path[0]);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataStructureLib.BinaryTree
{
   
    /// <summary>
    /// 二叉树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>:IBinaryTree<T>
    {
        /// <summary>
        /// 根节点
        /// </summary>
        private Node<T> head;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        /// <param name="leftChild">左子树</param>
        /// <param name="rightChild">右子树</param>
        public BinaryTree(T data,Node<T> leftChild,Node<T> rightChild)
        {
            head  = new Node<T>(data, leftChild, rightChild);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        public BinaryTree(T data):this(data,null,null)
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BinaryTree()
        {
            head = null;
        }

        #region IBinaryTree<T> 成员

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        public Node<T> GetRoot()
        {
            return head;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(head==null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 当前节点左子树插入值为val的节点
        /// </summary>
        /// <param name="val">插入节点的值</param>
        /// <param name="currentNode">当前节点</param>
        public void InsertLeftChild(T val, Node<T> currentNode)
        {
            //构造新节点
            Node<T> newNode= new Node<T>(val);

            //新节点的左子树为当前节点的左子树
            newNode.LeftChild = currentNode.LeftChild ;

            //插入节点的左子树为构造的新节点
            currentNode.LeftChild = newNode;

        }

        /// <summary>
        /// 当前节点右子树插入值为val的节点
        /// </summary>
        /// <param name="val">插入节点的值</param>
        /// <param name="currentNode">当前节点</param>
        public void InsertRightChild(T val, Node<T> currentNode)
        {
            //构造新节点
            Node<T> newNode = new Node<T>(val);
            //新节点的左子树为当前节点的左子树
            newNode.RightChild  = currentNode.RightChild ;
            //当前节点的左子树为新节点
            currentNode.RightChild  = newNode;
        }

        /// <summary>
        /// 删除左子树
        /// </summary>
        /// <param name="currentNode"></param>
        public void DeleteLeftChild(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                currentNode.LeftChild = null;
            }
        }

        /// <summary>
        /// 删除右子树
        /// </summary>
        /// <param name="currentNode"></param>
        public void DeleteRightChild( Node<T> currentNode)
        {
            if (currentNode != null)
            {
                currentNode.RightChild = null;
            }
        }

        public Node<T> GetLeftChild(Node<T> node)
        {
            return node.LeftChild;
        }

        public Node<T> GetRightChild(Node<T> node)
        {
            return node.RightChild;
        }

        public bool IsLeaf(Node<T> node)
        {
            if(node!=null && node.LeftChild ==null && node.RightChild ==null)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 遍历
        
        /// <summary>
        /// 优先遍历树节点
        /// </summary>
        /// <param name="node">节点</param>
        public void PreOrder(Node<T> node)
        {
            if(node==null )
            {
                return;
            }
            Console.WriteLine("Node Data:{0}", node.Data);

            //遍历左子树
            PreOrder(node.LeftChild);
            //遍历右子树
            PreOrder(node.RightChild);
        }

        /// <summary>
        /// 优先遍历树
        /// </summary>
        public void PreOrder()
        {
            PreOrder(head);
        }



        /// <summary>
        /// 中序遍历树节点
        /// </summary>
        /// <param name="node">节点</param>
        public void InOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
           

            //遍历左子树
            InOrder(node.LeftChild);

            //输出节点数据
            Console.WriteLine("Node Data:{0}", node.Data);

            //遍历右子树
            InOrder(node.RightChild);
        }

        /// <summary>
        /// 中序遍历树
        /// </summary>
        public void InOrder()
        {
            InOrder(head);
        }

        /// <summary>
        /// 后序遍历树节点
        /// </summary>
        /// <param name="node">节点</param>
        public void PostOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }


            //遍历左子树
            PostOrder(node.LeftChild);

            //遍历右子树
            PostOrder(node.RightChild);

            //输出节点数据
            Console.WriteLine("Node Data:{0}", node.Data);
        }

        /// <summary>
        /// 后序遍历树
        /// </summary>
        public void PostOrder()
        {
            PostOrder(head);
            
        }

        /// <summary>
        /// 层序遍历节点
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrder(Node<T> node)
        {
            if(node==null)
            {
                return;
            }

            DataStructureLib.SequenceQueue<Node<T>> queue = new SequenceQueue<Node<T>>(100);

            queue.In(node);

            while (!queue.IsEmpty())
            {
                Node<T> currentNode=queue.Out();

                Console.WriteLine("Node Data ：{0}" ,currentNode.Data);
                if (currentNode.LeftChild != null)
                {
                    queue.In(currentNode.LeftChild);
                }

                if(currentNode.RightChild!=null)
                {
                    queue.In(currentNode.RightChild);
                }
            }

        }

          /// <summary>
        /// 层序遍历树
        /// </summary>
        public void LevelOrder()
        {
            LevelOrder(head);
        }


        #endregion

        /// <summary>
        /// 查找给定节点中值为val的节点
        /// </summary>
        /// <param name="node">给定节点</param>
        /// <param name="val">值</param>
        /// <returns>返回值为val的节点</returns>
        public void Search(Node<T> node, T val,ref Node<T> result)
        {
            if (node == null)
            {
                return ;
            }

            //Debug.WriteLine(node.Data);

            if (node.Data.Equals(val))
            {
                result =node;
            }

            Search(node.LeftChild, val,ref result);
            
            Search(node.RightChild, val,ref result );

            
        }

        /// <summary>
        /// 统计给定节点上叶子节点的数目
        /// </summary>
        /// <param name="node">给定节点</param>
        /// <returns>叶子节点的数目</returns>
        public int CountLeafNode(Node<T> node)
        {
            
            if(node==null )
            {
                return 0;
            }
            else if(node.LeftChild==null && node.RightChild==null)
            {
                return 1;
            }

            else
            {
                return CountLeafNode(node.LeftChild) + CountLeafNode(node.RightChild);
            }
        }

        /// <summary>
        /// 获取给定节点的深度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetHeight(Node<T> node)
        {
            
            int left=0;
            int right=0;
            if(node==null)
            {
                return 0;
            }
            else if(node.LeftChild==null && node.RightChild==null)
            {
                return 1;
            }

            left = GetHeight(node.LeftChild);

            right = GetHeight(node.RightChild);
            
            return (left > right ? left : right)+1;

            
        }
    }
}

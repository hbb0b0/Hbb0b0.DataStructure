using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataStructureLib.BinaryTree;
namespace BinaryTreeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> myBinaryTree = GetBinaryTree();

            //先序遍历
            Console.WriteLine();
            myBinaryTree.PreOrder();

            //中序遍历
            Console.WriteLine();
            myBinaryTree.InOrder();

            //后序遍历
            Console.WriteLine();
            myBinaryTree.PostOrder();

            //层序遍历
            Console.WriteLine();
            myBinaryTree.LevelOrder();
            Console.Read();
        }

        /// <summary>
        /// 获取二叉树
        /// </summary>
        /// <returns></returns>
        static BinaryTree<string> GetBinaryTree()
        {
              /*
                           A
             *           /  \
             *           B   C
             *          /\   /
             *          D E F
             */
            BinaryTree<string> tree = new BinaryTree<string>("A");

            //A node
            Node<string > currentNode = tree.GetRoot();

            tree.InsertLeftChild("B", currentNode);

            //B node
            currentNode = currentNode.LeftChild;

            //insert D
            tree.InsertLeftChild("D", currentNode);

            //insert E
            tree.InsertRightChild("E", currentNode);

            //A 
            currentNode = tree.GetRoot();

            //insert C
            tree.InsertRightChild("C", currentNode);

            //C
            currentNode= tree.GetRightChild(currentNode);

            //Insert F
            tree.InsertLeftChild("F", currentNode);

            return tree;
        }
    }
}

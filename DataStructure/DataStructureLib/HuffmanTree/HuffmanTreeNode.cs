using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 哈夫曼树节点
    /// </summary>
    public class   HuffmanTreeNode
    {
        /// <summary>
        /// 左节点序号
        /// </summary>
        private int leftChild;

        public int LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        /// <summary>
        /// 右节点序号
        /// </summary>
        private int rightChild;

        public int RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        /// <summary>
        /// 本节点序号
        /// </summary>
        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// 权重
        /// </summary>
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public HuffmanTreeNode()
        {
            index = -1;
            leftChild = -1;
            rightChild = -1;
            weight = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="weight"></param>
        public HuffmanTreeNode(int index,int left,int right,int weight)
        {
            this.index = index;
            this.leftChild = left;
            this.rightChild = right;
            this.weight = weight;
        }
    }
}

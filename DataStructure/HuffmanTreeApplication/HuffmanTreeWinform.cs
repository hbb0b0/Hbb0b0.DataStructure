using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataStructureLib;

namespace HuffmanTreeApplication
{
    public partial class HuffmanTreeWinform : Form
    {
        /// <summary>
        /// huffman树
        /// </summary>
        HuffmanTree huffmanTree = null;

        /// <summary>
        /// 权重集合
        /// </summary>
        List<int> weights =null;

        public HuffmanTreeWinform()
        {
            InitializeComponent();
            FillTree();
        }

        
        public void FillTree()
        {
            
            weights = new List<int>(5);

            weights.Clear();
            for (int i = 1; i < 5;i++ )
            {
                weights.Add ( i);
            }
            huffmanTree = new HuffmanTree(weights);

            huffmanTree.Create();

            HuffmanTreeNode huffTreeNode = huffmanTree[huffmanTree.Data.Count - 1];

            TreeNode root = new TreeNode("huffman Tree");

            FillTreeNodes(huffTreeNode, root);

            treeView1.Nodes.Add(root);
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="huffmanNode"></param>
        /// <param name="parentNode"></param>
        void FillTreeNodes(HuffmanTreeNode huffmanNode,TreeNode parentNode)
        {
            TreeNode treeNode = new TreeNode(huffmanNode.Weight.ToString());

            //如果权重值包括在权重列表中，则树节点文本显示为红色
            if (weights.Contains(huffmanNode.Weight))
            {
                treeNode.ForeColor = Color.Red;

            }

            parentNode.Nodes.Add(treeNode);


            if(huffmanNode.LeftChild!=-1)
            {
                HuffmanTreeNode left= huffmanTree[huffmanNode.LeftChild];

                FillTreeNodes(left,treeNode);
            }

            if (huffmanNode.RightChild!= -1)
            {
                HuffmanTreeNode currentNode = huffmanTree[huffmanNode.RightChild ];

                FillTreeNodes(currentNode,treeNode);
            }
        }
    }
}

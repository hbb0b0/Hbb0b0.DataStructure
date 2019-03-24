using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib
{
    /// <summary>
    /// 哈夫曼树
    /// </summary>
    public class HuffmanTree
    {
        /// <summary>
        /// 叶子节点的数据
        /// </summary>
        private int leafNum;

        public int LeafNum
        {
            get { return leafNum; }
            set { leafNum = value; }
        }

        
        /// <summary>
        /// 最终的节点数组
        /// </summary>
        private  List<HuffmanTreeNode> data;

        /// <summary>
        /// 临时节点数组
        /// </summary>
        private List<HuffmanTreeNode> tmpData;

        public HuffmanTreeNode this[int index]
        {
            get
            {
                return data[index ];
            }
        }

        public List<HuffmanTreeNode> Data
        {
            get
            {
                return data;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n"></param>
        public HuffmanTree(List<int> weights)
        {
            //根据权重节点设定数组大小
            data = new List<HuffmanTreeNode>(2 * weights.Count- 1);
            tmpData = new List<HuffmanTreeNode>(2 * weights.Count - 1);

            //排列权重
            weights = weights.OrderBy(p => p).ToList();
            //按权重初始化哈夫曼数组
            for (int i = 0; i < weights.Count;i++ )
            {
                HuffmanTreeNode tmp = new HuffmanTreeNode();
                tmp.Weight=weights[i];
                tmp.Index = i;

                tmpData.Add( tmp);
                data.Add ( tmp);
            }
            
            //设置叶子节点的数目
            leafNum = weights.Count ;
        }

        public void Show()
        {
            int currentIndex = 0;
           foreach (HuffmanTreeNode current in data)
           {

               string text = string.Format("Index:{0}  Weight:{1} LeftChild:{2} RightChild:{3}",
                    current .Index ,current.Weight,current.LeftChild,current.RightChild );
               Console.WriteLine(text );

               ++currentIndex;
           }
        }

        /// <summary>
        /// 创建哈夫曼树
        /// </summary>
        public void Create()
        {
            while(tmpData.Count>1)
            {
                //根据权重最小的两节点生成新节点
                HuffmanTreeNode tmp = new HuffmanTreeNode();

                tmp.Weight = tmpData[0].Weight + tmpData[1].Weight;

                tmp.LeftChild = tmpData[0].Index;

                tmp.RightChild = tmpData[1].Index;

                int newIndex = tmpData.Max(p => p.Index) + 1;
                
                tmp.Index =newIndex ;

                //临时数组添加新生成的节点
                tmpData.Add(tmp);

                //结果数据添加新生成的节点
                data.Add(tmp);

                //临时数组移除已处理的节点
                tmpData.RemoveAt(0);
                tmpData.RemoveAt(0);

                //重新排列临时数组
                tmpData = tmpData.OrderBy(p => p.Weight).ToList();

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureLib.BinaryTree
{

    /// <summary>
    /// 二叉树接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBinaryTree<T>
    {

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        Node<T> GetRoot();

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        
        /// <summary>
        /// 当前节点左子树插入值为val的节点
        /// </summary>
        /// <param name="val">插入节点的值</param>
        /// <param name="currentNode">当前节点</param>
        void InsertLeftChild(T val, Node<T> currentNode);

        /// <summary>
        /// 当前节点右子树插入值为val的节点
        /// </summary>
        /// <param name="val">插入节点的值</param>
        /// <param name="currentNode">当前节点</param>
        void InsertRightChild(T val,Node<T> currentNode);

        /// <summary>
        /// 删除指定节点左子树
        /// </summary>
        /// <param name="currentNode"></param>
        void DeleteLeftChild( Node<T> currentNode);

        /// <summary>
        /// 删除指定节点右子树
        /// </summary>
        /// <param name="currentNode"></param>
        void DeleteRightChild(Node<T> currentNode);

        /// <summary>
        /// 获取指定节点左子树
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Node<T> GetLeftChild(Node<T> node);

        /// <summary>
        /// 获取指定节点的右子树
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Node<T> GetRightChild(Node<T> node);

        /// <summary>
        /// 判断指定节点是不是叶子节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool IsLeaf(Node<T> node);
    }
}

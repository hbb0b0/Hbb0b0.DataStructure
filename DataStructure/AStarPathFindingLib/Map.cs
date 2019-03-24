using System;
using System.Collections.Generic;
using System.Text;

namespace AStarPathFindingLib
{
    /// <summary>
    /// 地图
    /// </summary>
    public class Map
    {
        /// <summary>  
        /// 字段：地图长  
        /// </summary>  
        public int LenX;
        /// <summary>  
        /// 字段：地图宽  
        /// </summary>  
        public int LenY;
        /// <summary>  
        /// 字段：用网格节点描述的地图  
        /// </summary>  
        public Grid[,] m_Data;
        /// <summary>  
        /// 构造方法：初始化地图  
        /// </summary>  
        /// <param name="x">地图长</param>  
        /// <param name="y">地图宽</param>  
        public Map(int x, int y)
        {
            LenX = x;
            LenY = y;
            m_Data = new Grid[LenY, LenX];
            for (int i = 0; i < LenY; i++)
                for (int j = 0; j < LenX; j++)
                {
                    m_Data[i, j] = new Grid() { X = j, Y = i };
                }
        }
        private Grid startGrid;
        /// <summary>  
        /// 属性：地图起点  
        /// </summary>  
        public Grid StartGrid
        {
            get { return startGrid; }
            set
            {
                if (value.LandAttribute != 0)
                {
                    startGrid = value;
                    startGrid.GCostAttribute = 0;
                    startGrid.fatherGrid = null;
                    startGrid.PathAttribute = true;
                    m_Data[startGrid.Y, startGrid.X] = startGrid;
                }
                else startGrid = null;
            }
        }
        private Grid endGrid;
        /// <summary>  
        /// 属性：地图终点  
        /// </summary>  
        public Grid EndGrid
        {
            get { return endGrid; }
            set
            {
                endGrid = value;
                endGrid.PathAttribute = true;
                m_Data[endGrid.Y, endGrid.X] = endGrid;
            }
        }
        /// <summary>  
        /// 方法：对所有网格的地形属性进行初始化设置从而生成一张地图  
        /// </summary>  
        /// <param name="grid">当前节点</param>  
        /// <param name="landform">地形选项</param>  
        public void MapGridSet(Grid grid, byte landform)
        {
            if (landform > landtypes) return;
            else grid.LandAttribute = landform;
        }
        /// <summary>  
        /// 字段：地形总数  
        /// </summary>  
        private int landtypes = Enum.GetValues(typeof(LandFormEnum)).Length - 1;


        public override bool Equals(object obj)
        {
            bool result = true;
            Map that = obj as Map;

            if(that==null)
            {
                return false;
            }
            //比较地图大小
            if(this.LenX!=that.LenX || this.LenY!=that.LenY)
            {
                return false;
            }
            //比较地图起始点
            if(this.startGrid.X!=that.startGrid.X || this.startGrid.Y!=that.startGrid.Y)
            {
                return false;
            }
            //比较地图值
            foreach (var item in this.m_Data)
            {
                var thatItem = that.m_Data[ item.X,item.Y];
                if(thatItem==null)
                {
                    return false;
                }
                if(item.LandAttribute!=thatItem.LandAttribute)
                {
                    return false;
                }
            }

            return result;
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

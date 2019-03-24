using AStarPathFindingLib;
using System;

namespace AStarPathFindingLibApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化地图  


            //寻路  
            MapConverter mapConverter = new MapConverter();
            Map excelMap = mapConverter.GetMapFromExcel("data\\APathFind.xlsx", "X20_Y20_01");

            Map sourceMap = GetSourceMap();

           Console.WriteLine( excelMap.Equals(sourceMap));

        }

        static Map GetSourceMap()
        {
            Map mapSample = new Map(20, 20);
            Grid sg = new Grid() { X = 0, Y = 4 };
            mapSample.StartGrid = sg;
            Grid eg = new Grid() { X = 19, Y = 9 };
            mapSample.EndGrid = eg;
            //设置障碍            
            for (int i = 0; i < 17; i++)
            {
                mapSample.MapGridSet(mapSample.m_Data[5,i], 0);
            }
            mapSample.MapGridSet(mapSample.m_Data[ 4,0], 0);
            mapSample.MapGridSet(mapSample.m_Data[ 4,16], 0);

            return mapSample;
        }

        
    }
}

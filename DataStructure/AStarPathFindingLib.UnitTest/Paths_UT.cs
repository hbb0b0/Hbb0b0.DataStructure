using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace AStarPathFindingLib.UnitTest
{

    public class Paths_UT : IDisposable
    {
        private readonly ITestOutputHelper m_Output;
        Map m_basicMap = new Map(20, 20);
        public Paths_UT(ITestOutputHelper output)
        {
            //Trace.Listeners.Add(new TextWriterTraceListener(string.Format($"{DateTime.Now.Ticks}.txt")));
            m_Output = output;

            InitializeTrace();
        }

        private static void InitializeTrace()
        {
            Stream myFile = File.Create(string.Format($"{DateTime.Now.Ticks}.txt"));

            /* Create a new text writer using the output stream, and add it to
             * the trace listeners. */
            TextWriterTraceListener myTextListener = new
               TextWriterTraceListener(myFile);
            Trace.Listeners.Add(myTextListener);
        }


        public void Dispose()
        {
            m_basicMap = null;
        }


      

        public static IEnumerable<object[]> GetMapFromDataGenerator()
        {
            yield return new object[]
            {
               GetMap()

            };


        }
        private static Map GetMap()
        {
            Map map = new Map(20, 20);
            Grid start = new Grid() { X = 0, Y = 4 };
            map.StartGrid = start;
            Grid end = new Grid() { X = 19, Y = 9 };
            map.EndGrid = end;
            //设置障碍            
            for (int i = 0; i < 17; i++)
            {
                map.MapGridSet(map.m_Data[i, 5], 0);
            }
            map.MapGridSet(map.m_Data[0, 4], 0);
            map.MapGridSet(map.m_Data[16, 4], 0);

            return map;
        }

        [Theory]
        [MemberData(nameof(GetMapFromDataGenerator))]
        public void Find_WithMemberData(Map map)
        {
            Paths astarPath = new Paths();
            astarPath.Find(map.StartGrid, map.EndGrid, map);
            //打印地图和路径  
            foreach (Grid g in map.m_Data)
            {
                if (g.X == map.LenY - 1)
                {
                    m_Output.WriteLine(Grid.Print(g));
                    Console.WriteLine(Grid.Print(g));
                    Trace.WriteLine(Grid.Print(g));
                }

                else
                {
                    m_Output.WriteLine(Grid.Print(g));
                    Console.Write(Grid.Print(g));
                    Trace.Write(Grid.Print(g));
                }
            }

            Trace.Flush();

            Assert.NotNull(map);
        }

        [Theory]
        [ClassData(typeof(TestDataProvider))]
        public void Find_WithClassData(Map map)
        {
            Paths astarPath = new Paths();
            astarPath.Find(map.StartGrid, map.EndGrid, map);
            //打印地图和路径  
            foreach (Grid g in map.m_Data)
            {
                if (g.X == map.LenY - 1)
                {
                    m_Output.WriteLine(Grid.Print(g));
                    Console.WriteLine(Grid.Print(g));
                    Trace.WriteLine(Grid.Print(g));
                }

                else
                {
                    m_Output.WriteLine(Grid.Print(g));
                    Console.Write(Grid.Print(g));
                    Trace.Write(Grid.Print(g));
                }
            }

            Trace.Flush();

            Assert.NotNull(map);
        }
    }

    public class TestDataProvider : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {GetMap1()},
        new object[] {GetMap2()}
};
        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static Map GetMap1()
        {
            Map map = new Map(20, 20);
            Grid start = new Grid() { X = 0, Y = 4 };
            map.StartGrid = start;
            Grid end = new Grid() { X = 19, Y = 9 };
            map.EndGrid = end;
            //设置障碍            
            for (int i = 0; i < 17; i++)
            {
                map.MapGridSet(map.m_Data[i, 5], 0);
            }
            map.MapGridSet(map.m_Data[0, 4], 0);
            map.MapGridSet(map.m_Data[16, 4], 0);

            return map;
        }
        private static Map GetMap2()
        {
            Map map = new Map(20, 20);
            Grid start = new Grid() { X = 0, Y = 4 };
            map.StartGrid = start;
            Grid end = new Grid() { X = 19, Y = 9 };
            map.EndGrid = end;
            //设置障碍            
            for (int i = 0; i < 17; i++)
            {
                map.MapGridSet(map.m_Data[i, 5], 0);
            }
            map.MapGridSet(map.m_Data[0, 4], 0);
            map.MapGridSet(map.m_Data[16, 4], 0);

            return map;
        }
    }


}

using MyMathLib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyMathLib.UnitTest
{
    public class SortHelper_UnitTest
    {
        [Fact]
        public void SwapSort()
        {
           Assert.Equal<int[]>(new int[] {0,1,2,2,3,3,5,9 },  SortHelper.SwapSort(new int[] { 2, 1, 3, 9, 5, 3, 2, 0 }));
        }
    }
}

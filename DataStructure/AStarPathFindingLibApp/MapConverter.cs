using AStarPathFindingLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Npoi.Core.SS.UserModel;
using Npoi.Core.XSSF.UserModel;
using Npoi.Core.HSSF.UserModel;

namespace AStarPathFindingLibApp
{
    enum CellColor
    {
        Red=10,
        LIME=52
    }
    class MapConverter
    {
        public  Map GetMapFromExcel(string filePath,string sheetName)
        {
            //DataTable dataTable = null;
            //DataColumn column = null;
            //DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow currentRow = null;
            ICell currentCell = null;
            double currentCellValue = (double)LandFormEnum.Flatground;
            int maxRow = 0;
            int maxColumn = 0;
            Map map = null;
            int cellValue = 0;
            List<short> colorList = new List<short>();
            List<Tuple<int, int, int>> tupleList = new List<Tuple<int, int, int>>();
            try
            {

                Tuple<int?, int?> MaxXY = this.ParseXY(sheetName);
                if(!MaxXY.Item1.HasValue|| !MaxXY.Item2.HasValue)
                {
                    throw new Exception("invalidate sheetName");
                }
                using (FileStream fs = File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheet(sheetName);
                        maxRow = MaxXY.Item2.Value;
                        maxColumn = MaxXY.Item1.Value;
                        for (int currentRowIndex = 0; currentRowIndex < maxRow; currentRowIndex++)
                        {
                            currentRow = sheet.GetRow(currentRowIndex);

                            
                            for (int currentColIndex = 0; currentColIndex < maxColumn; currentColIndex++)
                            {
                                currentCell = currentRow.GetCell(currentColIndex);
                                cellValue = 0;
                                currentCellValue = -1;
                                if (currentCell != null)
                                {
                                    //currentColor = currentCell.CellStyle.FillForegroundColor;
                                    if (currentCell.CellType == CellType.Numeric)
                                    {
                                        currentCellValue = currentCell.NumericCellValue;

                                    }
                                    else if (currentCell.CellType == CellType.String)
                                    {

                                        if (!string.IsNullOrEmpty(currentCell.StringCellValue))
                                        {
                                            double.TryParse(currentCell.StringCellValue, out currentCellValue);

                                        }

                                    }

                                    if (currentCellValue == (int)LandFormEnum.Block)
                                    {
                                        cellValue = (int)LandFormEnum.Block;
                                    }
                                    else if (currentCellValue == (int)LandFormEnum.Start)
                                    {
                                        cellValue = (int)LandFormEnum.Start;
                                    }
                                    else if (currentCellValue == (int)LandFormEnum.End)
                                    {
                                        cellValue = (int)LandFormEnum.End;
                                    }
                                    
                                    if (currentCellValue != -1)
                                    {
                                        tupleList.Add(new Tuple<int, int, int>(currentColIndex, currentRowIndex, cellValue));
                                    }
                                }


                            }
                        }
                    }
                }

                //设置地图大小
                map = new Map(maxRow, maxColumn);

                //Start
                var start = tupleList.FirstOrDefault(p => p.Item3 == (int)LandFormEnum.Start);
                var end= tupleList.FirstOrDefault(p => p.Item3 == (int)LandFormEnum.End);
                if (start != null)
                {
                    Grid gStart = new Grid() { X = start.Item1, Y = start.Item2 };

                    map.StartGrid = gStart;

                    map.MapGridSet(gStart, (int)LandFormEnum.Block);

                }

                if (end != null)
                {
                    Grid gEnd = new Grid() { X = end.Item1,Y=end.Item2 };

                    map.EndGrid = gEnd;

                    map.MapGridSet(gEnd, (int)LandFormEnum.Block);

                }
                var blockList = tupleList.Where(p => p.Item3 == (int)LandFormEnum.Block).ToList();

                foreach(var item in blockList)
                {
                    Grid g = new Grid() { X=item.Item1,Y=item.Item2 };
                    map.MapGridSet(g, (int)LandFormEnum.Block);
                }
                //设置障碍物
                return map;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 解析X，Y
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private Tuple<int?,int?> ParseXY(string sheetName)
        {
            Tuple<int?, int?> tuple = new Tuple<int?, int?>(null,null); ;

            string[] array= sheetName.Split('_');

            if(array==null || array.Length<2)
            {
                throw new  Exception(String.Format($"Invalidate SheetName:{sheetName}"));
            }

            int x = 0;
            int y = 0;
            if(int.TryParse(array[0].ToUpperInvariant().Replace("X",""),out x) && int.TryParse(array[1].ToUpperInvariant().Replace("Y", ""), out y))
            {
                tuple = new Tuple<int?, int?>(x, y);
            }

            return tuple;
        }
    }
}
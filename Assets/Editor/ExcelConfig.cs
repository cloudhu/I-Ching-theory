using Excel;
using System.Data;
using System.IO;
using UnityEngine;

public class ExcelConfig
{
    /// <summary>
    /// 存放excel表文件夹的的路径，本例excel表放在了"Assets/Excel/"当中
    /// </summary>
    public static readonly string excelsFolderPath = Application.dataPath + "/Excel/";

    /// <summary>
    /// 存放Excel转化CS文件的文件夹路径
    /// </summary>
    public static readonly string assetPath = "Assets/Resources/DataAssets/";
}

public class ExcelTool
{

    /// <summary>
    /// 读取表数据，生成对应的数组
    /// </summary>
    /// <param name="filePath">excel文件全路径</param>
    /// <returns>Item数组</returns>
    public static Item[] CreateItemArrayWithExcel(string filePath)
    {
        //获得表数据
        int columnNum = 0, rowNum = 0;
        DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

        //根据excel的定义，第二行开始才是数据
        Item[] array = new Item[rowNum - 1];
        for (int i = 1; i < rowNum; i++)
        {
            Item item = new Item();
            //解析每列的数据
            item.Id = int.Parse(collect[i][0].ToString());
            item.Name = collect[i][1].ToString();
            item.IncludeId = int.Parse(collect[i][2].ToString());
            item.OppositeId= int.Parse(collect[i][3].ToString());
            item.ReverseId= int.Parse(collect[i][4].ToString());
            item.MainId= int.Parse(collect[i][5].ToString());
            item.GuestId= int.Parse(collect[i][6].ToString());
            item.GramId1= int.Parse(collect[i][7].ToString());
            item.GramId2 = int.Parse(collect[i][8].ToString());
            item.GramId3 = int.Parse(collect[i][9].ToString());
            item.GramId4 = int.Parse(collect[i][10].ToString());
            item.GramId5 = int.Parse(collect[i][11].ToString());
            item.GramId6 = int.Parse(collect[i][12].ToString());
            item.GramDes1 = collect[i][13].ToString();
            item.GramDes2 = collect[i][14].ToString();
            item.GramDes3 = collect[i][15].ToString();
            item.GramDes4 = collect[i][16].ToString();
            item.GramDes5 = collect[i][17].ToString();
            item.GramDes6 = collect[i][18].ToString();
            item.Des1 = collect[i][19].ToString();
            item.Des2 = collect[i][20].ToString();
            item.Des3 = collect[i][21].ToString();
            array[i - 1] = item;
        }
        return array;
    }

    /// <summary>
    /// 读取excel文件内容
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="columnNum">行数</param>
    /// <param name="rowNum">列数</param>
    /// <returns></returns>
    static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
    {
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();
        //Tables[0] 下标0表示excel文件中第一张表的数据
        columnNum = result.Tables[0].Columns.Count;
        rowNum = result.Tables[0].Rows.Count;
        return result.Tables[0].Rows;
    }
}

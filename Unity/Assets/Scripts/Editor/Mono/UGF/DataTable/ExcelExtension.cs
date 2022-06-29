//------------------------------------------------------------
// ExcelToTxt
// Copyright Xu wei
//------------------------------------------------------------

using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using UnityEngine;
using UnityEditor;

namespace UGF.Editor.DataTableTools
{
    public static class ExcelExtension
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Z][A-Za-z0-9_]*$");
        private const string DataTableConfigPath = "Configs/Builtin/";
        private const string DataTablePath = "Assets/Res/DataTables/";
        private const int ContentStartRow = 4;
        private const int IdColumn = 1;
        
        /// <summary>
        /// excel转成txt
        /// </summary>
        /// <returns>转换表格的表名</returns>
        public static List<string> ExcelToTxt()
        {
            List<string> excelDataTableNames = new List<string>();
            if (!Directory.Exists(DataTableConfigPath))
            {
                Debug.LogError($"{DataTableConfigPath} is not exist!");
                return excelDataTableNames;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string[] excelFiles = Directory.GetFiles(DataTableConfigPath, "*.xlsx", SearchOption.AllDirectories);
            foreach (var excelFile in excelFiles)
            {
                if (excelFile.Contains("~"))
                    continue;
                ExcelOutputTextFormat excelOutputTextFormat = new ExcelOutputTextFormat();
                excelOutputTextFormat.Encoding = Encoding.UTF8;
                using FileStream fileStream = new FileStream(excelFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using ExcelPackage excelPackage = new ExcelPackage(fileStream);
                for (int s = 0; s < excelPackage.Workbook.Worksheets.Count; s++)
                {
                    var sheet = excelPackage.Workbook.Worksheets[s];
                    if (sheet.Dimension.End.Row < 1)
                        continue;
                    string dataTableName = sheet.Cells[1, IdColumn + 1].ToText(excelOutputTextFormat);
                    if (string.IsNullOrWhiteSpace(dataTableName))
                    {
                        Debug.LogErrorFormat("{0} has not datable name!", dataTableName);
                        continue;
                    }

                    if (!NameRegex.IsMatch(dataTableName))
                    {
                        Debug.LogErrorFormat("{0} has wrong datable name!", dataTableName);
                        continue;
                    }

                    string fileFullPath = $"{DataTablePath}{dataTableName}.txt";
                    if (File.Exists(fileFullPath))
                    {
                        File.Delete(fileFullPath);
                    }

                    List<string> sContents = new List<string>();
                    StringBuilder sb = new StringBuilder();
                    if (sheet.Dimension.End.Row < 3)
                    {
                        Debug.LogErrorFormat("{0} has wrong row num!", fileFullPath);
                        continue;
                    }

                    int columnCount = sheet.Dimension.End.Column;
                    for (int i = 1; i <= sheet.Dimension.End.Row; i++)
                    {
                        if (i > ContentStartRow)
                        {
                            if (sheet.Cells[i, IdColumn + 1].Value == null)
                            {
                                continue;
                            }
                        }
                        sb.Clear();
                        for (int j = 1; j <= columnCount; j++)
                        {
                            if (sheet.Cells[i, j] == null || sheet.Cells[i, j].Value == null)
                            {
                                sb.Append("");
                            }
                            else
                            {
                                string str = sheet.Cells[i, j].Value.ToString();
                                str = str.Replace('\t', ' ');
                                sb.Append(str);
                            }

                            if (j != columnCount)
                            {
                                sb.Append('\t');
                            }
                        }

                        sContents.Add(sb.ToString());
                    }
                    File.WriteAllLines(fileFullPath, sContents, Encoding.UTF8);
                    excelDataTableNames.Add(dataTableName);
                }
            }
            Debug.Log("更新Excel表格完成");
            AssetDatabase.Refresh();
            return excelDataTableNames;
        }
    }
}
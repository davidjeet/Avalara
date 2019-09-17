using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;
using Weather27612.Core.Model;

namespace Weather27612.Core.Excel
{
    /// <summary>
    /// File based implementation of reading Excel file from disk.
    /// </summary>
    public class ExcelFileClient : IExcelClient
    {
        private string _filePath;

        public ExcelFileClient(string filePath)
        {
            _filePath = filePath;
        }

        public List<WeatherData> RetrieveAllFromSheet(int sheetIndex)
        {
            List<WeatherData> weatherDataList = null;
            try
            {                
                using (var stream = File.Open(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // 1. read from excel to a dataset
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        // 2. move data from dataset to a .NET CLR object collection
                        weatherDataList = result.Tables[sheetIndex].MapToWeatherData();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return weatherDataList;
        }

    }
}

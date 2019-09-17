using System;
using System.Collections.Generic;
using System.IO;
using Weather27612.Core.Excel;
using Weather27612.Core.Model;

namespace Weather27612.Core
{
    /// <summary>
    /// Concrete implementation of WeatherEngine.
    /// </summary>
    public class WeatherEngine : IWeatherEngine
    {
        private ExcelFileClient excelClient;
        private Dictionary<int, RainfallResult> rainfallPredictionModel;


        public WeatherEngine()
        {           
            string filePath = Path.Combine(Environment.CurrentDirectory, Constants.ExcelFileName);
            Initialize(filePath);
        }

        public WeatherEngine(string filePath)
        {
            Initialize(filePath);
        }

        public void Initialize(string filePath)
        {
            excelClient = new ExcelFileClient(filePath);
            BuildPredictionModel();
        }

        public RainfallResult GetRainfallPrediction(DateTime date)
        {
            return rainfallPredictionModel[date.Month];
        }

        /// <summary>
        /// Build an in-memory CLR dictionary of month-prediction 
        /// </summary>
        /// <returns>Success of building model</returns>
        public bool BuildPredictionModel()
        {
            bool success = false;
            try
            { 
                IList<WeatherData> weatherData = excelClient.RetrieveAllFromSheet(Constants.ExcelSheetIndex);
                rainfallPredictionModel = new Dictionary<int, RainfallResult>();
                foreach(var weatherDataPoint in weatherData)
                {
                    int month = weatherDataPoint.Month;
                    float prcp = weatherDataPoint.Prcp;
                    if (!rainfallPredictionModel.ContainsKey(month))
                    {
                        rainfallPredictionModel[month] = new RainfallResult();
                    }
                    rainfallPredictionModel[month].PrcpList.Add(prcp);                
                }
                success = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return success;
        }

    }
}

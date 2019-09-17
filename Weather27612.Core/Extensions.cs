using System;
using System.Collections.Generic;
using System.Data;
using Weather27612.Core.Model;

namespace Weather27612.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Converting data from a DataTable to a CLR object.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>WeatherData object.</returns>
        public static List<WeatherData> MapToWeatherData(this DataTable dataTable)
        {
            List<WeatherData> weatherData = new List<WeatherData>();
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    DateTime dateTime = row.Field<DateTime>("DATE");
                    string prcpString = Convert.ToString(row.Field<object>("PRCP"));
                    if (!string.IsNullOrEmpty(prcpString))
                    {
                        weatherData.Add(new WeatherData
                        {
                            Month = dateTime.Month,
                            Prcp = Convert.ToSingle(prcpString)
                        });
                    }                  
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
            }

            return weatherData;
        }
    }
}

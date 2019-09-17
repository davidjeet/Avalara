using System.Collections.Generic;
using Weather27612.Core.Model;

namespace Weather27612.Core
{
    public interface IExcelClient
    {
        List<WeatherData> RetrieveAllFromSheet(int sheetIndex);
    }
}

using System;
using System.IO;

namespace Weather27612.Core
{
    public static class Constants
    {
        public static readonly Uri WeatherDataUri = new Uri(@"https://avalara1-my.sharepoint.com/:x:/g/personal/christina_godwin_avalara_com/EeCVYStUdrdBkOgJPO2OMqEBSzf_kgqiUV8WXOitjeDHgg");

        public const string ExcelSheetName = "In";

        public const int ExcelSheetIndex = 0;

        public const string ExcelFileName = @"27612-precipitation-data.xlsx";

    }
}

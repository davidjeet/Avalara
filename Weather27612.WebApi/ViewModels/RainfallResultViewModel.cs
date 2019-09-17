namespace Weather27612.WebApi.ViewModels
{
    /// <summary>
    /// Simplified return value containing just mean prcp and the standard deviation
    /// </summary>
    public class RainfallResultViewModel
    {
        public float MeanPrcp { get; set; }

        public double StdDev { get; set; }
    }
}

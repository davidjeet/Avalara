using System;
using System.Collections.Generic;
using System.Linq;

namespace Weather27612.Core.Model
{
    public class RainfallResult
    {
        public List<float> PrcpList { get; set; } = new List<float>();

        public int Total => PrcpList.Count;

        public float MeanPrcp => ( PrcpList.Sum() / Total) ;

        public double StdDev => Math.Sqrt(this.Variance());

        public double Variance()
        {
            double variance = 0;
            var start = 0;
            var end = Total;
            var mean = this.MeanPrcp;

            for (int i = start; i < end; i++)
            {
                variance += Math.Pow((PrcpList[i] - mean), 2);
            }

            int n = end - start;
            if (start > 0) n -= 1;

            return variance / (n);
        }
    }
}

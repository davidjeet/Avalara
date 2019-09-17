using System;
using Weather27612.Core.Model;

namespace Weather27612.Core
{
    public interface IWeatherEngine
    {
        void Initialize(string filePath);

        bool BuildPredictionModel();

        RainfallResult GetRainfallPrediction(DateTime date);
    }
}

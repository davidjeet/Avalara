using System.IO;
using NUnit.Framework;
using Weather27612.Core;
using Weather27612.Core.Excel;

namespace Weather27612.Tests
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void BuildPredictionModel_Succeeds()
        {
            //Arrange
            var weatherEngine = MockWeatherEngine;

            //Act
            var success = MockWeatherEngine.BuildPredictionModel();

            //Assert 
            Assert.IsTrue(success);
        }

        [Test]
        public void ExcelFileClient_Fails_RetrieveAllFromSheet_With_Faulty_Excel_Source()
        {
            //Arrange
            var file = Path.GetTempFileName();

            //Act
            IExcelClient client = new ExcelFileClient(file);

            //Assert
            Assert.Throws<ExcelDataReader.Exceptions.HeaderException>(() => client.RetrieveAllFromSheet(0));
        }


        #region test data, mocks

        private IWeatherEngine _weatherEngine = null;
        public IWeatherEngine MockWeatherEngine
        {
            get
            {
                if (_weatherEngine == null)
                {
                    _weatherEngine = new WeatherEngine();
                }
                return _weatherEngine;
            }
        }


        #endregion


    }
}


using NUnit.Framework;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using Weather27612.Core;
using Weather27612.WebApi.Controllers;
using Weather27612.WebApi.ViewModels;

namespace Weather27612.Tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void GetPrediction_No_Date_Supplied()
        {
            //Arrange
            var controller = new PredictionController(MockWeatherEngine);

            // Act
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<RainfallResultViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
 
            //since current date varies, we will just assert that we have some values for mean and std
            Assert.IsTrue(contentResult.Content.MeanPrcp > 0);
            Assert.IsTrue(contentResult.Content.StdDev > 0);
        }

        [Test]
        public void GetPrediction_With_Date_Supplied()
        {
            //Arrange
            //date is in September
            string date = "2020-09-14";
            var controller = new PredictionController(MockWeatherEngine);

            //Act
            IHttpActionResult actionResult = controller.Get(date);
            var contentResult = actionResult as OkNegotiatedContentResult<RainfallResultViewModel>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(MockRainfallResultViewModel1.MeanPrcp, contentResult.Content.MeanPrcp);
            Assert.AreEqual(MockRainfallResultViewModel1.StdDev, contentResult.Content.StdDev);

            //Arrange
            //date is in January
            date = "01-31-2021";

            //Act
            actionResult = controller.Get(date);
            contentResult = actionResult as OkNegotiatedContentResult<RainfallResultViewModel>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(MockRainfallResultViewModel2.MeanPrcp, contentResult.Content.MeanPrcp);
            Assert.AreEqual(MockRainfallResultViewModel2.StdDev, contentResult.Content.StdDev);
        }

        [Test]
        public void GetPrediction_With_Invalid_Date_Supplied()
        {
            //Arrange
            string date = "2020-02-30";
            var controller = new PredictionController(MockWeatherEngine);

            // Act
            IHttpActionResult actionResult = controller.Get(date);

            // Assert
            Assert.AreEqual(actionResult.ToString(), "System.Web.Http.Results.BadRequestErrorMessageResult");
            Console.WriteLine(actionResult);
        }


        #region test data, mocks

        private RainfallResultViewModel MockRainfallResultViewModel1 = new RainfallResultViewModel
        {
            MeanPrcp = 0.359265834f,
            StdDev = 0.7771412874422842
        };


        private RainfallResultViewModel MockRainfallResultViewModel2 = new RainfallResultViewModel
        {
            MeanPrcp = 0.173857674f,
            StdDev = 0.2957091770425298
        };


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


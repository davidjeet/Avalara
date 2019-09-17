using System;
using System.Web.Http;
using Weather27612.Core;
using Weather27612.Core.Model;
using Weather27612.WebApi.ViewModels;

namespace Weather27612.WebApi.Controllers
{
    public class PredictionController : ApiController
    {
        private IWeatherEngine _weatherEngine;

        public PredictionController(IWeatherEngine weatherEngine)
        {
            _weatherEngine = weatherEngine;
        }

        /// <summary>
        /// Retrieve prediction based on date supplied.
        /// </summary>
        /// <param name="dateSource">Date for rainfall to be predicted</param>
        /// <returns>Rainfall prediction</returns>
        [HttpGet, Route("prediction/{dateSource}")]
        public IHttpActionResult Get(string dateSource)
        {
            DateTime validDate;
            bool canParseDate = DateTime.TryParse(dateSource, out validDate);
            if (canParseDate)
            {
                RainfallResult model = null;
                try
                {
                    model = _weatherEngine.GetRainfallPrediction(validDate);
                }
                catch(Exception ex)
                {
                    BadRequest(ex.Message);
                }
                return Ok(new RainfallResultViewModel { MeanPrcp = model.MeanPrcp, StdDev = model.StdDev });
            }
            return BadRequest("Invalid date format supplied by user");
        }

        /// <summary>
        /// Retrieve prediction w/o date supplied (uses today's date).
        /// </summary>
        /// <returns>Rainfall prediction</returns>
        [HttpGet, Route("prediction")]
        public IHttpActionResult Get()
        {            
            return Get(DateTime.Now.ToString());
        }
    }
}

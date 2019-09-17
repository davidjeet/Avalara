using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Weather27612.Api.Controllers
{
    public class PredictionController
    {
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("api/Player/videos")]
        public IHttpActionResult GetVideoMappings()
        {
            var model = new MyCarModel();
            return Json(model);
        }

    }
}



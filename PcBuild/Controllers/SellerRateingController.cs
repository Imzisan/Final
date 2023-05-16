using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PcBuild.Controllers
{
    public class SellerRateingController : ApiController
    {
        [HttpGet]
        [Route("api/SellerRating/{id}")]
        public HttpResponseMessage SellerReview(int id)
        {
            try
            {
                var data = SellerReviewService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}

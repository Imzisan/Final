using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PcBuild.Controllers
{
    public class TopSearchSelleingproductController : ApiController
    {

        [HttpGet]
        [Route("api/TSelleingProduct")]
        public HttpResponseMessage TSelleingProducts()
        {
            try
            {
                var data = TopSearchSelleingproductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/search/{product}")]
        public HttpResponseMessage Get(string product)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, TSProducRepoService.Get(product));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/TSelleingProduct/add")]
        public HttpResponseMessage Add(TopSearchSelleingproductDTO obj)
        {
            try
            {
                var res = TopSearchSelleingproductService.Create(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = obj });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }

    }
}

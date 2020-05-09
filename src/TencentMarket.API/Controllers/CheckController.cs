using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TencentMarket.API.Controllers
{
    public class CheckController : ApiController
    {

        public CheckController()
        {

        }

        /// <summary>
        /// Check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> HealthAsync()
        {
            var str = "OK";
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(str, Encoding.UTF8, "text/plain")
            };
            return result;
        }
    }
}

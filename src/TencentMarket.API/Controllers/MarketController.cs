using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TencentMarket.API.Extensions;
using TencentMarket.API.Models.ViewModels;
using TencentMarket.API.Services;

namespace TencentMarket.API.Controllers
{
    public class MarketController : ApiController
    {
        public TencentMarketService service = new TencentMarketService();

        public static bool IsDebug = true;
        public MarketController()
        {

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddAsync([FromBody] UserInfo userInfo)
        {
            userInfo.Phone = userInfo.Phone.Trim();

            if (!IsDebug)
            {
                var hash = EncryExtension.MD5Hash(userInfo.Phone);
                if (hash != userInfo.Token)
                {
                    HttpResponseMessage errResponse = Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Token");
                    return errResponse;
                }
            }

            var result = await service.ActionUp(userInfo);
            return result;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "OK");
            return response;
        }
    }
}

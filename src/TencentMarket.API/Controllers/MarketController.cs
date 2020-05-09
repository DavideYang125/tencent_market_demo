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

        /// <summary>
        /// 落地页提交操作
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> AddAsync([FromBody] UserInfo userInfo)
        {
            userInfo.phone = userInfo.phone.Trim();
            try
            {
                //md5校验  由于企划部写页面的同事不会用md5，因此这个功能暂时注释

                //var hash = EncryExtension.MD5Hash(userInfo.phone);
                //if (hash != userInfo.token)
                //{
                //    HttpResponseMessage errResponse = Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Token");
                //    return errResponse;
                //}

                var result = await service.ActionUp(userInfo);
                return result;
            }
            catch
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Exception");
                return response;
            }
        }
    }
}

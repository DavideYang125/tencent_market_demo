using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TencentMarket.API.Models;
using TencentMarket.API.Models.ViewModels;
using TencentMarket.API.Services.Dto;

namespace TencentMarket.API.Services
{
    /// <summary>
    /// 处理腾讯广告逻辑
    /// https://api.e.qq.com/v1.2/user_actions/add?access_token=<ACCESS_TOKEN>&timestamp=<TIMESTAMP>&nonce=<NONCE>'
    /// </summary>
    public class TencentMarketService
    {
        public const string _addUrl = "https://api.e.qq.com/v1.2/user_actions/add";

        public const string _sanboxUrl = "https://sandbox-api.e.qq.com/v1.2/user_actions/add";

        public const string access_token = "d104cc10891fbfc99223a0c7294bf7d2";

        public const string refresh_token = "089eb4a6765c100da2f6de83ca07b264";

        /// <summary>
        /// 行为数据上报
        /// </summary>
        public async Task<HttpResponseMessage> ActionUp(UserInfo userInfo)
        {
            var dd = JsonConvert.SerializeObject(userInfo);

            var accessToken = access_token;

            var rrr = ActionTypeEnum.RESERVATION.ToString();

            TencentMarketClient client = new TencentMarketClient();

            var sandBox = false;

            var url = _addUrl + string.Format("?access_token={0}&timestamp={1}&nonce={2}", accessToken, GetTimeStamp(), Guid.NewGuid().ToString("N"));

            if (sandBox == true) url = _sanboxUrl + string.Format("?access_token={0}&timestamp={1}&nonce={2}", accessToken, GetTimeStamp(), Guid.NewGuid().ToString("N"));

            ActionUpRequestDto actionUpRequest = new ActionUpRequestDto()
            {
                AccounId = "15250111",// "15250111",//7093943
                Actions = new List<Dto.Action>() {
                      new Dto.Action()
                      {
                           ActionTime=0,
                            ActionType= ActionTypeEnum.RESERVATION.ToString(),
                              ExternalActionId=Guid.NewGuid().ToString(),
                               UserId=new UserId()
                               {
                               },
                               Trance=new Trance(){  ClickId=userInfo.ClickId},
                      }
                 },
                UserActionSetId = "1110488186",

            };

            var result = await client.ActionUp(url, actionUpRequest);

            if (result.IsSuccessStatusCode)
            {
                string resultContent = result.Content.ReadAsStringAsync().Result;
                var contentObj = JsonConvert.DeserializeObject<TencentResultModel>(resultContent);
                if (contentObj.Code == "0")
                {

                }
            }

            return result;
        }

        #region private

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        #endregion
    }
}
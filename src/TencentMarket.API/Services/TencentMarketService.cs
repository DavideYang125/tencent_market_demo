using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TencentMarket.API.Extensions;
using TencentMarket.API.Models;
using TencentMarket.API.Models.ViewModels;
using TencentMarket.API.Services.Dto;

namespace TencentMarket.API.Services
{
    /// <summary>
    /// 处理腾讯广告逻辑
    /// https://developers.e.qq.com/docs/api/user_data/user_action/user_actions_add?version=1.2
    /// </summary>
    public class TencentMarketService
    {
        public const string _addUrl = "https://api.e.qq.com/v1.2/user_actions/add";

        public const string _sanboxUrl = "https://sandbox-api.e.qq.com/v1.2/user_actions/add";

        public const string access_token = "95aa8d19c08dcca99ddee9d865517b59";

        public const string refresh_token = "f6d70c362c062a26751784938a8ca311";

        public const string account_id = "15250111";

        public const string action_set_id = "1110454022";

        /// <summary>
        /// 行为数据上报
        /// </summary>
        public async Task<HttpResponseMessage> ActionUp(UserInfo userInfo)
        {
            var dd = JsonConvert.SerializeObject(userInfo);

            var accessToken = access_token;

            var rrr = ActionTypeEnum.RESERVATION.ToString();

            TencentMarketClient client = new TencentMarketClient();

            //沙盒测试
            var sandBox = false;

            var url = _addUrl + string.Format("?access_token={0}&timestamp={1}&nonce={2}", accessToken, GetTimeStamp(), Guid.NewGuid().ToString("N"));

            if (sandBox == true) url = _sanboxUrl + string.Format("?access_token={0}&timestamp={1}&nonce={2}", accessToken, GetTimeStamp(), Guid.NewGuid().ToString("N"));

            ActionUpRequestDto actionUpRequest = new ActionUpRequestDto()
            {
                AccounId = account_id,// "15250111",//7093943
                Actions = new List<Dto.Action>() {
                      new Dto.Action()
                      {
                           ActionTime=0,
                            ActionType= ActionTypeEnum.RESERVATION.ToString(),
                              ExternalActionId=Guid.NewGuid().ToString(),
                               UserId=new UserId()
                               {
                               },
                               Trance=new Trance(){  ClickId=userInfo.click_id},
                      }
                 },
                UserActionSetId = action_set_id,

            };

            var result = await client.ActionUp(url, actionUpRequest);

            if (result.IsSuccessStatusCode)
            {
                string resultContent = result.Content.ReadAsStringAsync().Result;
                var contentObj = JsonConvert.DeserializeObject<TencentResultModel>(resultContent);
                if (contentObj.Code == "0")
                {
                    LogExtension.Info($"上传用户行为成功");
                }
                else
                {
                    LogExtension.Info($"上传用户行为失败，click_id:{userInfo.click_id}");
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TencentMarket.API.Models;
using TencentMarket.API.Services.Dto;

namespace TencentMarket.API.Services
{
    public class TencentMarketClient
    {
        protected HttpClient _client = new HttpClient();

        protected string ApiPath { get; set; }

        public TencentMarketClient()
        {
        }

        /// <summary>
        /// action up
        /// </summary>
        public async Task<HttpResponseMessage> ActionUp(string url, ActionUpRequestDto content)
        {
            try
            {
                var str = JsonConvert.SerializeObject(content);

                var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                var response = _client.PostAsync(url, stringContent);
                var result = response.Result;
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
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
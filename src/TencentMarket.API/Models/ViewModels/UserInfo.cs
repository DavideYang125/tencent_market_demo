using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TencentMarket.API.Models.ViewModels
{
    /// <summary>
    /// 表单数据模型
    /// </summary>
    public class UserInfo
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("click_id")]
        public string ClickId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 最高学历
        /// </summary>
        [JsonProperty("highest_edu")]
        public string HighestEdu { get; set; }

        /// <summary>
        /// 工作年限
        /// </summary>
        [JsonProperty("work_years")]
        public string WorkYears { get; set; }
    }
}
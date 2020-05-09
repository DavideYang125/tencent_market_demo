using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TencentMarket.API.Services.Dto
{
    /// <summary>
    /// https://developers.e.qq.com/docs/apilist/user_data/user_action
    /// </summary>
    public class ActionUpRequestDto
    {
        /// <summary>
        /// 推广帐号 id
        /// </summary>
        [JsonProperty("account_id")]
        public string AccounId { get; set; }

        /// <summary>
        /// 行为源id
        /// </summary>
        [JsonProperty("user_action_set_id")]
        public string UserActionSetId { get; set; }

        /// <summary>
        /// actions
        /// </summary>
        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }

    /// <summary>
    /// 行为
    /// </summary>
    public class Action
    {
        /// <summary>
        /// 行为时间
        /// </summary>
        [JsonProperty("action_time")]
        public long ActionTime { get; set; }

        [JsonProperty("user_id")]
        public UserId UserId { get; set; }

        /// <summary>
        /// 行为类型
        /// </summary>
        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        /// <summary>
        /// 行为id
        /// </summary>
        [JsonProperty("external_action_id")]
        public string ExternalActionId { get; set; }

        /// <summary>
        /// 自定义行为类型
        /// </summary>
        [JsonProperty("custom_action")]
        public string CustomAction { get; set; }

        [JsonProperty("trance")]
        public Trance Trance { get; set; }
    }

    /// <summary>
    /// 跟踪信息
    /// </summary>
    public class Trance
    {
        /// <summary>
        /// 点击 id
        /// </summary>
        [JsonProperty("click_id")]
        public string ClickId { get; set; }
    }

    /// <summary>
    /// 用户标识
    /// </summary>
    public class UserId
    {

    }

    /// <summary>
    /// 行为类型
    /// </summary>
    public enum ActionTypeEnum
    {
        [Description("自定义")] CUSTOM,

        [Description("预约")] RESERVATION,

        [Description("注册")] REGISTER
    }
}
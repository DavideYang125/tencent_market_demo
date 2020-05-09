using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TencentMarket.API.Extensions
{
    public class LogExtension
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 普通级别
        /// </summary>
        /// <param name="content"></param>
        public static void Info(string content)
        {
            Logger.Info(content);
        }
    }
}
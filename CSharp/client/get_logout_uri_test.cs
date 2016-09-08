﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.CommonClasses;
using CSharp.ResponseClasses;

namespace CSharp.client
{
    public class get_logout_uri_test
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the Logout URL
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public LogoutResponse GetLogoutURL(string host, int port, string oxdId)
        {
            try
            {
                CommandClient client = new CommandClient(host, port);

                GetLogoutUrlParams param = new GetLogoutUrlParams();
                param.setOxdId(oxdId);

                Command cmd = new Command(CommandType.get_logout_uri);
                cmd.setParamsObject(param);

                string response = client.send(cmd);
                LogoutResponse res = JsonConvert.DeserializeObject<LogoutResponse>(response);
                Assert.IsNotNull(res.Data.LogoutUri);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Debug(ex.Message);
                return null;
            }
        }
    }
}
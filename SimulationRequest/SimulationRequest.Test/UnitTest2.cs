using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulationRequest.Core;
using System.Collections.Generic;

namespace SimulationRequest.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ProxyKuaiDaiLiHelperTest()
        {
            var proxy = new ProxyKuaiDaiLiHelper();
            var list = proxy.GetIpsByApi(false);
            HttpHelper http = new HttpHelper();
            var result = new List<string>();
            foreach (var item in list)
            {
                if (http.CheckProxyIP(item))
                {
                    result.Add(item);
                }
            }
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void ProxyXiciHelperTest()
        {
            var proxy = new ProxyXiciHelper();
            var list = proxy.GetIpsByApi(false);
            HttpHelper http = new HttpHelper();
            var result = new List<string>();
            foreach (var item in list)
            {
                if (http.CheckProxyIP(item))
                {
                    result.Add(item);
                }
            }
            Assert.IsTrue(result.Count > 0);//100-3 100-8 
        }
        [TestMethod]
        public void ProxyIp66HelperTest()
        {
            var proxy = new ProxyIp66Helper();
            var list = proxy.GetIpsByApi(false);
            HttpHelper http = new HttpHelper();
            var result = new List<string>();
            foreach (var item in list)
            {
                if (http.CheckProxyIP(item))
                {
                    result.Add(item);
                }
            }
            Assert.IsTrue(result.Count > 0);//100-7-2s 100-7-2s  100-20-8s
        }
    }
}

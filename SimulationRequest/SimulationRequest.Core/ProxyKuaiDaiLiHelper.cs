using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimulationRequest.Core
{
    /// <summary>
    /// 快代理 http://www.kuaidaili.com
    /// </summary>
    public class ProxyKuaiDaiLiHelper:ProxyHelper
    {
        public ProxyKuaiDaiLiHelper(string apiUrl = "http://www.kuaidaili.com/free/inha/1/", string ipTxtPath = "")
            : base(apiUrl, ipTxtPath)
        {
        }
        public override List<string> GetIpsByApi(bool saveTxt = false)
        {
            if (string.IsNullOrEmpty(_ipRequestUrl))
            {
                return new List<string>();
            }
            HttpHelper http = new HttpHelper();
            var ips = new List<string>();
            var reuslt = http.GetHtml(new HttpItem()
            {
                URL = _ipRequestUrl,
                Timeout = 3000,
                UserAgent = "Mozilla/8.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36"
            });

            reuslt.Html = reuslt.Html = reuslt.Html.Replace("</td>\n                <td data-title=\"PORT\">", ":");
            Regex regex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,4}");
            MatchCollection mc = regex.Matches(reuslt.Html);
            foreach (Match m in mc)
            {
                ips.Add(m.Value);
            }
            if (saveTxt)
                SaveIpToTxt(ips);
            return ips;
        }
    }
}

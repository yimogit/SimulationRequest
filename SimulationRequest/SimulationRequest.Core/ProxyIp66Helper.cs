using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimulationRequest.Core
{
    public class ProxyIp66Helper:ProxyHelper
    {
        public ProxyIp66Helper(string apiUrl = "http://www.66ip.cn/mo.php?sxb=&tqsl=100&port=&export=&ktip=&sxa=&submit=%CC%E1++%C8%A1&textarea=http%3A%2F%2Fwww.66ip.cn%2F%3Fsxb%3D%26tqsl%3D100%26ports%255B%255D2%3D%26ktip%3D%26sxa%3D%26radio%3Dradio%26submit%3D%25CC%25E1%2B%2B%25C8%25A1", string ipTxtPath = "")
            : base(apiUrl, ipTxtPath)
        {
        }
        //public override List<string> GetIpsByApi(bool saveTxt = false)
        //{
        //    if (string.IsNullOrEmpty(base._ipRequestUrl))
        //    {
        //        return new List<string>();
        //    }
        //    HttpHelper http = new HttpHelper();
        //    var ips = new List<string>();
        //    var reuslt = http.GetHtml(new HttpItem()
        //    {
        //        URL = base._ipRequestUrl,
        //        Timeout = 3000,
        //        UserAgent = "Mozilla/8.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36"
        //    });
        //    var str = "";
        //    Regex regex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,4}");
        //    MatchCollection mc = regex.Matches(reuslt.Html);
        //    foreach (Match m in mc)
        //    {
        //        str += m.Value + "\r\n";
        //        ips.Add(m.Value);
        //    }
        //    if (saveTxt)
        //        base.SaveIpToTxt(str);
        //    return ips;
        //}
    }
}

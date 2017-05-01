using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimulationRequest.Core
{
    public abstract class ProxyHelper
    {
        protected string _ipRequestUrl { get; set; }
        protected string _ipTxtPath { get; set; }
        public ProxyHelper(string apiUrl,string ipTextPath)
        {
            _ipRequestUrl = apiUrl;
            _ipTxtPath = ipTextPath;
        }
        /// <summary>
        /// 通过接口获取IP
        /// </summary>
        /// <param name="saveTxt">保存到文本文件中【覆盖写入】</param>
        /// <returns></returns>
        public virtual List<string> GetIpsByApi(bool saveTxt = false)
        {
            return GetIpsBycurrency(saveTxt);
        }
        protected List<string> GetIpsBycurrency(bool saveTxt)
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
            var str = "";
            Regex regex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,4}");
            MatchCollection mc = regex.Matches(reuslt.Html);
            foreach (Match m in mc)
            {
                str += m.Value + "\r\n";
                ips.Add(m.Value);
            }
            if (saveTxt)
                SaveIpToTxt(str);
            return ips;
        } 
        /// <summary>
        /// 获取文件中的IP 若无数据则尝试重接口获取
        /// </summary>
        /// <returns></returns>
        public List<string> GetIpsByTxt()
        {
            var ips = new List<string>();
            if (string.IsNullOrEmpty(_ipTxtPath) == false)
            {
                using (var reader = new StreamReader(_ipTxtPath, Encoding.Default))
                {
                    ips = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (ips.Count > 0)
                    {
                        return ips;
                    }
                }
            }
            return this.GetIpsByApi(true);
        }
        /// <summary>
        /// 保存到文本中，覆盖写入
        /// </summary>
        /// <param name="ips"></param>
        public void SaveIpToTxt(string ips)
        {
            if (string.IsNullOrEmpty(_ipTxtPath))
            {
                return;
            }
            using (FileStream fs = new FileStream(_ipTxtPath, FileMode.Create, FileAccess.Write,
                                                 FileShare.ReadWrite, 1024, FileOptions.Asynchronous))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ips + "\r\n");
                IAsyncResult writeResult = fs.BeginWrite(buffer, 0, buffer.Length,
                    (asyncResult) =>
                    {
                        var fStream = (FileStream)asyncResult.AsyncState;
                        fStream.EndWrite(asyncResult);
                    },
                    fs);
                fs.Close();
            }
        }
        public void SaveIpToTxt(List<string> ips)
        {
            SaveIpToTxt(string.Join("\r\n", ips));
        }
    }
}

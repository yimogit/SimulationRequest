using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimulationRequest.Core
{
    public class ProxyXiciHelper:ProxyHelper
    {
        public ProxyXiciHelper(string apiUrl="http://api.xicidaili.com/free2016.txt", string ipTxtPath="")
            : base(apiUrl, ipTxtPath)
        {
        }
        public override List<string> GetIpsByApi(bool saveTxt = false)
        {
            return base.GetIpsBycurrency(saveTxt);
        }
    }
}

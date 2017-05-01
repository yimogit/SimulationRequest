using SimulationRequest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationRequest.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtPath = "./ip.txt";
            Console.WriteLine("获取代理IP：");
            var proxy1 = new ProxyXiciHelper(ipTxtPath: txtPath);
            var list1 = proxy1.GetIpsByApi(true);
            var list2 = proxy1.GetIpsByTxt();
            var proxy2 = new ProxyIp66Helper(ipTxtPath: txtPath);
            var list3 = proxy2.GetIpsByApi(true);
            var list4 = proxy2.GetIpsByTxt();
            var result = new List<string>();
            var proxy3 = new ProxyKuaiDaiLiHelper(ipTxtPath: txtPath);
            var list5 = proxy3.GetIpsByApi(false);
            result.AddRange(list1);
            result.AddRange(list2);
            result.AddRange(list3);
            result.AddRange(list4);
            result.AddRange(list5);
            var i = 0;
            result.ForEach(item =>
            {
                Console.WriteLine("{0}：{1}", ++i, item);
            });
            Console.WriteLine("获取IP数量：" + result.Count);
            Console.WriteLine("非重复IP数量：" + result.Distinct().Count());

            Console.WriteLine(result.Count);

            Console.ReadKey();
        }
    }
}

 
var request = require("request");
var iconv = require('iconv-lite');
var Promise = require("bluebird");
var fs=require('fs');  
 
function getProxyList() {
    return new Promise((resolve,reject)=>{
        fs.readFile('./ips.txt','utf-8',function(err,data){  
            if(err){  
                console.error(err);  
            }  
            else{  
                var ret = data.match(/\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,4}/g); 
                resolve(ret);
            }  
        });  
    })
    var apiURL = 'http://www.66ip.cn/mo.php?sxb=&tqsl=500&port=&export=&ktip=&sxa=&submit=%CC%E1++%C8%A1&textarea=http%3A%2F%2Fwww.66ip.cn%2F%3Fsxb%3D%26tqsl%3D100%26ports%255B%255D2%3D%26ktip%3D%26sxa%3D%26radio%3Dradio%26submit%3D%25CC%25E1%2B%2B%25C8%25A1';
    // apiURL='http://www.66ip.cn/nmtq.php?getnum=800&isp=0&anonymoustype=0&start=&ports=&export=&ipaddress=&area=0&proxytype=2&api=66ip';
 
    return new Promise((resolve, reject) => {
        var options = {
            method: 'GET',
            url: apiURL,
            gzip: true,
            encoding: null,
            headers: {
                'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
                'Accept-Encoding': 'gzip, deflate',
                'Accept-Language': 'zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4',
                'User-Agent': 'Mozilla/8.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36',
                'referer': 'http://www.66ip.cn/'
            },
 
        };
 
        request(options, function (error, response, body) {
 
 
            try {
 
                if (error) throw error;
 
                if (/meta.*charset=gb2312/.test(body)) {
                    body = iconv.decode(body, 'gbk');
                }
 
                var ret = body.match(/\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,4}/g);
 
 
                resolve(ret);
 
            } catch (e) {
                return reject(e);
            }
 
 
        });
    })
}
 
 
getProxyList().then(function (proxyList) {
 var targetOptions={
     form:{
         vote:23
     },
     timeout:8000,
     proxy:null
 }
 console.log(proxyList.length);
 var i=1;
 var j=1;
 var k=0;
    //这里修改一下，变成你要访问的目标网站
    proxyList.forEach(function (proxyurl) {
        console.log(`${j++}.testing ${proxyurl}`);
        targetOptions.form.vote=Math.ceil(Math.random()*22)
        targetOptions.proxy = 'http://' + proxyurl;
        request.post('http://basi.dilidili.wang/',targetOptions,function (error, response, body) {
            try {
                if (error) throw error;
                if (body) {
                    body = body.toString();
                    if(body.indexOf('投票成功')>-1){
                        fs.appendFileSync('./ips2.txt',proxyurl+',')
                    }
                    k+=body.indexOf('投票成功')>-1?1:0;
                    console.log(`${i++}.${body.indexOf('投票成功')>-1?'投票成功':'投票失败'}--${k}--${proxyurl}`);
                }
                else{
                    console.log(`${i++}.${proxyurl}验证失败`);
                }
            } catch (e) {
                console.log(`${i++}.${proxyurl}验证失败`);
            }
 
 
        });
 
    });
}).catch(e => {
    console.log(e);
})
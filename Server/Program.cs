using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace IdCardReaderServer {
    class Program {
        static void Main(string[] args) {
            //指定聆聽的URL
           // var config = new HttpSelfHostConfiguration("http://localhost:8011");

             string HostUrl = ConfigurationManager.AppSettings["HostUrl"];
            var config = new HttpSelfHostConfiguration(HostUrl);
            //注意: 在Vista, Win7/8，預設需以管理者權限執行才能繫結到指定URL，否則要透過以下指令授權
            //開放授權 netsh http add urlacl url=http://+:32767/ user=machine\username
            //移除權限 netsh http delete urlacl url=http://+:32767/
            //設定路由
            config.Routes.MapHttpRoute("API", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            //設定Self-Host Server，由於會使用到網路資源，用using確保會Dispose()加以釋放
            using (var httpServer = new HttpSelfHostServer(config)) {
                //OpenAsync()屬非同步呼叫，加上Wait()則等待開啟完成才往下執行
                httpServer.OpenAsync().Wait();
                Console.WriteLine("Web API host started...");
                //輸入exit按Enter結束httpServer
                string line = null;
                do {
                    line = Console.ReadLine();
                }
                while (line != "exit");
                //結束連線
                httpServer.CloseAsync().Wait();
            }
        }
    }
}

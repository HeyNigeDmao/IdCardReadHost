using System.Configuration;
using System.Web.Http;
using System.Web.Http.SelfHost;
//using Autofac;

namespace IdCardReaderServer {
    public static class Startup {

        private static readonly string HostUrl = ConfigurationManager.AppSettings["HostUrl"];
        private static readonly HttpSelfHostConfiguration Config;
        private static HttpSelfHostServer _httpServer;

        static Startup() {
            // Config = new HttpSelfHostConfiguration("http://localhost:8011");
            Config = new HttpSelfHostConfiguration(HostUrl);
            Config.Routes.MapHttpRoute("API", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            ////設定Self-Host Server，由於會使用到網路資源，用using確保會Dispose()加以釋放
            //using (var httpServer = new HttpSelfHostServer(Config)) {
            //    //OpenAsync()屬非同步呼叫，加上Wait()則等待開啟完成才往下執行
            //    httpServer.OpenAsync().Wait();
            //    Console.WriteLine("Web API host started...");
            //    ////輸入exit按Enter結束httpServer
            //    //string line = null;
            //    //do {
            //    //    line = Console.ReadLine();
            //    //}
            //    //while (line != "exit");
            //    ////結束連線
            //    //httpServer.CloseAsync().Wait();
            //}
        }

        public static void Start() {
            if (_httpServer == null) {
                _httpServer = new HttpSelfHostServer(Config);
            }
            _httpServer.OpenAsync().Wait();
        }

        public static void Stop() {
            _httpServer.CloseAsync().Wait();
            _httpServer.Dispose();
        }

    }
}

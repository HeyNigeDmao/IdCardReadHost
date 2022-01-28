using IdCardReaderServer;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace IdCardService {
    public partial class IdReaderService : ServiceBase {
        public IdReaderService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            try {
                Startup.Start();
            }
            catch (Exception e) {
                EventLog.WriteEntry($"{ServiceName}服务启动错误{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
                Stop();
            }
            EventLog.WriteEntry($"{ServiceName}服务启动");
        }

        protected override void OnStop() {
            try {
                Startup.Stop();
            }
            catch (Exception e) {
                EventLog.WriteEntry($"{ServiceName}服务停止错误{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            EventLog.WriteEntry($"{ServiceName}服务停止");
        }

        void _initService() {
            AutoLog = true;
            CanStop = true;
            ServiceName = ConfigurationManager.AppSettings["ServiceName"] ?? "身份证读卡器服务";
        }
    }
}

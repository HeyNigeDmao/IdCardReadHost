using aidhost;
using System;
using System.Web.Http;
using System.Net.Http;
using aidhost.Model;
using Newtonsoft.Json;

namespace IdCardReaderServer.Controller {
    public class IdReaderController : ApiController {

        private readonly IDCardReaderService _srv;
        public IdReaderController() {
            _srv = new IDCardReaderService();
        }

        [HttpGet]
        public string Date() {
            return DateTime.Today.ToString("yyyy/MM/dd");
        }

        [HttpGet]
        public string ReadCard(int port = 0) {
            return _srv.ReadCard(port);
        }

        [HttpGet]
        public HttpResponseMessage ReadCard2(int port = 0) {
            string json = _srv.ReadCard(port);
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }
        [HttpGet]
        public IdCardInfoModel ReadCard3(int port = 0) {

            return _srv.ReadCard2(port);
        }
        [HttpGet]
        public string ReadCard4(int port = 0) {
            var ss= _srv.ReadCard2(port);
            return JsonConvert.SerializeObject(ss);
        }
    }
}

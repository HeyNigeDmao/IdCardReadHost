using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aidhost.Model {
    public class IdCardInfoModel {
        /// <summary>
        /// 附加的，读卡器端口号
        /// </summary>
        public int? Port { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 发证机关
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 有效期起
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 有效期止
        /// </summary>
        public string EndtDate { get; set; }
        /// <summary>
        /// 照片的Base64编码字符串
        /// </summary>
        public string PhotoBase64 { get; set; }

        

    }
}

using aidhost.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidhost {
    public class IDCardReaderService {

        /// <summary>
        /// 返回json字符
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public string ReadCard(int port) {
            string str = "";
            if (port == 0) {
                for (int i = 0; i < 1111; i++) {
                    if (IDMethod.InitComm(i) == 1) {
                        //MessageBox.Show(i.ToString());
                        port = i;
                        break;
                    }
                }
            }
            if (port == 0) {
                str = "错误：未能找到端口。";
                return str;
            }
            if (IDMethod.InitComm(port) == 1) {
                if (IDMethod.Authenticate() == 1) {
                    if (IDMethod.Read_Content(1) == 1) {
                        IdCardInfoModel idmodel = new IdCardInfoModel();
                        idmodel.Port = port;
                        
                        Byte[] bs =  new byte[100];

                        int dwName = IDMethod.GetPeopleName(bs, 100);
                        idmodel.Name= IDMethod.GetInfoValue(bs, dwName);
                        // var name = IDMethod.GetInfoValue(bs, dwName);
                        // str = str + "\r\n" + name;
                        int dwSex = IDMethod.GetPeopleSex(bs, 100);
                        idmodel.Sex = IDMethod.GetInfoValue(bs, dwSex);
                        //var sex = IDMethod.GetInfoValue(bs, dwSex);
                        //str = str + "\r\n" + sex;
                        int dwNation = IDMethod.GetPeopleNation(bs, 100);
                        idmodel.Nation = IDMethod.GetInfoValue(bs, dwNation);
                        //var nation = IDMethod.GetInfoValue(bs, dwNation);
                        //str = str + "\r\n" + nation;
                        int dwBrithday = IDMethod.GetPeopleBirthday(bs, 100);
                        idmodel.Birthday = IDMethod.GetInfoValue(bs, dwBrithday);
                        //var brithday = IDMethod.GetInfoValue(bs, dwBrithday);
                        //str = str + "\r\n" + brithday;
                        int dwAddress = IDMethod.GetPeopleAddress(bs, 100);
                        idmodel.Address = IDMethod.GetInfoValue(bs, dwAddress);
                        //var address = IDMethod.GetInfoValue(bs, dwAddress);
                        //str = str + "\r\n" + address;
                        int dwCode = IDMethod.GetPeopleIDCode(bs, 100);
                        idmodel.Id = IDMethod.GetInfoValue(bs, dwCode);
                        //var id = IDMethod.GetInfoValue(bs, dwCode);
                        //str = str + "\r\n" + id;

                        int dwDept = IDMethod.GetDepartment(bs, 100);
                        idmodel.Department = IDMethod.GetInfoValue(bs, dwDept);

                        int dwBeginDate = IDMethod.GetStartDate(bs, 100);
                        idmodel.StartDate= IDMethod.GetInfoValue(bs, dwBeginDate);
                        //var beginDate = IDMethod.GetInfoValue(bs, dwBeginDate);
                        //str = str + "\r\n" + beginDate;
                        int dwEndDate = IDMethod.GetEndDate(bs, 100);
                        idmodel.EndtDate = IDMethod.GetInfoValue(bs, dwEndDate);
                        //var endDate = IDMethod.GetInfoValue(bs, dwEndDate);
                        //str = str + "\r\n" + endDate;

                        bs = null;
                        Byte[] bs2 = new byte[1024 * 100];
                        var dwPhotoLen = IDMethod.GetPhotoBMP(bs2, 1024 * 100);
                        bs2 = null;

                        Byte[] bs3 = new byte[dwPhotoLen];
                        var dwPhoto = IDMethod.GetPhotoBMP(bs3, dwPhotoLen);
                        //var phtoBase64 = Convert.ToBase64String(bs3);
                        //str = str + "\r\n" + phtoBase64;
                        idmodel.PhotoBase64 = Convert.ToBase64String(bs3);

                        bs3 = null;
                        GC.Collect();
                        IDMethod.CloseComm();

                        str = JsonConvert.SerializeObject(idmodel);
                    }
                    else
                        str = "错误：读卡错误。";
                }
                else
                    str = "错误：卡片错误。";
            }
            else
               str = "错误：端口错误。";
            return str;
        }

        /// <summary>
        /// 返回模型
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public IdCardInfoModel ReadCard2(int port) {
            IdCardInfoModel idmodel = null;
            if (port == 0) {
                for (int i = 0; i < 1111; i++) {
                    if (IDMethod.InitComm(i) == 1) {
                        //MessageBox.Show(i.ToString());
                        port = i;
                        break;
                    }
                }
            }
            if (port == 0) {
                return idmodel;
            }
            if (IDMethod.InitComm(port) == 1) {
                if (IDMethod.Authenticate() == 1) {
                    if (IDMethod.Read_Content(1) == 1) {
                        idmodel = new IdCardInfoModel();
                        idmodel.Port = port;

                        Byte[] bs = new byte[100];

                        int dwName = IDMethod.GetPeopleName(bs, 100);
                        idmodel.Name = IDMethod.GetInfoValue(bs, dwName);

                        int dwSex = IDMethod.GetPeopleSex(bs, 100);
                        idmodel.Sex = IDMethod.GetInfoValue(bs, dwSex);

                        int dwNation = IDMethod.GetPeopleNation(bs, 100);
                        idmodel.Nation = IDMethod.GetInfoValue(bs, dwNation);

                        int dwBrithday = IDMethod.GetPeopleBirthday(bs, 100);
                        idmodel.Birthday = IDMethod.GetInfoValue(bs, dwBrithday);
                        int dwAddress = IDMethod.GetPeopleAddress(bs, 100);
                        idmodel.Address = IDMethod.GetInfoValue(bs, dwAddress);

                        int dwCode = IDMethod.GetPeopleIDCode(bs, 100);
                        idmodel.Id = IDMethod.GetInfoValue(bs, dwCode);

                        int dwDept = IDMethod.GetDepartment(bs, 100);
                        idmodel.Department = IDMethod.GetInfoValue(bs, dwDept);

                        int dwBeginDate = IDMethod.GetStartDate(bs, 100);
                        idmodel.StartDate = IDMethod.GetInfoValue(bs, dwBeginDate);

                        int dwEndDate = IDMethod.GetEndDate(bs, 100);
                        idmodel.EndtDate = IDMethod.GetInfoValue(bs, dwEndDate);

                        bs = null;
                        Byte[] bs2 = new byte[1024 * 100];
                        var dwPhotoLen = IDMethod.GetPhotoBMP(bs2, 1024 * 100);
                        bs2 = null;

                        Byte[] bs3 = new byte[dwPhotoLen];
                        var dwPhoto = IDMethod.GetPhotoBMP(bs3, dwPhotoLen);
                        idmodel.PhotoBase64 = Convert.ToBase64String(bs3);

                        bs3 = null;
                        GC.Collect();
                        IDMethod.CloseComm();
                    }
                }
            }
            return idmodel;
        }
    }
}

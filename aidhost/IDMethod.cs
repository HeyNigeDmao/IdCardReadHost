using System;
using System.Runtime.InteropServices;
using System.Text;

namespace aidhost {
    public class IDMethod {

        //请根据自己需要把DLL丢到计算机指定目录，我直接丢到system32下面
        
        /// <summary>
        /// 初始化端口，1初始成功,其它数值表示失败
        /// </summary>
        /// <param name="iPort">端口号</param>
        [DllImport("termb.DLL", CharSet = CharSet.Auto)]
        public static extern int InitComm(int iPort);
        /// <summary>
        /// 关闭端口，1表示关闭成功，其它数值表示失败
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComm();
        /// <summary>
        /// 卡认证，1表示卡片正确，其它数值表示失败
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Authenticate();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="iActive">操作类型，1读基本信息；2只读文字信息；3读最新住址信息；4读芯片管理号</param>
        /// <returns>
        /// 1   正确
        /// 0   读卡错误
        /// -1  相片解码错误
        /// -2	wlt文件后缀错误
        /// -3	wlt文件打开错误
        /// -4	wlt文件格式错误
        /// -5	软件未授权
        /// -6	设备连接失败
        /// </returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Content(int iActive);
        /// <summary>
        /// 读取姓名
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleName(Byte[] buf, int iLen);
        /// <summary>
        /// 读取性别
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(Byte[] buf, int iLen);
        /// <summary>
        /// 读取民族
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleNation(Byte[] buf, int iLen);
        /// <summary>
        /// 读取出生日
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(Byte[] buf, int iLen);
        /// <summary>
        /// 读取住址
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(Byte[] buf, int iLen);
        /// <summary>
        /// 读取开始日期,返回格式:yyyyMMdd
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(Byte[] buf, int iLen);
        /// <summary>
        /// 读取截止日期,返回格式:yyyyMMdd
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(Byte[] buf, int iLen);
        /// <summary>
        /// 读取身份证号
        /// </summary>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(Byte[] buf, int iLen);

        /// <summary>
        /// 读取照片，fileName不为空时候，照片将会存到指定地址
        /// </summary>
        [DllImport("termb.DLL",CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPhotoBMP(Byte[] buf, int iLen);

        /// <summary>
        /// 得到发证机关信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(Byte[] buf, int iLen);

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="asciibytes">ascii码集合</param>
        /// <param name="dwret">文本长度</param>
        public static string GetInfoValue(Byte[] asciibytes, int dwret) {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciibytes, 0, dwret)];
            gb2312.GetChars(asciibytes, 0, dwret, asciiChars, 0);
            return new string(asciiChars);
        }
    }
}

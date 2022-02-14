# IdCardReadHost
国产读卡器读卡服务，仅限于Windows系统

多年前写的一个国腾身份证读卡器的一个读卡服务，在谷歌浏览器禁止非应用商店里的.crx插件后写的一个为客户机运行的读卡服务

****该方法调用termb.dll,不是所有品牌的读卡器都能使用，目前只知道国腾的机器能用****

1 需要安装.net 4.5.2，因此该服务不支持XP系统

2 读卡器驱动什么的自己装好之后再看下面

3 安装方法：将dll丢到system32文件夹或者你自己在代码中指定的位置，将Start.bat和stop.bat文件放在跟程序同一个目录下，以管理员身份运行Start.bat进行安装，如果要卸载请使用stop.bat

4 安装成功后，在“计算机--管理--服务和应用程序--服务”就可以看到就可以看到"身份证读卡器服务端"的服务，将该服务启动，并设置成自动启动

5 然后就可以调用端口了， http://localhost:5678/IdReader/ReadCard  默认端口是5678，如果要更改端口地址，则先停止服务，再修改.config文件里的端口号，再启动服务

JS调用代码如下

var port ="0";
function Test(){
     $.ajax({
            url: 'http://localhost:5678/IdReader/ReadCard?port=' + port,
            type: 'get',
            success: function (r) {
                //如果错误，则返回的字符前面一律带"错误"两个字
                if(r.indexOf('错误')==0){
                  //todo
                }
                else{
                   var obj =JSON.parse(r);
                   port = obj.Port; //返回正确的端口号
                   // obj.Name      //姓名
                   // obj.Sex       //性别
                   // obj.Nation    //民族
                   // obj.Birthday  //出生日期19990608
                   // obj.Address   //地址
                   // obj.Id        //身份证号
                   // obj.Department //发证机关
                   // obj.StartDate  //有效期开始日期 19990608
		               // obj.EndDate    //有效期结束日期 19990608、长期
                   // obj.PhotoBase64 //身份证头像转换的Base64字符
                }
            },
            error: function (r,t,e) {                
            }
        });
}

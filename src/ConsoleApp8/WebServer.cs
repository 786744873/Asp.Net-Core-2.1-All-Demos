/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：ConsoleApp8
/// 文件名称	：WebServer.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2018/12/11 14:38:13 
/// 邮箱		：786744873@qq.com
/// 个人主站	：https://www.cnblogs.com/wyt007/
///
/// 功能描述	：
/// 使用说明	：
/// =================================
/// 修改者	：
/// 修改日期	：
/// 修改内容	：
/// =================================
///
/// ***********************************************************************


using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp8
{
    /// <summary>
    /// 
    /// <see cref="WebServer" langword="" />
    /// </summary>
    public class WebServer
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static void Start()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, 8200));
            socket.Listen(100);

            //接收客户端的Socket请求
            socket.BeginAccept(OnAccept, socket);

            Console.WriteLine("当前Web服务器启动成功，端口号为8200");
        }

        //接收请求
        public static void OnAccept(IAsyncResult async)
        {
            var serverSocket = async.AsyncState as Socket;

            //获取到客户端的Socket
            var clientSocket = serverSocket.EndAccept(async);

            //进行下一步监听
            serverSocket.BeginAccept(OnAccept, socket);

            //获取其内容
            var bytes = new byte[10240];
            var len = clientSocket.Receive(bytes);
            var request = Encoding.UTF8.GetString(bytes, 0, len);

            var response = string.Empty;

            if (!string.IsNullOrEmpty(request)&&!request.Contains("favicon.ico"))
            {
                //1.html
                var filePath = request.Split("\r\n")[0].Split(" ")[1].Replace("/", "");

                //获取文件内容
                response = File.ReadAllText(filePath, Encoding.UTF8);
            }

            //按照Http响应码返回
            var responseHeader = string.Format(@"HTTP/1.1 200 OK
Date: Tue, 11 Dec 2018 07:08:44 GMT
Content-Type: text/html; charset=utf-8
Content-Length: {0}
Connection: keep-alive
Vary: Accept-Encoding
Cache-Control: private, max-age=10
Expires: Tue, 11 Dec 2018 07:08:54 GMT
Last-Modified: Tue, 11 Dec 2018 07:08:44 GMT
X-UA-Compatible: IE=10
X-Frame-Options: SAMEORIGIN

", Encoding.UTF8.GetByteCount(response));

            //返回给客户端
            clientSocket.Send(Encoding.UTF8.GetBytes(responseHeader));
            clientSocket.Send(Encoding.UTF8.GetBytes(response));

            clientSocket.Close(); 
        }

    }
}

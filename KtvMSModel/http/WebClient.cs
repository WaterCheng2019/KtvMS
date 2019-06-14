using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;

namespace KtvMSModel
{
    public class WebClient
    {
        private class CertPolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
            {
                return true;
            }
        }

        private const string BOUNDARY = "--HEDAODE--";

        private const int SEND_BUFFER_SIZE = 10245;

        private const int RECEIVE_BUFFER_SIZE = 10245;

        private WebHeaderCollection requestHeaders;//请求头

        private WebHeaderCollection responseHeaders;//响应头

        private TcpClient clientSocket;//为tc网络提供客户端连接

        private MemoryStream postStream;//支持储存区为内存的流

        private Encoding encoding = Encoding.Default;//默认编码格式

        private string cookie = "";

        private string respHtml = "";

        private string strRequesHeaders = "";

        private string strResponseHeaders = "";

        private int statusCode;

        private bool isCanceled;

        public WebHeaderCollection RequestHeaders
        {
            get
            {
                return requestHeaders;
            }
            set
            {
                requestHeaders = value;
            }
        }

        public WebHeaderCollection ResponseHeaders
        {
            get
            {
                return responseHeaders;
            }
        }

        public string StrRequestHeaders
        {
            get
            {
                return strRequesHeaders;
            }
        }

        public string StrResponseHeaders
        {
            get
            {
                return strResponseHeaders;
            }
        }

        public string Cookie
        {
            get
            {
                return cookie;
            }
            set
            {
                cookie = value;
            }
        }

        public Encoding Encoding
        {
            get
            {
                return encoding;
            }
            set
            {
                encoding = value;
            }
        }

        public string RespHtml
        {
            get
            {
                return respHtml;
            }
        }

        public int StatusCode
        {
            get
            {
                return statusCode;
            }
        }

        public event WebClientUploadEvent UploadProgressChanged;
        public event WebClientDownloadEvent DownloadProgressChanged;

        public WebClient()//构造函数
        {
            responseHeaders = new WebHeaderCollection();
            requestHeaders = new WebHeaderCollection();
        }


        #region 折叠 

        public string OpenRead(string URL)//打开读取
        {
            responseHeaders.Add("Connection", "close");
            SendRequestData(URL, "GET");
            return GetHtml();
        }
        public string OpenRead(string URL,string postData)
        {
            byte[] sendBytes = encoding.GetBytes(postData);
            postStream = new MemoryStream();
            postStream.Write(sendBytes,0,sendBytes.Length);
            requestHeaders.Add("Content-Length",postStream.Length.ToString());
            requestHeaders.Add("Content-Type","application/x-www-form-utlencoded");
            requestHeaders.Add("Connection","close");
            SendRequestData(URL,"POST");
            return GetHtml();
        }

        /// <summary>
        /// 打开读取获取Http
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="strPostdata"></param>
        /// <returns></returns>
        public string OpenReadWithHttps(string URL, string strPostdata)
        {
            ServicePointManager.CertificatePolicy = new CertPolicy();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = encoding.GetBytes(strPostdata);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer,0,buffer.Length);//写入请求的数据
            HttpWebResponse response=(HttpWebResponse)request.GetResponse();//资源的响应
            StreamReader reader = new StreamReader(response.GetResponseStream(),encoding);
            respHtml = reader.ReadToEnd();
            foreach (Cookie ck in response.Cookies)
            {
                string text = cookie;
                cookie = text + ck.Name + "=" + ck.Value + ";";
            }

            reader.Close();
            return respHtml;
        }
        /// <summary>
        /// 获取流
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public Stream GetStream(string URL,string postData)
        {
            byte[] sendBytes = encoding.GetBytes(postData);
            postStream = new MemoryStream();
            postStream.Write(sendBytes,0,sendBytes.Length);
            requestHeaders.Add("Content-Lenght",postStream.Length.ToString());
            requestHeaders.Add("Content-Type","application/x-www-form-urlencoded");
            requestHeaders.Add("Connection","close");
            SendRequestData(URL,"POST");
            MemoryStream ms = new MemoryStream();
            SaveNetworkStream(ms);
            return ms;
            
        }

        private void WriteTextField(string textField)
        {
            string[] strArr = Regex.Split(textField,"&");
            textField = "";
            string[] array = strArr;
            foreach (string var in array)
            {
                Match M = Regex.Match(var, "([^=]+)=(.+)");
                textField+= "----HEDAODE--\r\n";
                string text = textField;
                textField=text+ "Content-Disposition: form-data; name=\"" + M.Groups[1].Value + "\"\r\n\r\n" + M.Groups[2].Value + "\r\n";
            }
            byte[] buffer = encoding.GetBytes(textField);
            postStream.Write(buffer,0,buffer.Length);
        }

        private void WriteFileField(string fileFileld)
        {
            string filePath2 = "";
            int count2 = 0;
            string[] strArr = Regex.Split(fileFileld,"&");
            string[] array = strArr;
            foreach (string var in array)
            {
                Match M = Regex.Match(var, "([^=]+)=(.+)");
                filePath2 = M.Groups[2].Value;
                fileFileld = "----HEDAODE--\r\n";
                string text = fileFileld;
                fileFileld=text+ "Content-Disposition: form-data; name=\"" + M.Groups[1].Value + "\"; filename=\"" + Path.GetFileName(filePath2) + "\"\r\n";
                fileFileld += "Content-Type: image/jpeg\r\n\r\n";
                byte[] buffer3 = encoding.GetBytes(fileFileld);
                postStream.Write(buffer3,0,buffer3.Length);
                FileStream fs2 = new FileStream(filePath2,FileMode.Open,FileAccess.Read);
                buffer3 = new byte[50000];
                do
                {
                    count2 = fs2.Read(buffer3,0,buffer3.Length);
                    postStream.Write(buffer3,0,count2);
                } while (count2>0);
                fs2.Close();
                fs2.Dispose();
                fs2 = null;
                buffer3 = encoding.GetBytes("\r\n");
                postStream.Write(buffer3,0,buffer3.Length);

            }

        }

        public Stream DownloadData(string URL)
        {
            requestHeaders.Add("Connection","close");
            SendRequestData(URL,"GET");
            MemoryStream ms = new MemoryStream();
            SaveNetworkStream(ms,true);
            return ms;
        }

        public void Cancel()
        {
            isCanceled = true;
        }
        public void Start()
        {
            isCanceled = false;
        }


        private string GetHtml()
        {
            MemoryStream ms = new MemoryStream();
            SaveNetworkStream(ms);
            StreamReader sr = new StreamReader(ms, encoding);
            respHtml = sr.ReadToEnd();
            sr.Close();
            ms.Close();
            return respHtml;
        }

        #endregion

        public void DownloadFile(string URL,string fileName)
        {
            requestHeaders.Add("Connection","close");
            SendRequestData(URL,"GET");
            FileStream fs2 = new FileStream(fileName,FileMode.Create);
            SaveNetworkStream(fs2);
            fs2.Close();
            fs2 = null;
        }

        /// <summary>
        /// 发送请求数据
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="method"></param>
        private void SendRequestData(string URL, string method)
        {
            SendRequestData(URL, method, false);
        }
        public void SendRequestData(string URL, string method, bool showProgress)
        {
            clientSocket = new TcpClient();
            Uri URI = new Uri(URL);
            clientSocket.Connect(URI.Host, URI.Port);//将客户端连接指定主机上的端口
            requestHeaders.Add("Host", URI.Host);
            byte[] request = GetRequestHeaders(method+" "+URI.PathAndQuery+" HTTP/1.1");
            clientSocket.Client.Send(request);//将数据发给Socket
            if (postStream==null)
            {
                return;
            }
       
            byte[] buffer = new byte[10245];
            int count2 = 0;

            Stream sm = clientSocket.GetStream();
            postStream.Position = 0L;
            UploadEventArgs e = default(UploadEventArgs);
            e.totalBytes = postStream.Length;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (!isCanceled)
            {
                count2 = postStream.Read(buffer,0,buffer.Length);
                sm.Write(buffer,0,count2);

                if (showProgress)
                {
                    e.bytesSent += count2;
                    e.sendProgress = (double)e.bytesSent / (double)e.totalBytes;
                    double t2 = timer.ElapsedMilliseconds / 1000;
                    t2 = ((t2<=0.0)?1.0:t2);
                    e.sendSpeed=(double)e.bytesSent / t2;
                    this.UploadProgressChanged?.Invoke(this,e);
                }
                if (count2<=0)
                {
                    break;
                }

            }
            timer.Stop();
            postStream.Close();
            postStream = null;

        }

       /// <summary>
       /// 获取请求头部的数据
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>
        private byte[] GetRequestHeaders(string request)
        {
            requestHeaders.Add("Accept","*/*");
            requestHeaders.Add("Accept-language","zh-cn");
            requestHeaders.Add("User-Agent","Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            string headers2 = request + "\r\n";

            foreach (string key in requestHeaders)
            {
                string text = headers2;
                headers2 = text + key + ":" + requestHeaders[key] + "\r\n";
            }

            if (cookie!="")
            {
                headers2 = headers2 + "Cookie:" + cookie + "\r\n";
            }
            headers2 = (strRequesHeaders = headers2 + "\r\n");
            requestHeaders.Clear();
            return encoding.GetBytes(headers2);
        }

     

        private void SaveNetworkStream(Stream toStream)
        {
            SaveNetworkStream(toStream,true);
        }
        /// <summary>
        /// 保存流
        /// </summary>
        /// <param name="toStream"></param>
        /// <param name="showProgress"></param>
        private void SaveNetworkStream(Stream toStream,bool showProgress)
        {
            NetworkStream NetStream = clientSocket.GetStream();
            byte[] buffer2 = new byte[10245];
            int count4 = 0;
            int startIndex = 0;
            MemoryStream ms = new MemoryStream();
            for (int i = 0; i < 3; i++)
            {
                count4 = NetStream.Read(buffer2,0,500);
                ms.Write(buffer2, 0, count4);
            }

            if (ms.Length==0)
            {
                NetStream.Close();
                throw new Exception("远程服务器没有响应");
            }
            buffer2 = ms.GetBuffer();
            count4 = (int)ms.Length;
            GetResponseHeader(buffer2,out startIndex);
            count4 -= startIndex;
            toStream.Write(buffer2,startIndex,count4);

            DownloadEventArgs e = default(DownloadEventArgs);
            if (responseHeaders["Content-Length"]!=null)
            {
                e.totalBytes = long.Parse(responseHeaders["Content-Length"]);
            }
            else
            {
                e.totalBytes = 1L;
            }
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (!isCanceled)
            {
                if (showProgress)
                {
                    e.bytesReceived += count4;
                    e.ReceiveProgress = (double)e.bytesReceived / (double)e.totalBytes;
                    byte[] tempBuffer = new byte[count4];
                    Array.Copy(buffer2,startIndex,tempBuffer,0,count4);
                    e.receivedBuffer = tempBuffer;
                    double t = ((double)timer.ElapsedMilliseconds + 0.1) / 1000.0;
                    e.receiveSpend = (double)e.bytesReceived / t;
                    startIndex = 0;
                    if (this.DownloadProgressChanged!=null)
                    {
                        this.DownloadProgressChanged(this,e);
                    }
                }
                count4 = NetStream.Read(buffer2,0,buffer2.Length);
                toStream.Write(buffer2,0,count4);
                if (count4<=0)
                {
                    break;
                }
            }
            timer.Stop();
            if (responseHeaders["Content-Length"]!=null)
            {
                toStream.SetLength(long.Parse(responseHeaders["Content-Length"]));
            }
            toStream.Position = 0L;
            NetStream.Close();
            clientSocket.Close();
        }
        /// <summary>
        /// 获取响应头
        /// </summary
        /// <param name="buffer"></param>
        /// <param name="startIndex"></param>
        private void GetResponseHeader(byte[] buffer,out int startIndex)
        {
            requestHeaders.Clear();
            string html = encoding.GetString(buffer);
            StringReader sr = new StringReader(html);
            int start = html.IndexOf("\r\n\r\n") + 4;
            strResponseHeaders = html.Substring(0,start);
            if (sr.Peek()>0)
            {
                string line3 = sr.ReadLine();
                Match M4 = Regex.Match(line3,"\\d\\d\\d");
                if (M4.Success)
                {
                    statusCode = int.Parse(M4.Value);
                }
            }

            while (sr.Peek()>-1)
            {
                string line2 = sr.ReadLine();
                if (line2!="")
                {
                    Match M3 = Regex.Match(line2, "([^:]+):(.+)");
                    if (M3.Success)
                    {
                        try
                        {
                            responseHeaders.Add(M3.Groups[1].Value.Trim(),M3.Groups[2].Value.Trim());
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        if (M3.Groups[1].Value=="Set-Cookie")
                        {
                            M3 = Regex.Match(M3.Groups[2].Value, "[^=]+=[^;]+");
                            cookie = cookie + M3.Value.Trim() + ";";
                        }
                    }
                    continue;
                }
                if (responseHeaders["Content-Length"]==null&&sr.Peek()>-1)
                {
                    line2 = sr.ReadLine();
                    Match M = Regex.Match(line2, "~[0-9a-fA-F]{1,15}");
                    if (M.Success)
                    {
                        int length = int.Parse(M.Value, NumberStyles.AllowHexSpecifier);
                        responseHeaders.Add("Content-Length", length.ToString());
                        strResponseHeaders = strResponseHeaders + M.Value + "\r\n";
                    }
                }
                break;
            }
            sr.Close();
            startIndex = encoding.GetBytes(strRequesHeaders).Length;
        }


       

    }


    //声明委托
    public delegate void WebClientUploadEvent(object sender,UploadEventArgs e);
    public delegate void WebClientDownloadEvent(object sender, DownloadEventArgs e);

    public struct UploadEventArgs
    {
        public long totalBytes;

        public long bytesSent;

        public double sendProgress;

        public double sendSpeed;
    }
    public struct DownloadEventArgs
    {
        public long totalBytes;
        public long bytesReceived;
        public double ReceiveProgress;
        public byte[] receivedBuffer;
        public double receiveSpend;
    }
}

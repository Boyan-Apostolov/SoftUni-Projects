using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        private static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        private const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 12345);
            tcpListener.Start();
            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
            }
        }

        private static async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                var length = await stream.ReadAsync(buffer, 0, buffer.Length);

                string requestString =
                    Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine(requestString);
                
                var sid = Guid.NewGuid().ToString();
                var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
                
                if (match.Success)
                {
                    sid = match.Value.Substring(4);
                }

                if (!SessionStorage.ContainsKey(sid))
                {
                    SessionStorage.Add(sid,0);
                }

                SessionStorage[sid]++;

                Console.WriteLine(sid);

                string html = $"<h1>Hello from NikiServer {DateTime.Now} for the {SessionStorage[sid]} time</h1>" +
                              $"<form action=/tweet method=post>" +
                              $"<input name=username /><input name=password />" +
                              $"<input type=submit /></form>" + DateTime.Now;

                string response = "HTTP/1.1 200 OK" + NewLine +
                                  "Server: NikiServer 2020" + NewLine +
                                  "Content-Type: text/html; charset=utf-8" + NewLine +
                                  // "Location: https://www.google.com" + NewLine +
                                  // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                                  //"Set-Cookie: sid=1234567890; Expires= "+ DateTime.UtcNow.AddHours(1).ToString("R") + NewLine +
                                  //$"Set-Cookie: tweetsCookie=oreojghr380jgbjrioetrjbthterji; Path=/tweets"+ NewLine +
                                  $"Set-Cookie: tweetsCookie=oreojghr380jgbjrioetrjbthterji; Path=/tweet; Max-Age= "+ (12*30*24*60*60) +NewLine +
                                  $"Set-Cookie: sid={sid}; Max-Age= " + (100 * 24 * 60 * 60) + NewLine +
                                  //"Set-Cookie: sid=1234567890; Secure;" + NewLine +
                                  //"Set-Cookie: sid=1234567890; HttpOnly;" + NewLine +
                                  "Content-Length: " + html.Length + NewLine +
                                  NewLine +
                                  html + NewLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes);

                Console.WriteLine(new string('=', 70));
            }
        }
        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}

﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        private const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 12345);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        private static async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

                string requestString =
                    Encoding.UTF8.GetString(buffer, 0, lenght);
                Console.WriteLine(requestString);

                Thread.Sleep(5000);

                string html = $"<h1>Hello from NikiServer {DateTime.Now}</h1>" +
                              $"<form action=/tweet method=post><input name=username /><input name=password />" +
                              $"<input type=submit /></form>" + DateTime.Now;

                string response = "HTTP/1.1 200 OK" + NewLine +
                                  "Server: NikiServer 2020" + NewLine +
                                  // "Location: https://www.google.com" + NewLine +
                                  "Content-Type: text/html; charset=utf-8" + NewLine +
                                  // "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                                  "Content-Lenght: " + html.Length + NewLine +
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
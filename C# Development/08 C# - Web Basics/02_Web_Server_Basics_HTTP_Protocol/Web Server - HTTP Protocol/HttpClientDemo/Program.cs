using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HttpClientDemo.Stuff;

namespace HttpClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();
            var dbContext = new BooksDbContext();
            dbContext.Database.EnsureCreated();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[10000000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length); //GET /tweets HTTP/1.1

                    //Get Type of Request "GET" "POST"
                    var typeOfRequest = (requestString.Split(' ')[0]);
                    //Get Directory for Request "/" "/books"
                    var dir = (requestString.Split(' ')[1]);
                    //Get Contents of Request "author" "title"
                    var contentsOfRequest = requestString.Split(Environment.NewLine)[requestString.Split(Environment.NewLine).Length - 1];

                    string html = String.Empty;

                    //Index page
                    if (dir == "/")
                    {
                        //Index page
                        html = $"<h1>Hello From NikiServer {DateTime.Now}</h1>" +
                               @$"<form method=post action=/books>
                                                <label for=title>Title:</label><br>
                                                <input type=text id=title name=title><br>
                                                <label for=author>Author:</label><br>
                                                <input type=text id=author name=author><br><br>
                                                <input type=submit value='Submit a book'>
                                                <a href=/books>..Books..</a>" + 
                               $"</form>";

                        if (typeOfRequest == "POST" && contentsOfRequest != "")
                        {
                            var bookId = int.Parse(contentsOfRequest.Split("=")[0]);
                            var book = dbContext.Books.Find(bookId);

                            if (book != null)
                            {
                                dbContext.Books.Remove(book);
                            }

                            dbContext.SaveChanges();
                        } //Remove book
                    }
                    else if (dir == "/books")
                    {
                        //Books page, shows the book list
                        if (typeOfRequest == "POST")
                        {
                            var title = contentsOfRequest.Split('&')[0].Split("=")[1].Replace("+", " ");
                            var author = contentsOfRequest.Split('&')[1].Split("=")[1].Replace("+", " ");
                            var book = new Book(title, author);
                            dbContext.Books.Add(book);
                            dbContext.SaveChanges();
                        }

                        html += $"<h1>Library: <form method=post action=/><input type=submit value='Go Back'/><form/> </h1>";
                        html += $"<h5>Books count: {dbContext.Books.Count()} </h5>";
                        html += new string('=', 60) + Environment.NewLine;


                        foreach (var book in dbContext.Books)
                        {
                            html += $"<article>";
                            html += $"<h4>'{book.Title}'</h4> by <h7>{book.Author}</h7> <br/> <br/>";
                            html += $"<from method=get>" +
                                    $"<input type=submit id={book.Id} name={book.Id} value='Remove'/>" +
                                    $"<form/>" +
                                    $" <br/><br/>";
                            html += new string('=', 60) + Environment.NewLine;
                            html += $"</article>";
                            html += Environment.NewLine;

                        }

                    } //save book and show books page

                    Console.WriteLine(requestString);

                    //Return response to browser with the HTML
                    string response = "HTTP/1.1 200 OK" + NewLine +
                                      "Server: NikiServer 2020" + NewLine +
                                      "Content-Type: text/html; charset=utf-8" + NewLine +
                                      "Content-Length: " + html.Length + NewLine +
                                      NewLine +
                                      html +
                                      NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                }


                Console.WriteLine(new string('=', 70));
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            Console.WriteLine(html);
        }
    }
}

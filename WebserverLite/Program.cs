/*
 * Code copied from https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server.aspx
 * All credits goes to the Author at https://codehosting.net/blog/BlogEngine/author/david.aspx
 */

using System;
using System.Collections.Generic;
using System.Net;

namespace WebserverLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://192.168.2.3:8080/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }


        static string SendResponse(HttpListenerRequest request)
        {
            var querystring = new List<string>();
            foreach (var item in request.QueryString.AllKeys)
            {
                querystring.Add(string.Format("{0}={1}", item, request.QueryString.Get(item)));
            }

            var result = string.Join(",", querystring);
            Console.WriteLine("incoming request " + result);

            return string.Format("{0} : {1}", DateTime.Now, result);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.IO;

namespace SerwisyInternetowe
{

    public class Program
    {
        public static string username {get; set;}
        public static string password {get; set;}
        public static string host {get; set;}
        public static string vhost {get; set;}
        public static string endpoint {get; set;}


        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(System.IO.File.Open("config.txt", System.IO.FileMode.Open)); 
            username = sr.ReadLine();
            password = sr.ReadLine();
            host = sr.ReadLine();
            vhost = sr.ReadLine();
            endpoint = sr.ReadLine();


            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

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
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace SerwisyInternetowe
{

    public class Program
    {
        public static string username {get; set;}
        public static string password {get; set;}
        public static string host {get; set;}
        public static string endpoint {get; set;}

        public static DatabaseCommunicator databaseCommunicator { get; set; }

        public static IHost host_;

        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(System.IO.File.Open("config.txt", System.IO.FileMode.Open)); 
            username = sr.ReadLine();
            password = sr.ReadLine();
            host = sr.ReadLine();
            endpoint = sr.ReadLine();

            string databaseConnectionString = sr.ReadLine();
            string databaseName = sr.ReadLine();
            string collectionName = sr.ReadLine();

            databaseCommunicator = new DatabaseCommunicator(databaseConnectionString, databaseName, collectionName);


            host_ = CreateHostBuilder(args).Build();
            host_.RunAsync();

            host_.Services.GetRequiredService<QueueProcessor>().StartAsync(System.Threading.CancellationToken.None);

            while (true)
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

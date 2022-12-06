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
using System.Threading;
using MongoDB.Bson;

namespace SerwisyInternetowe
{

    public class QueueProcessor : IHostedService, IDisposable
    {
        class Consumer : DefaultBasicConsumer
        {
            DatabaseCommunicator databaseCommunicator;
            public Consumer(IModel model, DatabaseCommunicator dbc) : base(model) 
            {
                databaseCommunicator = dbc;
            }
            public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
            {
                TempICis p = System.Text.Json.JsonSerializer.Deserialize<TempICis>(body.Span);
                databaseCommunicator.savePacket(p);

                Console.WriteLine("Saving: {0}" , p.ToBson());

            }
        }

        ConnectionFactory factory;
        string endpoint;
        IConnection connection = null;
        IModel channel = null;

        DatabaseCommunicator databaseCommunicator;

        public QueueProcessor(string username, string password, string host, string endpoint, DatabaseCommunicator dbc)
        {
            this.endpoint = endpoint;
            this.databaseCommunicator = dbc;

            factory = new ConnectionFactory()
            {
                UserName = username,
                HostName = host,
                Password = password,
                VirtualHost = ConnectionFactory.DefaultVHost
            };
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            try
            {
                connection = factory.CreateConnection();

                channel = connection.CreateModel();
            }
            catch(Exception e)
            {
                return Task.FromException(e);
            }

            DoWork();

            return Task.CompletedTask;

        }

        private void DoWork()
        {
            channel.BasicConsume(Program.endpoint, true, "", false, false, null, new Consumer(channel,databaseCommunicator));
            channel.QueueDeclare("deviceinputqueue", true, false, false, null);
            while(true)
            {

            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if(channel != null)
            {
                channel.Dispose();
            }
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}

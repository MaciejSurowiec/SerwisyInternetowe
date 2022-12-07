using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ;
using System.Security.Cryptography;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(System.IO.File.Open("config.txt", FileMode.Open));
            string username = sr.ReadLine();
            string password = sr.ReadLine();
            string host = sr.ReadLine();
            string port = sr.ReadLine();
            string endpoint = sr.ReadLine();
            sr.Close();
            var rng = new Random();

            var factory = new Client.ConnectionFactory()
            {
                UserName = username,
                HostName = host,
                Password = password,
                VirtualHost = ConnectionFactory.DefaultVHost,
                Port = int.Parse(port)
            };

            Guid deviceguid = Guid.NewGuid();

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(endpoint, true, false, false, null);
                    channel.BasicQos(0, 1, true);
                    while (true)
                    {
                        var properties = channel.CreateBasicProperties();
                        properties.Headers = new Dictionary<string, object>();

                        var msg = new TempICis
                        {
                            Temp = rng.Next(40),
                            cisnienie = 800 + rng.Next(400),
                            timestamp = DateTime.Now.ToBinary(),
                            guid = deviceguid
                        };

                        properties.Persistent = true;
                        ReadOnlyMemory<byte> body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(msg));
                        channel.BasicPublish("", endpoint, false, properties, body);

                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }
        }
    }
    public interface ITemperatura
    {
        int Temp { get; set; }
    }

    public interface ITimestamp
    {
        long timestamp { get; set; }
    }

    public interface IGuid
    {
        Guid guid { get; set; }
    }
    public interface ICisnienie
    {
        int cisnienie { get; set; }
    }

    public class TempICis : ICisnienie, ITemperatura, ITimestamp, IGuid
    {
        public int Temp { get; set; }
        public int cisnienie { get; set; }
        public long timestamp { get; set; }
        public Guid guid { get; set; }
    }
}

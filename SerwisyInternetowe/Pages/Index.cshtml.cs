using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SerwisyInternetowe;

namespace SerwisyInternetowe.Pages
{
    class Consumer : DefaultBasicConsumer
    {
        public Consumer(IModel model) : base(model) { }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            //Console.WriteLine((int)properties.Headers["target"]);
            //Console.WriteLine((Encoding.UTF8.GetString((byte[])properties.Headers["string"])));
            Console.WriteLine(Encoding.UTF8.GetString(body.ToArray()));
            Thread.Sleep(2000);
        }
    }

  

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<TempICis> tempArray = new List<TempICis>();

      

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            /*
            TempICis t = new TempICis();
            t.cisnienie = 1;
            t.Temp = 2;
            t.timestamp = 3;
            t.guid = new Guid();
            TempICis t1 = new TempICis();
            t1.cisnienie = 5;
            t1.Temp = 4;
            t1.timestamp = 6;
            t1.guid = t.guid;
            TempICis t2 = new TempICis();
            t2.cisnienie = 5;
            t2.Temp = 4;
            t2.timestamp = 6;
            t2.guid = t.guid;
            tempArray.Add(t);
            tempArray.Add(t1);
            tempArray.Add(t2);


            */

            var data = Program.databaseCommunicator.GetPackets();

            tempArray = data.ToList();
        }
    }
}

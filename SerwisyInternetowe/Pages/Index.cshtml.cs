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

    public class Temp
    {
        public int temp { get; set; }
        public int cisnienie { get; set; }
        public long timestamp { get; set; }
        public Guid guid { get; set; }

    }

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Temp> tempArray = new List<Temp>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Temp temp = new Temp();
            temp.cisnienie = 1;
            temp.temp = 1;
            temp.timestamp = 1;
            temp.guid = Guid.NewGuid();

            tempArray.Add(temp);

            Temp temp2 = new Temp();
            temp2.cisnienie = 2;
            temp2.temp = 2;
            temp2.timestamp = 2;
            temp2.guid = Guid.NewGuid();
            tempArray.Add(temp2);
        }
    }
}

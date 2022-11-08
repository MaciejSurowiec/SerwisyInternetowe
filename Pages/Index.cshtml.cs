using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SerwisyInternetowe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string message { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            message = "Czekam na wiadomosc...";

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://oeqjbkyk:RH-XJ7m0bLuTvxWVq8pTg_HNg6ZPanoK@rat.rmq2.cloudamqp.com/oeqjbkyk");

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                };
            }
        }
    }
}

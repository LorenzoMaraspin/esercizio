using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ITS.ProjectWork.Client.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ITS.ProjectWork.Client.Protocols;

namespace ITS.ProjectWork.Client.Worker
{
    public class Worker : BackgroundService
    {
        //IProtocolInterface protocol = new Mqtt("localhost");
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //AmqpSend amqp = new AmqpSend();
            BrightnessSensor sensor = new BrightnessSensor();
            while (!stoppingToken.IsCancellationRequested)
            {
                //amqp.AmqpSender();
                sensor.GetJson();
               // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}

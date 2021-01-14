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
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Scooter scooter = new Scooter("1",true,15,50,1,3);
            Http http = new Http();
            while (!stoppingToken.IsCancellationRequested)
            {
                scooter.GetJson();
                http.Send("0");
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}

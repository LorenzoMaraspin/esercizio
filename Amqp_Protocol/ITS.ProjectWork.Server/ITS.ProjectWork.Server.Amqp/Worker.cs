using ITS.ProjectWork.Server.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.ProjectWork.Server.Amqp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IAmqpService _service;
        private IScooterService _serviceScooter;
        private ISensorService _serviceSensor;

        public Worker(ILogger<Worker> logger, IAmqpService service, IScooterService service1, ISensorService service2)
        {
            _logger = logger;
            _service = service;
            _serviceScooter = service1;
            _serviceSensor = service2;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _service = new AmqpService("bonobo-01.rmq.cloudamqp.com",_serviceScooter,_serviceSensor);
            while (!stoppingToken.IsCancellationRequested)
            {
                _service.Get("queue_scooter");
                _service.Get("queue_sensor");
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

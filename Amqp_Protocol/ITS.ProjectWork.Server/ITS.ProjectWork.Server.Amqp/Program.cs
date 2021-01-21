using ITS.ProjectWork.Server.Data;
using ITS.ProjectWork.Server.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.ProjectWork.Server.Amqp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<ISensorService, SensorService>();
                    services.AddSingleton<IScooterRepository, ScooterRepository>();
                    services.AddSingleton<ISensorRepository, SensorRepository>();
                    services.AddSingleton<IScooterService, ScooterService>();
                    services.AddSingleton<IAmqpService, AmqpService>();
                });
    }
}

using ITS.ProjectWork.Server.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace ITS.ProjectWork.Server.Service
{
    public class AmqpService : IAmqpService
    {
        private string endpoint;
        private IScooterService _serviceScooter;
        private ISensorService _serviceSensor;

        // Parametri di configurazione, da isolare in file esterno
        private readonly string username = "eirdctez";
        private readonly string password = "m79blBxsrywuMyw3AQu19pGnyPPQ4hBw";
        private readonly string virtualhost = "eirdctez";

        /**
         * Compatibile con vers. 0.9.1 (RabbitMQ)
         */
        public AmqpService(string endpoint, IScooterService service, ISensorService service1)
        {
            this.endpoint = endpoint;
            _serviceScooter = service;
            _serviceSensor = service1;
        }
        public void Get(string queue)
        {
            var factory = new ConnectionFactory() //{ HostName = "localhost" }
            {
                HostName = endpoint,
                UserName = username,
                Password = password,
                VirtualHost = virtualhost
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    if(queue == "queue_scooter")
                    {
                        var scooter = JsonSerializer.Deserialize<Scooter>(body);
                        _serviceScooter.InsertScooter(scooter);

                    }else if(queue == "queue_sensor")
                    {
                        var sensor = JsonSerializer.Deserialize<Sensor>(body);
                        _serviceSensor.InsertSensor(sensor);
                    }
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: true,
                                     consumer: consumer);
                channel.ConfirmSelect();

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}

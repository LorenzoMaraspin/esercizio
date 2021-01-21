using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Protocols
{
    public class Amqp : IProtocolInterface
    {
        private string endpoint;
        private string queueName;

        // Parametri di configurazione, da isolare in file esterno
        private readonly string username = "eirdctez";
        private readonly string password = "m79blBxsrywuMyw3AQu19pGnyPPQ4hBw";
        private readonly string virtualhost = "eirdctez";

        /**
         * Compatibile con vers. 0.9.1 (RabbitMQ)
         */
        public Amqp(string endpoint)
        {
            this.endpoint = endpoint;
        }

        /*
         * Possibili refactoring:
         * - riutilizzare la stessa connessione per ogni invio, quindi aprirla all'avvio dell'applicazione e chiuderla al termine
         * - gestire situazioni d'errore: cosa accade se il broker non è raggiungibile?
         */
        public void Send(string queue,string data)
        {
            var factory = new ConnectionFactory() //{ HostName = "localhost" }
            {
                HostName = endpoint,
                UserName = username,
                Password = password,
                VirtualHost = virtualhost
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    /*channel.QueueDeclare(queue: queue,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);*/

                    var body = Encoding.UTF8.GetBytes(data);
                    channel.ConfirmSelect();
                    channel.BasicPublish(exchange: "exchange_esercizio",
                                         routingKey: queue,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine("Sent {0}", data);
                }
            }
        }
        public void Get(string topic)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MQTTnet;
using MQTTnet.Client;
using System.Threading;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using ITS.ProjectWork.Client.Model;
using System;
using System.Text;

namespace ITS.ProjectWork.Client.Protocols
{
    public class Mqtt :IProtocolInterface
    {
        private string endpoint;
        private string topic;

        public Mqtt(string endpoint)
        {
            this.endpoint = endpoint;
        }
        /*
         * Possibili refactoring:
         * - riutilizzare la stessa connessione per ogni invio, quindi aprirla all'avvio dell'applicazione e chiuderla al termine
         * - gestire situazioni d'errore: cosa accade se il broker non è raggiungibile?
         */

        public void Send(string topic, string data)
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
            .WithTcpServer(endpoint, 1883) // Port is optional
            .Build();

            mqttClient.ConnectAsync(options).GetAwaiter().GetResult();

            var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(data)
            .Build();

            var result = mqttClient.PublishAsync(message, CancellationToken.None).GetAwaiter().GetResult();

            Console.Out.WriteLine(result.ReasonString);

            mqttClient.Dispose();
        }
        
        public void Get(string topic)
        {
            
            var factory = new MqttFactory();
            var client = factory.CreateMqttClient();
            var clientOptions = new MqttClientOptions
            {
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = "127.0.0.1"
                }
            };
            client.ConnectAsync(clientOptions);
            client.SubscribeAsync(new MqttTopicFilter { Topic = topic});

            client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
            {
                //var messaggio = string.Empty;
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();
                var messaggio = (Encoding.UTF8.GetString(e.ApplicationMessage.Payload)).ToString();
                var deserialize = JsonSerializer.Deserialize<Command>(messaggio);
                Console.WriteLine(deserialize.ScooterId + " " + deserialize.MaxSpeed + " ");
              });
        }
    }
}

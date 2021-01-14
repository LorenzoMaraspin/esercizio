using System;
using MQTTnet;
using MQTTnet.Client;
using System.Text;
using System.Threading;
using MQTTnet.Client.Options;

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
 
        public async void Send(string topic, string data)
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

        public void Get(string data)
        {
            throw new NotImplementedException();
        }
    }
}

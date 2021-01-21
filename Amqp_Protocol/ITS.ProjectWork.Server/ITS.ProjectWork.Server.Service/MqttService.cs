using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.ProjectWork.Server.Service
{
    public class MqttService : IMqttService
    {
        private string _endpoint;
        public MqttService(string endpoint)
        {
            _endpoint = endpoint;
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
            client.SubscribeAsync(new MqttTopicFilter { Topic = "Test/#" });

            client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
            {
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();
            });
        }


        public async void Send(string topic, string data)
        {

        }
    }
}

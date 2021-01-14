using ITS.ProjectWork.Client.Protocols;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Model
{
    public class TopicSend
    {
        IProtocolInterface protocol = new Mqtt("localhost");
        
        Scooter scooter = new Scooter(); 
        Sensor sensors = new Sensor();
        BatterySensor batterySensor = new BatterySensor();
        BrightnessSensor brightnessSensor = new BrightnessSensor();
        GpsSensor gpsSensor = new GpsSensor();
        SpeedSensor speedSensor = new SpeedSensor();

        public void Topic()
        {
            string topicScooter = "Es/" + scooter.ScooterId + "/visualize";
            string topicSensorBattery = "Es/" + scooter.ScooterId + "/battery";
            string topicSensorLight = "Es/" + scooter.ScooterId + "/light";
            string topicSensorSpeed = "Es/" + scooter.ScooterId + "/speed";
            string topicSensorLocation = "Es/" + scooter.ScooterId + "/location";

            var payload = scooter.GetJson();
            var payloadSensorBattery = batterySensor.GetJson();
            var payloadBrightnessSensor = brightnessSensor.GetJson();
            var payloadGpsSensor = gpsSensor.GetJson();
            var payloadSpeedSensor = speedSensor.GetJson();

            protocol.Send(topicScooter, payload);
            protocol.Send(topicSensorBattery, payloadSensorBattery);
            protocol.Send(topicSensorLight, payloadBrightnessSensor);
            protocol.Send(topicSensorLocation, payloadGpsSensor);
            protocol.Send(topicSensorSpeed, payloadSpeedSensor);
        }
    }
}

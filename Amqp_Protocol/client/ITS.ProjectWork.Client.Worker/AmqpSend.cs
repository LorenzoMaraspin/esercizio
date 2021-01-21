using ITS.ProjectWork.Client.Model;
using ITS.ProjectWork.Client.Protocols;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Client.Worker
{
    public class AmqpSend
    {
        IProtocolInterface protocol = new Amqp("bonobo-01.rmq.cloudamqp.com");

        Scooter scooter = new Scooter();
        BatterySensor batterySensor = new BatterySensor();
        BrightnessSensor brightnessSensor = new BrightnessSensor();
        GpsSensor gpsSensor = new GpsSensor();
        SpeedSensor speedSensor = new SpeedSensor();

        public void AmqpSender()
        {
            var payload = scooter.GetJson();
            var payloadSensorBattery = batterySensor.GetJson();
            var payloadBrightnessSensor = brightnessSensor.GetJson();
            var payloadGpsSensor = gpsSensor.GetJson();
            var payloadSpeedSensor = speedSensor.GetJson();

            protocol.Send("queue_scooter", payload);
            protocol.Send("queue_sensor", payloadSpeedSensor);
            protocol.Send("queue_sensor", payloadGpsSensor);
            protocol.Send("queue_sensor", payloadBrightnessSensor);
            protocol.Send("queue_sensor", payloadSensorBattery);
        }
    }
}

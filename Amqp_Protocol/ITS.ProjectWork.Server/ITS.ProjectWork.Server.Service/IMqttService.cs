using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Service
{
    public interface IMqttService
    {
        void Send(string data, string topic);
        void Get(string topic);
    }
}

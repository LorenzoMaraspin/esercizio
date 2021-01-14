using System;

namespace ITS.ProjectWork.Client.Protocols
{
    public interface IProtocolInterface
    {
        void Send(string data, string topic);
        void Get(string data);
    }
}

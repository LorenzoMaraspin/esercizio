using System;

namespace ITS.ProjectWork.Client.Protocols
{
    public interface IProtocolInterface
    {
        void Send(string queue,string data);
        void Get(string topic);
    }
}

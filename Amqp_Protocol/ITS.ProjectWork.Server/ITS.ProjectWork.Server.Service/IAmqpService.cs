using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Service
{
    public interface IAmqpService
    {
        void Get(string queue);
    }
}

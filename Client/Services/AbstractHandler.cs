﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Services
{
    abstract class AbstractHandler<T>
    {
        public abstract T Answer { get; }
        public abstract void SendMessageToSocket();
        public abstract void RecieveMessageFromSocket();
    }
}
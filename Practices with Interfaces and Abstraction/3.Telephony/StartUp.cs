﻿using System.Security.Cryptography.X509Certificates;
using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();

        }
    }
}
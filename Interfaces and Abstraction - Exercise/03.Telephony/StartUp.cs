using Telephony.Core.Interfaces;
using Telephony.IO;
using Telephony.IO.Core;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
engine.Run();
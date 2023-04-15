using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private  IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;  
            this.writer = writer;
        }
        public void Run()
        {
            string[] inputNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] inputUrls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;

            foreach (var phoneNumber in inputNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    callable = new Smartphone();
                }
                else
                {
                    callable = new StationaryPhone();
                }

                try
                {
                    writer.WriteLine(callable.Call(phoneNumber));
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);

                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in inputUrls)
            {
                try
                {
                    writer.WriteLine(browsable.Browse(url));
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);

                }
            }

        }
    }
}

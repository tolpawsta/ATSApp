using ATSCore;
using ATS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtsable ats = Configuration.GetAts;
            IBillingable billingSystem = Configuration.GetBilling;
            ITerminalable terminal = Configuration.GetTerminal;
            IPortable port = Configuration.GetPort;
            ISubscriber johnSmith= ats.Subscribe(new Client("John", "Smith"));
            ats.Subscribe(new Client("Tomas", "Anderson"));
            ats.Subscribe(new Client("Pifia", "Oracle"));


            //ats.Start();
            terminal.Connect(port);

        }
    }
}

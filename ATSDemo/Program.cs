using ATSCore;
using ATS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Impl;

namespace ATSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = Configuration.GetManager;
            IPort port1 = manager.GetPort(37544);
            IPort port2 = manager.GetPort(37529);
            IPort port3 = manager.GetPort(37525);
            IList<IPort> ports = new List<IPort>() { port1, port2,port3};
            ITerminal terminal1 = manager.GetTerminal(port1);
            ITerminal terminal2 = manager.GetTerminal(port2);
            ITerminal terminal3 = manager.GetTerminal(port3);
            IList<ITerminal> terminals = new List<ITerminal>() { terminal1, terminal2,terminal3 };
            IBilling billingSystem = manager.GetBillingSystem();
            IAts ats = manager.GetAts(terminals,ports,billingSystem);
            
            
            
            ISubscriber johnSmith= ats.ConcludeContractWith(new Person("John", "Smith"));
           ISubscriber tomasAnderson=ats.ConcludeContractWith(new Person("Tomas", "Anderson"));
           ISubscriber pifiaOracle= ats.ConcludeContractWith(new Person("Pifia", "Oracle"));
            ITerminal terminalJS = johnSmith.Terminal;
            ITerminal terminalTA = tomasAnderson.Terminal;
            ITerminal terminalPO = pifiaOracle.Terminal;


            

        }
    }
}

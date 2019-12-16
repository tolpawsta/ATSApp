﻿using ATSCore;
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
            IAts ats = manager.GetAts;
            IBilling billingSystem = manager.GetBillingSystem;
            ITerminal terminal = manager.GetTerminal;
            IPort port = manager.GetPort;
            ISubscriber johnSmith= ats.ConcludeContractWith(new Person("John", "Smith"));
            ats.ConcludeContractWith(new Person("Tomas", "Anderson"));
            ats.ConcludeContractWith(new Person("Pifia", "Oracle"));


            //ats.Start();
            terminal.Connect(port);

        }
    }
}

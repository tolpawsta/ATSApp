using ATSCore;
using ATS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Impl;
using ATSCore.Interfaces;
using BillingSystem.Impl;
using ATSDemo.Impl;

namespace ATSDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var manager = Configuration.GetManager(new DependencyManager());
            ITariffPlan tariffPlan = manager.GetTariffPlan(20);
            IContract contractA1 = manager.GetContract(tariffPlan,phoneNumber: 37544);
            IContract contractMTS = manager.GetContract(tariffPlan,phoneNumber: 37529);
            IContract contractLife = manager.GetContract(tariffPlan,phoneNumber: 37525);

            IList<IPort> ports = new List<IPort>() { 
                manager.GetPort(),
                manager.GetPort(),
                manager.GetPort()};
            IList<ITerminal> terminals = new List<ITerminal>() { 
                manager.GetTerminal(), 
                manager.GetTerminal(),
                manager.GetTerminal() };
            IBilling billingSystem = manager.GetBillingSystem(
                new List<IContract>() { 
                    contractA1, 
                    contractLife, 
                    contractMTS });

            IAts ats = manager.GetAts(terminals,ports,billingSystem);
            ISubscriber johnSmith= ats.ConcludeContractWith(new Person("John", "Smith"));
           ISubscriber tomasAnderson=ats.ConcludeContractWith(new Person("Tomas", "Anderson"));
           ISubscriber pifiaOracle= ats.ConcludeContractWith(new Person("Pifia", "Oracle"));

            johnSmith.Call(37529);


            

        }
    }
}

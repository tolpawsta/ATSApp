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
        private static decimal CashToAccount = 10m;
        private static string LineSeparator = Environment.NewLine + "===========================================================================" + Environment.NewLine;
        static void Main(string[] args)
        {
            #region Initialization
            var manager = Configuration.GetManager(new DependencyManager());
            ITariffPlan tariffPlan = manager.GetTariffPlan(0.5m);
            IContract contractA1 = manager.GetContract(tariffPlan, phoneNumber: 37544);
            IContract contractMTS = manager.GetContract(tariffPlan, phoneNumber: 37529);
            IContract contractLife = manager.GetContract(tariffPlan, phoneNumber: 37525);
            IViewable view = manager.GetView();
            IList<IPort> ports = new List<IPort>() {
                manager.GetPort(),
                manager.GetPort(),
                manager.GetPort()};
            IList<ITerminal> terminals = new List<ITerminal>() {
                manager.GetTerminal(view),
                manager.GetTerminal(view),
                manager.GetTerminal(view) };
            IBilling billingSystem = manager.GetBillingSystem(
                new List<IContract>() {
                    contractA1,
                    contractLife,
                    contractMTS });
            IAts ats = manager.GetAts(terminals, ports, billingSystem);
            ISubscriber johnSmith = ats.ConcludeContractWith(new Person("John", "Smith"));
            ISubscriber tomasAnderson = ats.ConcludeContractWith(new Person("Tomas", "Anderson"));
            ISubscriber pifiaOracle = ats.ConcludeContractWith(new Person("Pifia", "Oracle"));
            #endregion
            #region 1. not enough funds in the account
            view.Show("1. not enough funds in the account");
            johnSmith.Call(37529);
            view.Show(LineSeparator);
            #endregion

            #region Add cash to the account
            view.Show("Add cash to the account");
            johnSmith.AccountMoney = CashToAccount;
            view.Show(LineSeparator);
            #endregion

            #region 2. on target number not enough funds in the account
            view.Show("2. on target number not enough funds in the account");
            johnSmith.Call(37529);
            view.Show(LineSeparator);
            #endregion

            #region Add cash to the accounts
            view.Show($"Add cash to the accounts ({tomasAnderson.FullName},{pifiaOracle.FullName})");
            tomasAnderson.AccountMoney = CashToAccount;
            pifiaOracle.AccountMoney = CashToAccount;
            view.Show(LineSeparator);
            #endregion

            #region  Call allowed between johnSmith and pifiaOracle
            view.Show($"3. Call allowed between {johnSmith.FullName} and {pifiaOracle.FullName}");
            johnSmith.Call(37529);
            pifiaOracle.Answer();
            // tomasAnderson call to pifiaOracle
            view.Show(LineSeparator);
            #endregion

            #region 4. tomasAnderson call to the pifiaOracle but pifiaOracle is busy
            view.Show($"4. {tomasAnderson.FullName} call to the {pifiaOracle.FullName}");
            tomasAnderson.Call(pifiaOracle);
            view.Show(LineSeparator);
            pifiaOracle.Reject();
            #endregion

            #region 5. tomasAnderson call to the pifiaOracle second attempt (drop call)
            view.Show($"5. {tomasAnderson.FullName} call to the {pifiaOracle.FullName}");
            tomasAnderson.Call(pifiaOracle);
            pifiaOracle.Drop();
            view.Show(LineSeparator);
            #endregion
            #region 6. tomasAnderson call to the pifiaOracle third attempt (answer call)
            view.Show($"6. {tomasAnderson.FullName} call to the {pifiaOracle.FullName}");
            tomasAnderson.Call(pifiaOracle);
            pifiaOracle.Answer();
            tomasAnderson.Reject();
            view.Show(LineSeparator);
            #endregion

            #region 7. tomasAnderson call to the pifiaOracle third attempt (answer call again)
            view.Show($"7. {tomasAnderson.FullName} call to the {pifiaOracle.FullName}");
            tomasAnderson.Call(pifiaOracle);
            pifiaOracle.Answer();
            pifiaOracle.Reject();
            view.Show(LineSeparator);
                     
            view.Show(billingSystem.GetSubscriberBy(37429));
            view.Show(LineSeparator);

            view.Show(billingSystem.GetAllCallFrom(pifiaOracle));
            view.Show(LineSeparator);

            view.Show(billingSystem.GetAllSubscriberInComingCalls(pifiaOracle));
            view.Show(LineSeparator);


        }
    }
}

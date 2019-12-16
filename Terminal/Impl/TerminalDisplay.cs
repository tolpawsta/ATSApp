using ATSCore;
using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Impl
{
    class TerminalDisplay : IViewable
    {
        public void Show(string message)
        {
            Console.WriteLine(message);
        }

        public void Show(IEnumerable<CallInfo> calls)
        {
            calls.ToList().ForEach(Console.WriteLine);
        }

        public void Show(IEnumerable<ISubscriber> subscribers)
        {
            subscribers.ToList().ForEach(Console.WriteLine);
        }
    }
}

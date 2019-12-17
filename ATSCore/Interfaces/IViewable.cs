using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore.Interfaces
{
    public interface IViewable
    {
        void Show(string message);
        void Show(IEnumerable<CallInfo> calls);
        void Show(ISubscriber subscriber);
        void Show(IEnumerable<ISubscriber> subscribers);
        void Stop();
    }
}

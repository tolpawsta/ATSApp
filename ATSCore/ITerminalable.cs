using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface ITerminalable
    {

        void Connect(IPortable port);
        void Call(string phoneNumber);
        void Reject();
        void Answer();
    }
}

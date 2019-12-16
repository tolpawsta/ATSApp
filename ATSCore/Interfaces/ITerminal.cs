using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface ITerminal
    {
        TerminalState State { get; set; }
        IPort Port { get; set; }
        void Connect(IPort port);
        void Call(int phoneNumber);
        void Reject();
        void Answer();
        void Drop();

    }

    
}

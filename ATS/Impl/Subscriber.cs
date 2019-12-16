using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Impl
{
    public class Subscriber : ISubscriber
    {
        Person client;
        public string FullName => throw new NotImplementedException();

        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface ISubscriber
    {
        string FullName { get; }
        string PhoneNumber { get; set; }

    }
}

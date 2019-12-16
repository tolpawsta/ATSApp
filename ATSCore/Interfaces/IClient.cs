using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface IClient
    {
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
    }
}

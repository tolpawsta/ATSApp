using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
   public class Client : IClientable
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => new StringBuilder().Append(FirstName).Append(" ").Append(LastName).ToString();

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

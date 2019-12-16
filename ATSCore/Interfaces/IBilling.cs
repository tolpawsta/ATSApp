﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface IBilling
    {
        IList<ISubscriber> subscribers { get; }

        ISubscriber GetSubscriberBy(int sourcePhoneNumber);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public static class Configuration
    {
        public static IDependancyManager GetManager(IDependancyManager manager) => manager;

    }
}

using ATSCore;
using ATSCore.EntityStates;
using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore.Controllers
{
   public class CallController 
    {

        public static bool CheckPermissionToCall(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public static bool CheckStatePortsSubscribers(ISubscriber subscriber,ISubscriber targetSubscriber)
        {
            IPort targetPort = targetSubscriber.Port;
            bool isPortFree = true;
            if (targetPort.State == PortState.Busy)
            {
                subscriber.Port.CallResponce("The subscriber you are calling is busy.");
                isPortFree= false;
            }
            else if (targetPort.State == PortState.Disconnected)
            {
                subscriber.Port.CallResponce("The subscribers terminal you are calling is off or offline.");
               isPortFree= false;
            }
            return isPortFree;
        }
    }
}

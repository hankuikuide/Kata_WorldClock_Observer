using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public class ConcreteClockSubject:AbstractSubject
    {

        public static ConcreteClockSubject newInstance()
        {
            return new ConcreteClockSubject();
        }

        public override void setUtcTime(DateTime utcTime)
        {
            base.utcTime = utcTime;

            base.notify();
        }


    }
}

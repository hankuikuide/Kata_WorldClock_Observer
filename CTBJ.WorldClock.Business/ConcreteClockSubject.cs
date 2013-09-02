using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public class ConcreteClockSubject:AbstractSubject
    {

        public override void setUTCTime(DateTime utcTime)
        {
            base.utcTime = utcTime;

            base.notify();
        }


    }
}

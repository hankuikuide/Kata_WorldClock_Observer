using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public class ConcreteCityOberver:AbstractObserver
    {

        public ConcreteCityOberver(string city,int utc):base(city,utc)
        {

        }

        public override void autoUpdate(DateTime utcTime)
        {

            base.time=utcTime.AddHours(base.utc);

            base.time = new DST().adjust(base.city,base.time);

            Console.WriteLine("the time of city:{0} is {1}",base.city,base.time);
        }
    }
}

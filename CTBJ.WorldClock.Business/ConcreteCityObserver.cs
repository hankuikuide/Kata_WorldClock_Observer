using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public class ConcreteCityObserver:AbstractObserver
    {

        public ConcreteCityObserver(string city,int utc):base(city,utc)
        {

        }


        public static ConcreteCityObserver newInstance(string city, int utc)
        {
            return new ConcreteCityObserver(city, utc);
        }

        public override void syncWithTimeServer(DateTime utcTime)
        {

            base.time=utcTime.AddHours(base.utc);

            base.time = DST.adjust(base.city,base.time);

            Console.WriteLine("the time of city:{0} is {1}",base.city,base.time);
        }
    }
}

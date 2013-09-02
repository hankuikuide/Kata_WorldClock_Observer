using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    class DST
    {
        private DateTime begin;

        private DateTime end;
      
        public DST()
        {           
        }

        /// <summary>
        /// special city adjust
        /// </summary>
        /// <param name="city"></param>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public DateTime adjust(string city, DateTime currentTime)
        {
            DateTime time;
            switch (city)
            {
                case "London":
                    this.begin = DateTime.Parse(currentTime.Year + "-3-31");
                    this.end = DateTime.Parse(currentTime.Year + "-10-27");
                    time = this.getDSTTime(currentTime);
                    break;
                case "NewYork":
                    this.begin = DateTime.Parse(currentTime.Year + "-3-10");
                    this.end = DateTime.Parse(currentTime.Year + "-11-3");
                    time = this.getDSTTime(currentTime);
                    break;
                default:
                    time = currentTime;
                    break;
            }

            return time;
        }

        private DateTime getDSTTime(DateTime time)
        {
            if (time >= this.begin && time <= this.end)
            {
                 time =time.AddHours(1);
            }

            return time;
        }
    }
}

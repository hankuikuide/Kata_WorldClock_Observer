using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    static class DST
    {
        private static DateTime begin;

        private static DateTime end;
      

        /// <summary>
        /// special city adjust
        /// </summary>
        /// <param name="city"></param>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public static DateTime adjust(string city, DateTime currentTime)
        {
            DateTime time;
            switch (city)
            {
                case "London":
                    begin = DateTime.Parse(currentTime.Year + "-3-31");
                    end = DateTime.Parse(currentTime.Year + "-10-27");
                    time = getDSTTime(currentTime);
                    break;
                case "NewYork":
                    begin = DateTime.Parse(currentTime.Year + "-3-10");
                    end = DateTime.Parse(currentTime.Year + "-11-3");
                    time = getDSTTime(currentTime);
                    break;
                default:
                    time = currentTime;
                    break;
            }

            return time;
        }

        private static DateTime getDSTTime(DateTime time)
        {
            if (time >= begin && time <= end)
            {
                 time =time.AddHours(1);
            }

            return time;
        }
    }
}

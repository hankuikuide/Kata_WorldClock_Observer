﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public abstract class AbstractObserver
    {
        protected string city;
        protected int utc;

        //for easy test ,change protected to public 
        protected DateTime time;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="city"> city name </param>
        /// <param name="utc">time difference between utc and Local </param>
        public AbstractObserver(string city,int utc )
        {
            this.city = city;
            this.utc = utc;
        }


        /// <summary>
        /// manully adjust time, and notity the subject with utcTime
        /// </summary>
        /// <param name="clock">notity the subject with utcTime</param>
        /// <param name="time"></param>
        public void adjustTime(ConcreteClockSubject clock, DateTime time)
        {
            clock.setUtcTime(time.AddHours(-this.utc));
        }

        public abstract void syncWithTimeServer(DateTime utcTime);

        public DateTime GetTime()
        {
            return time;
        }
    }
}

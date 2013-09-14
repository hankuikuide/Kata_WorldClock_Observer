using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public class ConcreteClockSubject
    {
        protected DateTime utcTime;
        private List<AbstractObserver> observers = new List<AbstractObserver>();

        public List<AbstractObserver> Observers
        {
            get { return observers; }           
        }

        public static ConcreteClockSubject newInstance()
        {
            return new ConcreteClockSubject();
        }

        public void setUtcTime(DateTime utcTime)
        {
            this.utcTime = utcTime;

            notify();
        }


        public void attach(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        protected void notify()
        {
            foreach (var observer in observers)
            {
                observer.syncWithTimeServer(this.utcTime);
            }
        }
    }
}

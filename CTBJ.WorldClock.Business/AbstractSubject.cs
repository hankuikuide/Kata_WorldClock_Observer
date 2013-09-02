using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    public abstract class AbstractSubject
    {
        protected DateTime utcTime;

        private List<AbstractObserver> observers = new List<AbstractObserver>();

        public List<AbstractObserver> Observers
        {
            get { return observers; }           
        }

        public void attach(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        public void detach(AbstractObserver observer)
        {
            observers.Remove(observer);

        }

        public abstract void setUTCTime(DateTime utcTime);

        protected void notify()
        {
            foreach (var observer in observers)
            {
                observer.autoUpdate(this.utcTime);
            }
        }
    }
}

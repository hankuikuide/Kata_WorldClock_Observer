using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTBJ.WorldClock.Business
{
    // Need not to have an abstractSubject since there is only one concrete subject. 
    // Only when there are two or more concrete subjects, we can extract an
    // abstract class.
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

        public abstract void setUtcTime(DateTime utcTime);

        protected void notify()
        {
            foreach (var observer in observers)
            {
                observer.syncTimeServer(this.utcTime);
            }
        }
    }
}

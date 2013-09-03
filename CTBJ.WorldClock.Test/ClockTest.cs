using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTBJ.WorldClock.Business;

namespace CTBJ.WorldClock.Test
{
    [TestClass]
    public class ClockTest
    {
        AbstractObserver Beijing = ConcreteCityObserver.getInstance("Beijing", 8);
        AbstractObserver London = ConcreteCityObserver.getInstance("London", 0);
        AbstractObserver Moscow = ConcreteCityObserver.getInstance("Moscow", 4);
        AbstractObserver Sydney = ConcreteCityObserver.getInstance("Sydney", 10);
        AbstractObserver NewYork = ConcreteCityObserver.getInstance("NewYork", -5);

        [TestMethod]
        public void ShowTimeTest()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-9-2 8:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 1:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 4:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 10:00:00"));
            expected.Add(DateTime.Parse("2013-9-1 20:00:00"));

            ConcreteClockSubject clock = ConcreteClockSubject.getInstance();

            attachObervers(clock);

            clock.setUTCTime(DateTime.Parse("2013-9-2 0:00:00"));

            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

        }

        private void attachObervers(ConcreteClockSubject clock)
        {
            clock.attach(Beijing);
            clock.attach(London);
            clock.attach(Moscow);
            clock.attach(Sydney);
            clock.attach(NewYork);
        }

        [TestMethod]
        public void adjustTimeText()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-9-2 9:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 2:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 5:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 11:00:00"));
            expected.Add(DateTime.Parse("2013-9-1 21:00:00"));

            ConcreteClockSubject clock = ConcreteClockSubject.getInstance();

            attachObervers(clock);

            clock.setUTCTime(DateTime.Parse("2013-9-2 0:00:00"));
            Beijing.adjustTime(clock, DateTime.Parse("2013-9-2 9:00:00"));
            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

            London.adjustTime(clock, DateTime.Parse("2013-10-28 0:00:00"));
        }

        [TestMethod]
        public void endDSTTimeText()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-10-28 8:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 0:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 4:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 10:00:00"));
            expected.Add(DateTime.Parse("2013-10-27 20:00:00"));

            ConcreteClockSubject clock = ConcreteClockSubject.getInstance();

            attachObervers(clock);

            clock.setUTCTime(DateTime.Parse("2013-9-2 0:00:00"));
            London.adjustTime(clock, DateTime.Parse("2013-10-28 0:00:00"));
            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

        }
    }
}

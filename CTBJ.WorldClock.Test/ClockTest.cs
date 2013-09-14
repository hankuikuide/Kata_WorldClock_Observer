using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CTBJ.WorldClock.Business;
using NUnit.Framework;


namespace CTBJ.WorldClock.Test
{
    [TestFixture]
    public class ClockTest
    {
        private AbstractObserver Beijing;
        private AbstractObserver London;
        private AbstractObserver Moscow;
        private AbstractObserver Sydney;
        private AbstractObserver NewYork;
        private ConcreteClockSubject clock;

        [SetUp]
        public void Init()
        {
            Beijing = ConcreteCityObserver.newInstance("Beijing", 8);
            London = ConcreteCityObserver.newInstance("London", 0);
            Moscow = ConcreteCityObserver.newInstance("Moscow", 4);
            Sydney = ConcreteCityObserver.newInstance("Sydney", 10);
            NewYork = ConcreteCityObserver.newInstance("NewYork", -5);

            clock = ConcreteClockSubject.newInstance();

            attachObervers();
            clock.setUtcTime(DateTime.Parse("2013-9-2 0:00:00"));
        }

        [Test]
        public void ShowTimeTest()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-9-2 8:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 1:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 4:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 10:00:00"));
            expected.Add(DateTime.Parse("2013-9-1 20:00:00"));

            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

        }

        private void attachObervers()
        {
            clock.attach(Beijing);
            clock.attach(London);
            clock.attach(Moscow);
            clock.attach(Sydney);
            clock.attach(NewYork);
        }

        [Test]
        public void adjustTimeText()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-9-2 9:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 2:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 5:00:00"));
            expected.Add(DateTime.Parse("2013-9-2 11:00:00"));
            expected.Add(DateTime.Parse("2013-9-1 21:00:00"));

            Beijing.adjustTime(clock, DateTime.Parse("2013-9-2 9:00:00"));
            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

            London.adjustTime(clock, DateTime.Parse("2013-10-28 0:00:00"));
        }

        [Test]
        public void endDSTTimeText()
        {
            List<DateTime> expected = new List<DateTime>();
            expected.Add(DateTime.Parse("2013-10-28 8:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 0:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 4:00:00"));
            expected.Add(DateTime.Parse("2013-10-28 10:00:00"));
            expected.Add(DateTime.Parse("2013-10-27 20:00:00"));

            London.adjustTime(clock, DateTime.Parse("2013-10-28 0:00:00"));
            for (int i = 0; i < clock.Observers.Count; i++)
            {
                Assert.AreEqual(expected[i], clock.Observers[i].time);
            }

        }
    }
}

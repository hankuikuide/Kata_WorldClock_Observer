using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTBJ.WorldClock.Business;

namespace CTBJ.WorldClock.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractObserver Beijing = new ConcreteCityOberver("Beijing",8);
            AbstractObserver London = new ConcreteCityOberver("London", 0);
            AbstractObserver Moscow = new ConcreteCityOberver("Moscow", 4);
            AbstractObserver Sydney = new ConcreteCityOberver("Sydney", 10);
            AbstractObserver NewYork = new ConcreteCityOberver("NewYork", -5);

            ConcreteClockSubject clock = new ConcreteClockSubject();

            clock.attach(Beijing);
            clock.attach(London);
            clock.attach(Moscow);
            clock.attach(Sydney);
            clock.attach(NewYork);

            clock.setUTCTime(DateTime.Parse("2013-9-2 0:00:00"));
            Console.WriteLine();

            Beijing.adjustTime(clock, DateTime.Parse("2013-9-2 9:00:00"));
            Console.WriteLine();

            London.adjustTime(clock, DateTime.Parse("2013-10-28 0:00:00"));

            Console.ReadKey();


        }
    }
}

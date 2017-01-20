namespace Homework
{
    using System;
    using System.Threading;

    public delegate void TimerEventHandler();

    public class TimerEvent
    {
        private int interval;
        private int times;

        public TimerEvent(int intervalSec,int executingTimes)
        {
            this.Interval = intervalSec;
            this.ExecuteTimes = executingTimes;

        }

        public event TimerEventHandler Methods;

        public int ExecuteTimes
        {
            get
            {
                return this.times;
            }

            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("The method must be executed at least one time");
                }

                this.times = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("interval must be at least 1 sec");
                }

                this.interval = value * 1000;
            }
        }

        public void Run()
        {
            if (this.Methods != null)
            {
                while (this.ExecuteTimes >0)
                {
                    this.Methods();
                    Thread.Sleep(this.Interval);
                    this.times--;
                }
            }
        }
    }
}

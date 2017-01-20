namespace Homework
{
    using System;
    using System.Threading;

    public delegate void DelegateAct();

    public class Timer
    {
        private int interval;
        private int times;

        public Timer(int interval, int executingTimes)
        {
            this.Interval = interval;
            this.ExecuteTimes = executingTimes;
        }

        public DelegateAct Methods;


        public int ExecuteTimes
        {
            get
            {
                return this.times;
            }

            private set
            {
                if (value < 1)
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
                    throw new ArgumentException("Interval cannot be less than 1");
                }

                this.interval = value * 1000;
            }
        }

        public void Run()
        {
            while (this.ExecuteTimes > 0)
            {
                this.Methods();
                Thread.Sleep(this.Interval);
                this.times--;
            }
        }
    }
}

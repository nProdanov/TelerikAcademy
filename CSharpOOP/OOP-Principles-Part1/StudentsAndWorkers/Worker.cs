namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public Worker()
            : base()
        {

        }

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPD)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPD;
        }

        public int WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 200)
                {
                    throw new ArgumentOutOfRangeException("Worker can not live with less than 200 lv for week");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value > 12)
                {
                    throw new ArgumentOutOfRangeException("The law does not allows more than 12 hours per day");
                }

                if (value < 4)
                {
                    throw new ArgumentOutOfRangeException("Worker must not be lazy");
                }

                this.workHoursPerDay = value;
            }
        }

        public double EarnedMoneyPerHour()
        {
            var moneyPerDay = this.weekSalary / 5.0;
            return moneyPerDay / this.workHoursPerDay;
        }

        public override string ToString()
        {
            return string.Format("worker {0} earns {1:F2} lv./hour", base.ToString(), this.EarnedMoneyPerHour());
        }
    }
}

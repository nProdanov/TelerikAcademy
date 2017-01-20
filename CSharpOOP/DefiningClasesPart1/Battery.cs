namespace GSMModels
{
    using System;

    class Battery
    {
        private string model;

        private double hoursIdle;

        private double hourseTalk;

        public BatteryType BatteryType { get; set; }

        public Battery()
        {
            
        }

        public Battery(string modelName)
        {
            this.Model = modelName;
        }

        public Battery(string modelName, double idleHours, double talkHours,BatteryType typeOfbattery)
            : this(modelName)
        {
            this.HoursIdle = idleHours;
            this.HoursTalk = talkHours;
            this.BatteryType = typeOfbattery;
        }  

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value<5)
                {
                    throw new ArgumentOutOfRangeException("Hours idle must be more than 4");
                }
                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hourseTalk;
            }
            set
            {
                if (value<5)
                {
                    throw new ArgumentOutOfRangeException("Talk hours must be more than 4");
                }
                if (value>this.hoursIdle)
                {
                    throw new ArgumentException("Idle hours cannot be less than a talk hours");
                }
                this.hourseTalk = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                string k = value;
                if (value ==null)
                {
                    throw new ArgumentNullException("Model cannot be a null string");

                }
                if (value.Length<5)
                {
                    throw new ArgumentException("The model name must be more than 5 symbols");
                }
                this.model = value;
            }
        }

        public override string ToString()
        {
            
            string text = "Battery Model: " + this.Model + ", Talk Hours: " + this.HoursTalk + ", Idle Hours: " + this.HoursIdle + " " + this.BatteryType;
            return text;
        }


    }
}

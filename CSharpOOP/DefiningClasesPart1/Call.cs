namespace GSMModels
{
    using System;
    class Call
    {
        private DateTime dateTime;

        private string dialed;

        private ulong duration;

        public Call(DateTime dateTimeCall, string dialedNumber, ulong callDuration)
        {
           
            this.DateTime = dateTimeCall;
            this.DialedNumber = dialedNumber;
            this.Duration = callDuration;

        }

        
        public DateTime DateTime
        {
            get
            {
                if (this.dateTime.Equals(null))
                {
                    throw new ArgumentNullException("DateTime call is null or empty");
                }
                return this.dateTime;
            }
            private set
            {

                this.dateTime = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialed;
            }
            private set
            {
                if (value.Length <= 0 || value.Length >= 14)
                {
                    throw new ArgumentOutOfRangeException("Its not a valid phone number");
                }
                if ( value[0] != '+')
                {
                    throw new ArgumentException(@"phone number must start with ""+"" followed by a code of the dialed country");
                }
                this.dialed = value;
            }
        }

        public ulong Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Call duration must be at least 1 sec");
                }
                this.duration = value;
            }
        }

        public override string ToString()
        {
            string text = "Dialed numer: " + this.DialedNumber + " | Call duaration: " + this.Duration + "sec | DateTime: " + this.DateTime;
            return text;
        }


    }
}

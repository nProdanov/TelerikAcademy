namespace GSMModels
{
    using System;
    using System.Collections.Generic;

    class GSM
    {
        private const decimal PricePerMinute = 0.37m;
        private const decimal MinSeconds = 60m;

        public static GSM iPhone4s = new GSM("iPhone 4s", "Apple", 450, "Sasho", new Battery("smotan", 70, 12, BatteryType.Li_Ion), new Display(4.3, 256000000));

        //fields
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        public Battery Battery { get; set; }
        public Display Display { get; set; }
        private List<Call> callHistory;
        private decimal callPrice;

        //Constructors
        public GSM(string modelPhone, string manufacturerOfPhone)
        {
            this.Model = modelPhone;
            this.Manufacturer = manufacturerOfPhone;
            this.callHistory = new List<Call>();
            
        }

        public GSM(string modelPhone, string manufacturerOfPhone, double pricePhone, string ownerOfPhone, Battery battery, Display display)
            : this(modelPhone, manufacturerOfPhone)
        {

            this.Price = pricePhone;
            this.Owner = ownerOfPhone;
            this.Battery = battery;
            this.Display = display;
        }


        //properties
        private decimal CallPrice
        {
            get
            {
                return this.callPrice;
            }

        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }


        }

        public GSM iPhone4S
        {
            get
            {
                return iPhone4s;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value.Length >= 5 || value == null)
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Model name must be at least 4 symbols");
                }

            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentOutOfRangeException("Price must be at least 10levs");
                }
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length >= 2 || value == null)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Manufaturer name must be at least 2 symbols");
                }

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
                if (value.Length >= 2 || value == null)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Model name must be at least 2 symbols");
                }

            }
        }


        //methods
        public void PrintCallPrice()
        {
            Console.WriteLine("Price for all calls is: {0} leva", this.CallPrice);
        }

        public void AddCall(int year, int month, int day, int hour, int minute, int second, string dialedNumber, ulong durationInSeconds)
        {
            Call call = new Call(new DateTime(year, month, day, hour, minute, second), dialedNumber, durationInSeconds);
            this.CallHistory.Add(call);
            decimal durationMinutes = (durationInSeconds / MinSeconds);
            this.callPrice += durationMinutes * PricePerMinute;
        }

        public void PrintCallHistory()
        {
            Console.Write("Call history for GSM {0}: ", ToString());
            Console.WriteLine();
            if (callHistory.Count == 0)
            {
                Console.WriteLine("there is no calls");
            }
            for (int i = 0; i < callHistory.Count; i++)
            {
                Console.WriteLine(callHistory[i]);
            }
        }

        public void DeleteCall(Call call)
        {
            int count = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i].DateTime == call.DateTime
                   && this.callHistory[i].Duration == call.Duration
                    && this.callHistory[i].DialedNumber == call.DialedNumber)
                {
                    Console.WriteLine("deleted {0} ", callHistory[i]);
                    decimal durationMinutes = this.callHistory[i].Duration / MinSeconds;
                    this.callPrice -= (durationMinutes * PricePerMinute);
                    this.callHistory.RemoveAt(i);


                    count++;
                }
            }
            if (count < 1)
            {
                Console.WriteLine("there is no a such call");
            }

        }


        public void ClearHistory()
        {
            this.callHistory.Clear();
            this.callPrice = 0;
            Console.WriteLine("History - Cleared!");
        }

        //override ToString()
        public override string ToString()
        {
            string text;

            if (this.Price == null)
            {
                text = this.Manufacturer + " | " + this.Model + " | ";
            }
            else
            {
                text = this.Manufacturer + " | " + this.Model + " | " + this.Price + "lv. | Owner: " + this.Owner + " | " + this.Battery + " | " + this.Display;
            }
            return text;
        }


    }
}

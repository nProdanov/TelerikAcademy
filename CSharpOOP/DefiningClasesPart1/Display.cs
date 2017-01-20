namespace GSMModels
{
    using System;

    class Display
    {
        private double size;

        private ulong numberOfColors;

        public Display()
        {

        }

        public Display(double sizeOfDisplayInch)
        {
            this.Size = sizeOfDisplayInch;
        }

        public Display(double sizeOfDisplayInch, ulong colorNumbers) :this(sizeOfDisplayInch)
        {
            this.ColorNumbers = colorNumbers;
        }

        public ulong ColorNumbers
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value<1)
                {
                    throw new ArgumentOutOfRangeException("Display must has even one color");
                }
                this.numberOfColors = value;
            }
        }

        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value<=2)
                {
                    throw new ArgumentOutOfRangeException("Display size must be more than 2 inches");
                }
                this.size = value;
            }
        }

        public override string ToString()
        {
            string text = "Display size: " + this.Size + ", Display colors: " + this.ColorNumbers;
            return text;
        }
    }
}

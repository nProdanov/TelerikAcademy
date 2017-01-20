namespace Kitchen.Products
{
    using Types;

    public abstract class Vegetable : IVegetable
    {
        protected ColorType color;
        protected ConditionType condition;
        protected WhereLiveType type;
        protected PicancyType picancy;

        public Vegetable(
            ColorType color,
            ConditionType condition,
            WhereLiveType type,
            PicancyType picancy)
        {
            this.Color = color;
            this.Condition = condition;
            this.Type = type;
            this.Picancy = picancy;
        }

        public ColorType Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public ConditionType Condition
        {
            get
            {
                return this.condition;
            }

            set
            {
                this.condition = value;
            }
        }

        public WhereLiveType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }

        public PicancyType Picancy
        {
            get
            {
                return this.picancy;
            }
            protected set
            {
                this.picancy = value;
            }
        }
    }
}

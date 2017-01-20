namespace SoftwareAcademy
{
    using System.Text;

    public class LocalCourse : Course, ICourse, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab) 
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                Validator.CheckStringNullOrEmpty(value, "Lab");

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format("Lab={0}", this.Lab));

            return result.ToString();
        }
    }
}

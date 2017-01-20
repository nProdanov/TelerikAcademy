namespace Homework.Students
{
    public class Group
    {
        private static string[] departments = new string[3] { "Math", "Statistics", "Development" };

        public Group(GroupNumber groupNumber)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departments[(int)groupNumber];
        }

        public GroupNumber GroupNumber { get; set; }

        public string DepartmentName { get; private set; }

        public override string ToString()
        {
            return this.DepartmentName;
        }
    }
}

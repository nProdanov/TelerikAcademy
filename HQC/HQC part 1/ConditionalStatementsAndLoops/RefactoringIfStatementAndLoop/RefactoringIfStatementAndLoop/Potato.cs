namespace RefactoringIfStatementAndLoop
{
    public class Potato
    {
        public Potato(bool peeled, bool isNotRotten)
        {
            this.IsPeeled = peeled;
            this.IsNotRotten = isNotRotten;
        }

        public bool IsPeeled { get; set; }

        public bool IsNotRotten { get; set; }
    }
}

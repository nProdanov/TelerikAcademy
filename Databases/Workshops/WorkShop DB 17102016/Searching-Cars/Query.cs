namespace Searching_Cars
{
    public class Query
    {
        public Query()
        {
            this.WhereClause = new WhereClause();
        }

        public string ResultFileName { get; set; }

        public string OrderBy { get; set; }

        public WhereClause WhereClause { get; set; }
    }
}

using System.Collections.Generic;

namespace Searching_Cars
{
    public class WhereClause
    {
        public WhereClause()
        {
            this.Property = new List<string>();
            this.PropertyName = new List<string>();
            this.ComparingOperator = new List<ComparingOperatorType>();
        }

        public List<string> PropertyName { get; set; }

        public List<string> Property { get; set; }

        public List<ComparingOperatorType> ComparingOperator { get; set; }
    }
}

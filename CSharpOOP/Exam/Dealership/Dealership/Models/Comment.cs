namespace Dealership.Models
{
    using System.Text;

    using Common;
    using Contracts;

    public class Comment : IComment
    {
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author { get; set; }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "comment length", Constants.MinCommentLength, Constants.MaxCommentLength));
                Validator.ValidateIntRange
                    (value.Length,
                    Constants.MinCommentLength,
                    Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "comment length", Constants.MinCommentLength, Constants.MaxCommentLength));

                this.content = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("    {0}", this.Content));
            result.Append(string.Format("      User: {0}", this.Author));

            return result.ToString();

        }
    }
}

namespace SchoolSystem.Contracts.SchoolActors
{
    /// <summary>
    /// School actor is person who is realated with school system.
    /// </summary>
    public interface ISchoolActor
    {
        /// <summary>
        /// First name of School actor
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last name of School actor
        /// </summary>
        string LastName { get; }
    }
}
namespace SchoolSystem
{
    using System;

    internal static class Validator
    {
        internal const int MinUniqueNumber = 10000;
        internal const int MaxUniqueNumber = 99999;
        internal const int MaxStudentsInCourse = 30;

        internal static void ValidateCourseCapacity(int courseStudentsCount)
        {
            if (Validator.MaxStudentsInCourse <= courseStudentsCount)
            {
                throw new ArgumentOutOfRangeException("Course capacity is full!");
            }
        }
        internal static void ValidateSchoolCapacity(int uniqueNumber)
        {
            if (Validator.MaxUniqueNumber < uniqueNumber)
            {
                throw new ArgumentOutOfRangeException("School capacity is full!");
            }
        }

        internal static void ValidateObjectNotNull(object obj, string parramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parramName);
            }
        }

        internal static void ValidateUniqueNumberIsUnderMinUniqueValue(int uniqueNumber)
        {
            if (uniqueNumber < Validator.MinUniqueNumber)
            {
                throw new ArgumentOutOfRangeException("Unique number", "Unique must be equal to, or  greater than 10000!");
            }
        }

        internal static void ValidateName(string name)
        {
            Validator.ValidateObjectNotNull(name, "Name");

            if (name == string.Empty)
            {
                throw new ArgumentOutOfRangeException("Name", "Name can not be empty!");
            }
        }
    }
}

using System;

using SchoolSystem.Contracts;
using SchoolSystem.Types;

namespace SchoolSystem.Models.SchoolActors
{
    public class Mark : IMark
    {
        private const int MinMarkValue = 2;
        private const int MaxMarkValue = 6;

        private float value;
        private SubjectType subject;

        public Mark(SubjectType subject, float value)
        {
            this.subject = subject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < MinMarkValue || value > MaxMarkValue)
                {
                    throw new ArgumentException(string.Format("Mark value must be in range {0} and {1}", MinMarkValue, MaxMarkValue));
                }

                this.value = value;
            }
        }

        public SubjectType Subject
        {
            get
            {
                return this.subject;
            }
        }
    }
}

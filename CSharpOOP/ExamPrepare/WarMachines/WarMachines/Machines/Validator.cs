namespace WarMachines.Machines
{
    using System;

    public static class Validator
    {
        public static void CheckName(string parram,string parramName)
        {
            if (string.IsNullOrEmpty(parram))
            {
                throw new ArgumentNullException(string.Format("{0} can not be null or empty!", parramName));
            }
        }

        public static void CheckForNegative(double parram, string parramName)
        {
            if(parram <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} can not be negative!", parramName));
            }
        }

        public static void CheckForZero(double parram, string parramName)
        {
            if(parram == 0)
            {
                throw new ArgumentOutOfRangeException("{0} can not be 0!", parramName);
            }
        }

        public static void CheckForNull(object obj, string parramName)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null!"));
            }
        }
    }
}

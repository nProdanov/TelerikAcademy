namespace SoftwareAcademy
{
    using System;

    public static class Validator
    {
        public static void CheckStringNullOrEmpty(string parram, string parramName)
        {
            if (string.IsNullOrEmpty(parram))
            {
                throw new ArgumentNullException(string.Format("{0} can not be null or empty!", parramName));
            }
        }

        public static void CheckIsNull(object obj,string parramName)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null!", parramName));
            }
        }
    }
}

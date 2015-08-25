namespace KingSurvival.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(errorMessage);
            }
        }
    }
}

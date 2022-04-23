namespace Aurora.Engine.Utilities
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Gets the ordinal numeral for the input number when it is positive. Otherwise it will just return the number in a string format.
        /// </summary>
        /// <param name="number">The number to convert to a ordinal numeral.</param>
        /// <returns>The ordinal numeral.</returns>
        public static string ToOrdinalNumeral(this int number)
        {
            if (number <= 0)
            {
                return number.ToString();
            }

            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
            }

            switch (number % 10)
            {
                case 1:
                    return $"{number}st";
                case 2:
                    return $"{number}nd";
                case 3:
                    return $"{number}rd";
                default:
                    return $"{number}th";
            }
        }
    }
}
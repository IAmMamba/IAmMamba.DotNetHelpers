using System;
using System.Text.RegularExpressions;

namespace IAmMamba.DotNetHelpers
{
    public static class StringExtensions
    {

        /// <summary>
        /// Takes the Left most characters of a string.  Short for Substring(length)
        /// </summary>
        /// <returns>The left.</returns>
        /// <param name="s">S.</param>
        /// <param name="length">Length.</param>
        public static string Left(this string s, int length)
        {
            if (!Check(s, length))
            {
                return s;
            }

            return s.Substring(0, length);
        }

        /// <summary>
        /// Returns the Right most characters of the string.  
        /// <para>Short for Substring(string.Length - length)</para>
        /// </summary>
        /// <returns>The right.</returns>
        /// <param name="s">S.</param>
        /// <param name="length">Length.</param>
        public static string Right(this string s, int length)
        {
            if (!Check(s, length) )
            {
                return s;
            }
           
            return s.Substring(s.Length - length);
        }

        /// <summary>
        /// Returns false if the string is null, if the length is less than the minLength 
        /// or if the length is greater than the maxLength. Max length is ignored if it is 0.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="minLength">Minimum string length</param>
        /// <param name="maxLength">Maximum string length, set to 0 for unbounded</param>
        /// <returns></returns>
        public static bool Check(string s, int minLength, int maxLength = 0)
        {
            if (s == null)
            {
                return false;
            }

            if (s.Length < minLength)
            {
                return false;
            }

            if (maxLength > 0 && s.Length > maxLength)
            {
                return false;
            }

            return true;
        }

        public const string LETTERS_ONLY_REGEX = "[^a-zA-Z]";
        /// <summary>
        /// Letters only.
        /// </summary>
        /// <returns>String with only a-z/A-Z.</returns>
        /// <param name="s">S.</param>
        public static string LettersOnly(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return new Regex(LETTERS_ONLY_REGEX).Replace(s, "");
        }
    }
}

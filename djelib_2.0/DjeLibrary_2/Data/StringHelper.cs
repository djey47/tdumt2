using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DjeLibrary_2.Data
{
    /// <summary>
    /// Utility class providing help to handle Strings
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Converts a string to a Pascal-Cased one
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <returns>The same string, pascal-cased</returns>
        public static string ToPascalCase(string str)
        {
            string result = null;

            if (str != null)
            {
                result = Regex.Replace(str, @"(\b[a-z])", new MatchEvaluator(_ToUpperCase));
            }

            return result;
        }

        #region Private methods
        /// <summary>
        /// Match evaluator returning uppercase of matching character
        /// </summary>
        /// <param name="m">matching character</param>
        /// <returns>the same character to uppercase</returns>
        private static string _ToUpperCase(Match m)
        {
            char c = m.Captures[0].Value[0];
            return Char.ToUpper(c).ToString();
        }
        #endregion

    }
}

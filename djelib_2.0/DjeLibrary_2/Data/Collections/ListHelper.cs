using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DjeLibrary_2.Data.Collections
{
    /// <summary>
    /// Static class providing advanced list management
    /// </summary>
    public static class ListHelper
    {
        #region Constants
        /// <summary>
        /// Format for list contents
        /// </summary>
        private const string _FORMAT_LIST_CONTENTS = "[{0}]";

        /// <summary>
        /// Symbol to separate list items
        /// </summary>
        private const char _SYMBOL_LIST_SEPARATOR = ';';
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a formated string to display list contents properly
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            if (list != null)
            {
                int index = 0;
                foreach (string anotherItem in list)
                {
                    sb.Append(anotherItem);
                    if (index != list.Count - 1)
                    {
                        sb.Append(_SYMBOL_LIST_SEPARATOR);
                    }
                    index++;
                }
            }
            return string.Format(_FORMAT_LIST_CONTENTS, sb);
        }
        #endregion
    }
}

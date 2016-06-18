using System;

namespace DjeLibrary_2_Test.Fail
{
    /// <summary>
    /// Utility class generating various kind of exception
    /// </summary>
    class ExceptionGenerator
    {
        /// <summary>
        /// NPE
        /// </summary>
        public void NullPointer()
        {
            throw new NullReferenceException("epic fail!!");
        }
    }
}

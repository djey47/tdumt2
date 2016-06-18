using DjeLibrary_2.Security;
using NUnit.Framework;

namespace DjeLibrary_2_Test.Security
{
    [TestFixture]
    public class PrivilegeUtilsTest
    {
        [TestCase]
        public void TestAdministrator()
        {
            // Tests always run in standard mode
            Assert.IsFalse(PrivilegeUtils.Administrator);
        }
    }
}

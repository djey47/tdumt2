using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModdingLibrary_2.fileformats.banks;
using ModdingLibrary_2.support;

namespace ModdingLibraryTest
{
    [TestClass]
    public class BnkTest
    {
        /// <summary>
        /// TDU2 file
        /// </summary>
        /// <returns></returns>
        private static Bnk _LoadBnk1()
        {
           const string fileName = @"E:\Docs\Bureau Vista\California.bnk";

            return new Bnk {Name = fileName};
        }

        /// <summary>
        /// TDU2 file
        /// </summary>
        /// <returns></returns>
        private static Bnk _LoadBnk2()
        {
            const string fileName = @"E:\Docs\Bureau Vista\CCXR_Edition.bnk";

            return new Bnk { Name = fileName };
        }

        /// <summary>
        /// TDU file
        /// </summary>
        /// <returns></returns>
        private static Bnk _LoadBnk3()
        {
            const string fileName = @"E:\Docs\Bureau Vista\300_C.bnk";

            return new Bnk { Name = fileName };
        }

        [TestMethod]
        public void TestBnkReading()
        {
            // TDU2 mode
            Context.GameProduct = Context.Product.TDU2;
            Bnk bnk1 = _LoadBnk1();

            bnk1.Read();

            Assert.IsNotNull(bnk1);

            // TDU mode
            Context.GameProduct = Context.Product.TDU;
            Bnk bnk3 = _LoadBnk3();

            bnk3.Read();

            Assert.IsNotNull(bnk3);
            

        }

        [TestMethod]
        public void TestBnkAllExtracting()
        {
            Bnk bnk1 = _LoadBnk1();
            Bnk bnk2 = _LoadBnk2();
            Bnk bnk3 = _LoadBnk3();

            Context.GameProduct = Context.Product.TDU2;
            bnk1.Read();
            bnk1.ExtractAll(@"E:\Docs\Bureau Vista\California");

            bnk2.Read();
            bnk2.ExtractAll(@"E:\Docs\Bureau Vista\CCXR");

            Context.GameProduct = Context.Product.TDU;
            bnk3.Read();
            bnk3.ExtractAll(@"E:\Docs\Bureau Vista\300_C");
        }
    }
}

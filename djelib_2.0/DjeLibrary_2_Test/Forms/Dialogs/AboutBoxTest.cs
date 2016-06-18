using DjeLibrary_2.Forms.Dialogs;
using System.Windows.Forms;
using NUnit.Framework;
using DjeLibrary_2.Gui.WinForms;

namespace DjeLibrary_2_Test.Forms.Dialogs
{
    /// <summary>
    ///Classe de test pour AboutBox, destinée à contenir tous
    ///les tests unitaires AboutBox
    ///</summary>
    [TestFixture]
    public class AboutBoxTest
    {
        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        [SetUp]
        public void MyTestInitialize()
        {
        }
        
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///Test pour Show
        ///</summary>
        [Test]
        public void ShowTest()
        {
            const string d = "2011";
            const string m = "This is a test.";
            const string i = "Thanks to...";
            IWin32Window owner = null;
            AboutBox target = new AboutBox
                                  {
                                      CustomDate = d,
                                      CustomInformation = i,
            CustomMessage = m
                              };
            const DialogResult expected = DialogResult.OK;
            DialogResult actual = target.Show(owner);

            Assert.AreEqual(expected, actual);
        }
    }
}

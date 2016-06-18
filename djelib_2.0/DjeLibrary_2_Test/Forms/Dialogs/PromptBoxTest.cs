using DjeLibrary_2.Forms.Dialogs;
using DjeLibray_2_Test.Support.Logging;
using log4net;
using System.Windows.Forms;
using NUnit.Framework;

namespace DjeLibrary_2_Test.Forms.Dialogs
{
    
    
    /// <summary>
    ///Classe de test pour PromptBoxTest, destinée à contenir tous
    ///les tests unitaires PromptBoxTest
    ///</summary>
    [TestFixture]
    public class PromptBoxTest
    {
        /// <summary>
        /// Internal logger.
        /// </summary>
        private static readonly ILog _Logger = LogManager.GetLogger(typeof(PromptBoxTest));

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
            LoggingUtil.Initialize();
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
        [TestCase]
        public void ShowTest()
        {
            const string v = "V";
            IWin32Window owner = null;
            PromptBox target = new PromptBox("TITLE","MESSAGE",v);
            const DialogResult expected = DialogResult.OK;
            DialogResult actual = target.Show(owner);

            Assert.AreEqual(expected, actual);
            _Logger.Info("Returned value: " + target.ReturnValue);
            Assert.AreEqual(v, target.ReturnValue);
        }
    }
}

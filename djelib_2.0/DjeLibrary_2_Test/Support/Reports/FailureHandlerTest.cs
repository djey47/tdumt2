using DjeLibrary_2.Support.Reports;
using DjeLibrary_2_Test.Fail;
using DjeLibray_2_Test.Support.Logging;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DjeLibrary_2_Test.Support.Reports
{

    /// <summary>
    ///Classe de test pour FailureHandlerTest, destinée à contenir tous
    ///les tests unitaires FailureHandlerTest
    ///</summary>
    [TestClass]
    public class FailureHandlerTest
    {
        /// <summary>
        /// Internal logger.
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof (FailureHandlerTest));

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
        [TestInitialize]
        public void MyTestInitialize()
        {
            LoggingUtil.Initialize();
        }
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///Test pour GetStackTrace
        ///</summary>
        [TestMethod]
        public void GetStackTraceTest()
        {
            Exception ex = new Exception();
            string actual = FailureHandler.GetStackTrace(ex);
            Assert.IsFalse(string.IsNullOrEmpty(actual));
        }

        /// <summary>
        ///Test pour Handle
        ///</summary>
        [TestMethod]
        public void HandleTest()
        {
            const string appName = "TEST_APP";
            Exception ex = new Exception();
            FailureHandler.Handle(appName, ex);

            // Should display a dialog box with exception stack trace in it...
        }

        /// <summary>
        /// Other test for Handle()
        /// </summary>
        [TestMethod]
        public void HandleTest2()
        {
            // Failure report
            try
            {
                new ExceptionGenerator().NullPointer();
            }
            catch (Exception ex)
            {
                // Critical exception catched here
                FailureHandler.Handle("TEST_APP", ex);

                logger.Error(FailureHandler.GetStackTrace(ex));
            }
        }
    }
}

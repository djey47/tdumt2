using DjeLibrary_2.Support.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DjeLibrary_2_Test.Support.Reports
{
    
    
    /// <summary>
    ///Classe de test pour ApplicationFailureTest, destinée à contenir tous
    ///les tests unitaires ApplicationFailureTest
    ///</summary>
    [TestClass]
    public class ApplicationFailureTest
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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test pour Constructeur ApplicationFailure
        ///</summary>
        [TestMethod]
        public void ApplicationFailureConstructorTest()
        {
            ApplicationFailure target = new ApplicationFailure();

            Assert.IsNotNull(target.AppName);
            Assert.IsNull(target.InnerException);
        }

        /// <summary>
        ///Test pour Constructeur ApplicationFailure
        ///</summary>
        [TestMethod]
        public void ApplicationFailureConstructorTest1()
        {
            const string appName = "TOTO_APP";
            Exception innerException = new Exception("bam");
            ApplicationFailure target = new ApplicationFailure(appName, innerException);

            Assert.AreEqual(appName, target.AppName);
            Assert.AreEqual(innerException, target.InnerException);
        }

        /// <summary>
        ///Test pour AppName
        ///</summary>
        [TestMethod]
        public void AppNameTest()
        {
            ApplicationFailure target = new ApplicationFailure(); 
            const string expected = "APP_NAME";

            target.AppName = expected;
            string actual = target.AppName;
            Assert.AreEqual(expected, actual);
        }
    }
}

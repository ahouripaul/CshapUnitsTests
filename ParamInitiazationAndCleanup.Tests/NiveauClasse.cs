using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParamInitializationAndCleanup;
using System;
using System.Windows.Forms;

namespace ParamInitiazationAndCleanup.Tests
{
    [TestClass]
    public class NiveauClasse
    {
       static Rectangle rec;

        [AssemblyInitialize] //méthode exécutée qu'une seule avant toutes les classes de test
        public static void SetupAssembly(TestContext testContext)
        {
            MessageBox.Show("Assembly Level Setup.....");
        }

        [AssemblyCleanup] //méthode exécutée qu'une seule après toutes les classes de test
        public static void CleanAssembly()
        {
            MessageBox.Show("Assembly Level Cleanup.....");
        }

        //La signature de la méthode Setup est imposée par MsTest: elle doit être static et doit prendre en param un objet de type TestContext
        [ClassInitialize] //cette méthode est excéutée qu'une seule fois avant toutes les méthodes de test
        public static void Setup(TestContext testContext)
        {
            rec = new Rectangle();
            rec.Longueur = 10;
            rec.Largeur = 15;

            MessageBox.Show("Classe Level:Méthode Setup");
        }

        [ClassCleanup] //cette méthode est exécutée qu'une seule fois après toutes les méthodes de test
        public static void Clean()
        {
            rec = null;
            MessageBox.Show("Classe Level: Méthode Clean");
        }

        [TestMethod]
        [TestCategory("Initialisation et nettoyage des params niveau classe")]
        public void SurfaceTest()
        {
            Assert.AreEqual(150, rec.Surface());
            MessageBox.Show("Classe Level: Méthode Surface");
        }

        [TestMethod]
        [TestCategory("Initialisation et nettoyage des params niveau classe")]
        public void PerimetreTest()
        {
            Assert.AreEqual(50, rec.Perimetre());
            MessageBox.Show("Classe Level: Méthode Périmetre");
        }
    }
}

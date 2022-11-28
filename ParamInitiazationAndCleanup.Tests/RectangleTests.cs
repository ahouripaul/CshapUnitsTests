using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParamInitializationAndCleanup;
using System;
using System.Windows.Forms;

namespace ParamInitiazationAndCleanup.Tests
{
    [TestClass]
    public class RectangleTests
    {
        //3 niveaux d'initialisation des paramètres
        //1- Niveau limité aux méthodes de test
        //2- Niveau limité à la classe de test
        //3- niveau limité à tout le prjet (toute l'Assembly)

        Rectangle rec;

        [TestInitialize] //cette méthode s'exécute avant chaque méthode de test
        public void Setup()
        {
            rec = new Rectangle();
            rec.Longueur = 10;
            rec.Largeur = 15;

            MessageBox.Show("Méthode Setup");
        }

        [TestCleanup] //cette s'exécute après chaque méthode de test
        public void Clean()
        {
            rec = null;
            MessageBox.Show("Méthode Clean");
        }

        [TestMethod]
        [TestCategory("Initialisation et nettoyage des paramétres")]
        public void SurfaceTest()
        {
            //arrange

            //Rectangle rec = new Rectangle();
            //rec.Longueur = 10;
            //rec.Largeur = 15;

            //Setup();
            double attendu = 150;

            //act: 
            double obtenu = rec.Surface();

            //assert
            Assert.AreEqual(attendu, obtenu);

            MessageBox.Show("Méthode Surface");
        }

        [TestMethod]
        [TestCategory("Initialisation et nettoyage des paramétres")]
        public void PerimetreTest()
        {
            //arrange

            //Rectangle rec = new Rectangle();
            //rec.Longueur = 10;
            //rec.Largeur = 15;

            //Setup();
            double attendu = 50;

            //act
            double obtenu = rec.Perimetre();

            //assert
            Assert.AreEqual(attendu,obtenu);

            MessageBox.Show("Méthode Perimetre");

        }
    }
}

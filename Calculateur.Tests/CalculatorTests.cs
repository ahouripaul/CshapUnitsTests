using Calculateur.DLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculateur.Tests
{
    /*
     * Conventions de nommage concerant les projets de test:
     * 1- Le nom du pojet de tests unitaires, porte le nom du projet à tester suivi du mot clé Tests
     * 2- Les classes (UnitTest) portent le nom de la classe a tester suivient du clé Tests
     * 3- Les méthodes des tests, portent le nom de la méthode à tester et contient aussi l'état des paramètres de la méthode à tester et
     *    le résultat attendu
     *     NomMéthodeATester_EtatDesParams_ResultatAttendu
     * 
     */

    [TestClass] //Attribut qui précise qu'il s'agit d'une classe de test
    
    public class CalculatorTests
    {
        [TestMethod] //Attribut qui précise qu'il s'agit d'une méthode de test
        [TestCategory("Calculator")]
        [TestProperty("Test Groupe1","Performence")]
        [Priority(1)]
        [Owner("Dawan")]
        public void Division_NumerateurPositif_DenominateurPositif_RetrunResultatPositif()
        {
            //Le contenu doit respecter le Pattern AAA: Arrange - Act - Assert

            //Arrange: initialiser les params de la méthode à tester
            int numerateur = 10;
            int denominateur = 2;
            int resultatAttendu = 5;

            //Act: Appel de la méthode à tester
            int resultatObtenu = Calculator.Division(numerateur, denominateur);

            //Assert: Faire des assertions (vérifications) - Vérifier les 2 résultat, en utilisant la classe Assert
            Assert.AreEqual(resultatAttendu, resultatObtenu);

        }
        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Groupe1", "Performence")]
        [Priority(1)]
        [Owner("Dawan")]
        public void Division_NumerateurPositif_DenominateurNegatif_ReturnResultatNegatif()
        {
            //Arrange
            int numerateur = 10;
            int denominateur = -2;
            int resultatAttendu = -5;

            //Act
            int resultatObtenu = Calculator.Division(numerateur, denominateur);

            //Assert
            Assert.AreEqual(resultatAttendu, resultatObtenu);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Groupe1", "Performence")]
        [Priority(1)]
        [Owner("Dawan")]
        public void Division_NumerateurNegatif_DenominateurNegatif_ReturnResultatPositif()
        {
            //Arrange
            int numerateur = -10;
            int denominateur = -2;
            int resultatAttendu = 5;

            //Act
            int resultatObtenu = Calculator.Division(numerateur, denominateur);

            //Assert
            Assert.AreEqual(resultatAttendu, resultatObtenu);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Groupe1", "Performence")]
        [Priority(1)]
        [Owner("Dawan")]
        public void Division_NumerateurNegatif_DenominateurPositif_ReturnResultatNegatif()
        {
            //Arrange
            int numerateur = -10;
            int denominateur = 2;
            int resultatAttendu = -5;

            //Act
            int resultatObtenu = Calculator.Division(numerateur, denominateur);

            //Assert
            Assert.AreEqual(resultatAttendu, resultatObtenu);
        }

        [TestMethod]
        [TestCategory("Calculator")]
        [TestProperty("Test Groupe1", "Performence")]
        [Priority(1)]
        [Owner("Dawan")]
        [ExpectedException(typeof(DivideByZeroException))] //Attribut qui permet de vérifier l'exception générer par une méthode
        public void Division_DenominateurEgaleZero_ReturnException()
        {
            //Arrange
            int numerateur = -10;
            int denominateur = 0;

            //Act
            Calculator.Division(numerateur, denominateur);

        }
        
        [TestMethod]
        [TestCategory("Exo")]
        public void NbChar_ParamNull_RetrunZero()
        {
            //Arrange
            string chaine = null;
            //Act:
            int resultat = Calculator.NbChar(chaine);
            //Assert
            Assert.AreEqual(0, resultat);
        }

        [TestMethod]
        [TestCategory("Exo")]
        public void NbChar_ParamEmpty_RetrunZero()
        {
            //Arrange
            string chaine = string.Empty;
            //Act:
            int resultat = Calculator.NbChar(chaine);
            //Assert
            Assert.AreEqual(0, resultat);
        }

        [TestMethod]
        [TestCategory("Exo")]
        public void NbChar_ParamNotEmptyNotNull_RetrunSize()
        {
            //Arrange
            string chaine = "ddddd";
            //Act:
            int resultat = Calculator.NbChar(chaine);
            //Assert
            Assert.AreEqual(5, resultat);
        }

        [TestMethod]
        [TestCategory("Exo")]
        [ExpectedException(typeof(ArgumentException))]
        public void NbMots_ParamNull_RetrunException()
        {
            //Arrange
            string chaine = null;
            //Act:
            Calculator.NbMots(chaine);
          
        }

        [TestMethod]
        [TestCategory("Exo")]
        [ExpectedException(typeof(ArgumentException))]
        public void NbMots_ParamEmpty_RetrunException()
        {
            //Arrange
            string chaine = string.Empty;
            //Act:
            Calculator.NbMots(chaine);

        }

        [TestMethod]
        [TestCategory("Exo")]
        public void NbMots_ParamNotEmptyNotNull_RetrunNbMots()
        {
            //Arrange
            string chaine = " ceci est une  chaine ";
            //Act:
            int resultat = Calculator.NbMots(chaine);
            //Assert
            Assert.AreEqual(4,resultat);

        }

        [TestMethod]
        [TestCategory("Exo")]
        [ExpectedException(typeof (ArgumentException))]
        public void SommeTab_ParamNull_RetrunException()
        {

            Calculator.SommeTab(null);
            
        }

        [TestMethod]
        [TestCategory("Exo")]
        public void SommeTab_ParamNotNull_RetrunSommeItem()
        {
            //Arrange
            int[] tab = { 10, 5, 3, 8 };
            int attendu = 26;
            //Act
            int obtenu = Calculator.SommeTab(tab);
            //Assert
            Assert.AreEqual(attendu,obtenu);

        }
    }
}

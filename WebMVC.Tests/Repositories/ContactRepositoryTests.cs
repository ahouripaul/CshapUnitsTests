using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebMVC.Models;
using WebMVC.Repositories;

namespace WebMVC.Tests.Repositories
{
    [TestClass]
    public class ContactRepositoryTests
    {
        /********Ne pas utiliser la base de données de la la prod (de l'application) **** Créer une BD pour faire les tests unitaires
         * 1- Installer Entity Framework 6.4
         * 2- Dans app.config - fournir la chaine de connexion vers la BD de tests
         * 
         */

        ContactRepository contactRepository;

        [TestInitialize]
        public void Setup()
        {
            contactRepository = new ContactRepository();
        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void GetAllTest()
        {
            //Table est vide
            Assert.AreEqual(0, contactRepository.GetAll().Count);
        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void Insert_Test()
        {
            //arrange
            Contact c = new Contact { Id = 1, Name = "dawan" };
            int tailleAvantInsertion = contactRepository.GetAll().Count; //0

            //Act
            contactRepository.Insert(c);
            int tailleApresInsertion = contactRepository.GetAll().Count; //1

            //Assert
            Assert.AreEqual(tailleApresInsertion, tailleAvantInsertion + 1);
        }
    }
}

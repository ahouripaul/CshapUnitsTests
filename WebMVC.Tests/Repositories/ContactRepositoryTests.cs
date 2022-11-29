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
        public void a_GetAllTest()
        {
            //Table est vide
            Assert.AreEqual(0, contactRepository.GetAll().Count);
        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void b_Insert_Test()
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

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void c_GetById_Test()
        {
            //arrange
           int id = 1;
            //Act
            Contact c = contactRepository.GetById(id);

            //Assert
            Assert.IsNotNull(c);
            Assert.AreEqual("dawan", c.Name);
        }


        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        [ExpectedException(typeof(Exception))]  
        public void d_GetById_IdNotExist_ReturnException()
        {
            //arrange
            int id = 1500;
            //Act
            contactRepository.GetById(id);
        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void e_Update_Test()
        {
            //arrange
            int id = 1;
            Contact c = contactRepository.GetById(id);
            c.Name = "Autre nom";

            //act
            contactRepository.Update(c);
            Contact contactDB = contactRepository.GetById(id);

            //Assert
            Assert.AreEqual("Autre nom", contactDB.Name);

        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        [ExpectedException(typeof(Exception))]
        public void f_Update_ContactNotExist_ReturnException()
        {
            //arrange
            Contact c = new Contact { Id = 2500, Name = "New Name" };

            //act
            contactRepository.Update(c);           

        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        public void g_Delete_Test()
        {
            //arrange
            int id = 1;
            int tailleAvantSuppression = contactRepository.GetAll().Count;

            //act
            contactRepository.Delete(id);
            int tailleApresSuppression = contactRepository.GetAll().Count;

            //assert
            Assert.AreEqual(tailleApresSuppression, tailleAvantSuppression - 1);

        }

        [TestMethod]
        [TestCategory("WebMvc Repository Unit Test")]
        [ExpectedException(typeof(Exception))]
        public void h_Delete_IdNotExist_ReturnException()
        {
            //arrange
            int id = 300;
            //act
            contactRepository.Delete(id);           

        }
    }
}
/*
 * Dans une sute de tests, les méthode sont exécutées par ordre alphabétique
 * Si on veut définir un ordre d'exécution des méthodes de tests, on doit revoir le nom des méthodes
 * et repartir d'une base de données de test complètement vide
 * 
 */
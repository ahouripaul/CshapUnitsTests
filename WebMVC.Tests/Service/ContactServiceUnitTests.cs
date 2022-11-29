using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebMVC.Models;
using WebMVC.Repositories;
using WebMVC.Services;

namespace WebMVC.Tests.Service
{
    /*
     * Le service depend complètement du Repository, à priori les tests unitaires pour le Service en sont
     * pas possibles.
     * Pour mettre en place des tests unitaires pour la couche Service, on doit utiliser un Framework de Mocking
     * pour mocker (simuler) le Repository. Java(mockito) - .net (moq)
     * 
     * 
     */

    [TestClass]
    public class ContactServiceUnitTests
    {
        ContactService contactService;
        Mock<IContact> mockRepo = new Mock<IContact>();

        [TestInitialize]
        public void Setup()
        {
            contactService = new ContactService(mockRepo.Object);
        }

        [TestMethod]
        [TestCategory("WebMvc Service Unit Tests")]
        public void GetAll_Test()
        {
            //arrange
            List<Contact> lst = new List<Contact>();
            lst.Add(new Contact());
            lst.Add(new Contact());
            mockRepo.Setup(a => a.GetAll()).Returns(lst); //simulation du fonctionnement de Repository

            //act
            var list = contactService.GetAll();

            //assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        [TestCategory("WebMvc Service Unit Tests")]
        public void GetById_Test()
        {
            //arrange
            Contact c = new Contact { Id = 1 , Name="dawan"};
            mockRepo.Setup(a => a.GetById(1)).Returns(c); //simulation du fonctionnement de Repository

            //act
            var contact = contactService.GetById(1);

            //assert
            Assert.AreEqual("dawan", contact.Name);
            Assert.AreEqual(1, contact.Id);
        }

        [TestMethod]
        [TestCategory("WebMvc Service Unit Tests")]
        public void Insert_Test()
        {
            //arrange
            //Insert du repo est void, ne renvoie aucun résultat
            //Comment savoir si la méthode insert est appelée?

            Contact c = new Contact { Id = 1, Name = "dawan" };
            mockRepo.Setup(a => a.Insert(c)).Callback(() => Console.WriteLine("Contact inséré...."));

            //act
            contactService.Insert(c);

           //Comment savoir si le contact est inséré (la méthode Insert du Service void)?
           //Il suffit de vérifier si méthode Insert du Repository est appelée.
        }

        [TestMethod]
        [TestCategory("WebMvc Service Unit Tests")]
        public void Delete_Test()
        {
            //arrange
            int id = 10;
            mockRepo.Setup(a => a.Delete(id)).Callback(() => Console.WriteLine("Contact supprimé...."));

            //act
            contactService.Delete(id);

           
        }

        [TestMethod]
        [TestCategory("WebMvc Service Unit Tests")]
        public void Update_Test()
        {
            //arrange
            Contact c = new Contact { Id = 1, Name = "dawan" };
            mockRepo.Setup(a => a.Update(c)).Callback(() => Console.WriteLine("Contact maj: "+c.Name));

            //act
            c.Name = "New Name";
            contactService.Update(c);


        }
    }
}

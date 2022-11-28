using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;
using WebMVC.Repositories;

namespace WebMVC.Services
{
    //SOLID: Dependency Injection
    public class ContactService
    {
        private IContact repo;

        //Injection de dépendence via le constructeur
        public ContactService(IContact repo)
        {
            this.repo = repo;
        }

        public List<Contact> GetAll()
        {
            return repo.GetAll();
        }
        public Contact GetById(int id)
        {
            return repo.GetById(id);           
        }

        public void Insert(Contact c)
        {
            repo.Insert(c);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
        public void Update(Contact c)
        {
            repo.Update(c);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.Repositories
{
    public class ContactRepository : IContact
    {
        private MyContext context = new MyContext();
        public void Delete(int id)
        {
            Contact c = context.Contacts.Find(id);
            if (c != null)
            {
                context.Contacts.Remove(c); //Etat c = Deleted
                context.SaveChanges(); //Delete From Contacts Where id=id
            }
            else
            {
                throw new Exception("Contact introuvable");
            }
        }

        public List<Contact> GetAll()
        {
            //AsNotrucking renvoie la liste des contacts sans la conserver dans le cache du Context
            return context.Contacts.AsNoTracking().ToList();
        }
            

        public Contact GetById(int id)
        {
            Contact c= context.Contacts.Find(id);
            if (c != null)
            {
                return c;
            }
            else
            {
                throw new Exception("Contact introuvable");
            }
        }

        public void Insert(Contact contact)
        {
            context.Contacts.Add(contact); //Etat contact = Added
            context.SaveChanges(); //Insert Into Contacts
        }

        public void Update(Contact contact) //Contact fournit par la couche présentation via un formulaire
        {
            //Etat de contact fournit par la UI = Detached (n'est pas relié au context)

            Contact contactDB = context.Contacts.Find(contact.Id); //contactDB etat = unchanged
            if (contactDB != null)
            {
                //Option1: manipuler le contactDB chargé dans le context - modifier ses attributs
                contactDB.Name = contact.Name; //Etat de contactDB = Modified
                context.SaveChanges(); //Update Contacts 

                //Option2: manipuler le contact fournit par la couche présentation et modifier son état
                //context.Contacts.Attach(contact); // etat de contact = unchanged
                //context.Entry(contact).State = EntityState.Modified;
                //context.SaveChanges(); //Update Contacts.......

            }
            else
            {
                throw new Exception("Contact introuvable");
            }
        }
    }
}
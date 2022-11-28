using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Repositories
{
    public interface IContact
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}

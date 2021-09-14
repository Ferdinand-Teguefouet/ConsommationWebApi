using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entities;

namespace WebApiDAL.Interface
{
    public interface IContactRequesterService
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void InsertContact(ContactForm cf);
        void Update(ContactForm contactForm);
        void Delete(int id);
    }
}

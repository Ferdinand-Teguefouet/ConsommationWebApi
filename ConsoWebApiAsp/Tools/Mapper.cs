using ConsoWebApiAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDAL.Entities;

namespace ConsoWebApiAsp.Tools
{
    public static class Mapper
    {
        public static AspContact ToAsp(this Contact contact)
        {
            return new AspContact
            {
                Id = contact.Id,
                CompleteName = contact.FirstName + " " + contact.LastName,
                Email = contact.Email
            };
        }

        public static AspContactDetails ToAspDetails(this Contact cDetails)
        {
            return new AspContactDetails
            {
                Id = cDetails.Id,
                FirstName = cDetails.FirstName,
                LastName = cDetails.LastName,
                Email = cDetails.Email
            };
        }

        public static AspContactCreate ToAspEdit(this Contact c)
        {
            return new AspContactCreate
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            };
        }

        public static ContactForm ToDAL(this AspContactCreate cc)
        {
            return new ContactForm
            {
                Id = cc.Id,
                FirstName = cc.FirstName,
                LastName = cc.LastName,
                Email = cc.Email
            };
        }
    }
}

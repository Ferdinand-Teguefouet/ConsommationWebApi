using ConsoWebApiAsp.Models;
using ConsoWebApiAsp.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDAL.Interface;

namespace ConsoWebApiAsp.Controllers
{
    public class ContactController : Controller
    {
        private IContactRequesterService _contactService;

        public ContactController(IContactRequesterService contactService)
        {
            _contactService = contactService;
        }

        #region Récupérer la liste de contacts
        public IActionResult Index()
        {
            return View(_contactService.GetAll().Select(c => c.ToAsp()));
        }
        #endregion

        #region Afficher les details d'un contact
        public ActionResult Details(int id)
        {
            return View(_contactService.GetById(id).ToAspDetails());
        }
        #endregion

        #region Créer et insérer un contact
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] AspContactCreate cc)
        {
            if (!ModelState.IsValid)
            {
                return View(cc);
            }
            _contactService.InsertContact(cc.ToDAL());
            return RedirectToAction("Index");
        }
        #endregion

        #region Modifier un contact
        public IActionResult Edit(int Id)
        {
            return View(_contactService.GetById(Id).ToAspEdit());
        }

        [HttpPost]
        public IActionResult Edit([FromForm]AspContactCreate cc)
        {
            if (!ModelState.IsValid)
            {
                return View(cc);
            }

            _contactService.Update(cc.ToDAL());
            return RedirectToAction("Index");
        }
        #endregion

        #region supprimer un contact
        public IActionResult Delete(int Id)
        {
            _contactService.Delete(Id);
            return RedirectToAction("Index");
        } 
        #endregion
    }
}

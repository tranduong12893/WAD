using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_EXAM.Models;

namespace WAD_EXAM.Controllers
{
    public class ContactController : Controller
    {
        private DataContext context = new DataContext();
        // GET: Contact
        public ActionResult Index()
        {
            var list = context.ListContacts.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListContact listContact)
        {
            if (ModelState.IsValid)
            {
                context.ListContacts.Add(listContact);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listContact);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ListContact listContact = context.ListContacts.Find(id);
            if (listContact == null)
            {
                return HttpNotFound();
            }
            return View(listContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListContact listContact)
        {
            if (ModelState.IsValid)
            {
                context.Entry(listContact).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listContact);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ListContact listContact = context.ListContacts.Find(id);
            if (listContact == null)
            {
                return HttpNotFound();
            }
            context.ListContacts.Remove(listContact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
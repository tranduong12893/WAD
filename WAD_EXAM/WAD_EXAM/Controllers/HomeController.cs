using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_EXAM.Models;

namespace WAD_EXAM.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            ViewData["Page-Title"] = "Online Contact";
            
            var list = context.ListContacts.ToList();

            return View(list); // passing data by model
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListContact listContact)
        {
            if (ModelState.IsValid)
            {
                // khi dữ liệu gửi lên thỏa mãn yêu cầu (yêu cầu theo Model) -> lưu vào DB
                context.ListContacts.Add(listContact);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(listContact);// trở lại giao diện kèm dữ liệu vừa nhập
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // Dựa vào id để tìm category
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
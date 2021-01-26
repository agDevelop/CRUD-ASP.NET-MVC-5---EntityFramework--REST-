using Laba2Goncharov.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba2Goncharov.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Note> notesList = db.Notes.ToList<Note>();

            ViewBag.notesList = notesList;

            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Index(string Id)
        {
            try
            {
                int noteId = int.Parse(Id);

                Note note = db.Notes.Local.FirstOrDefault(topic => topic.Id == noteId) ?? db.Notes.FirstOrDefault(topic => topic.Id == noteId);

                db.Entry(note).State = EntityState.Deleted;

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Note note)
        {
            db.Notes.Add(note);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            try
            {
                int noteId = int.Parse(Id);

                Note note = db.Notes.Local.FirstOrDefault(topic => topic.Id == noteId) ?? db.Notes.FirstOrDefault(topic => topic.Id == noteId);

                return View(note);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            db.Entry(note).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "О лабе";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }
    }
}
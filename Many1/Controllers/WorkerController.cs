using Many1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Many1.Controllers
{
    public class WorkerController : Controller
    {
        private TeamContext db = new TeamContext();
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult WorkerEdit(int id = 0)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.Projects = db.Projects.ToList();
            return View(worker);
        }

        [HttpPost]
        public ActionResult WorkerEdit(Worker worker, int[] selectedProjects)
        {
            Worker newPlayer = db.Workers.Find(worker.Id);
            newPlayer.Name = worker.Name;
            newPlayer.Surname = worker.Surname;
            newPlayer.Patronymic = worker.Patronymic;
            newPlayer.Email = worker.Email;

            if (ModelState.IsValid)
            {
                newPlayer.Projects.Clear();
                if (selectedProjects != null)
                {

                    foreach (var c in db.Projects.Where(co => selectedProjects.Contains(co.Id)))
                    {
                        newPlayer.Projects.Add(c);
                    }
                }

                db.Entry(newPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            ViewBag.Projects = db.Projects.ToList();
            return View(worker);
        }



        public ActionResult WorkerAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult WorkerAdd(Worker wrk)
        {
            if (ModelState.IsValid) 
            {
                db.Workers.Add(wrk);
                db.SaveChanges();

                return RedirectToAction("../Home/Index"); 
            }
            else 
            return RedirectToAction("WorkerAdd");
        }


        public ActionResult WorkerDel(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }

            return View(worker);
        }
        [HttpPost]

        public ActionResult WorkerDel(Worker worker)
        {

            Worker dataw = db.Workers
                .Where(o => o.Id == worker.Id)
                .FirstOrDefault();

            db.Workers.Remove(dataw);

            db.SaveChanges();
            return RedirectToAction("../Home/Index");
        }
    }
}
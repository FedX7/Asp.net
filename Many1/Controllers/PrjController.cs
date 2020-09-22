using Many1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Many1.Controllers
{
    public class PrjController : Controller
    {
        private TeamContext db = new TeamContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrjEdit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Workers = db.Workers.ToList();
            return View(project);
        }

        [HttpPost]
        public ActionResult PrjEdit(Project project, int[] selectedWorkers)
        {
            Project newProject = db.Projects.Find(project.Id);
            newProject.Name = project.Name;
            newProject.Leader = project.Leader;
            newProject.Customer = project.Customer;
            newProject.Performer = project.Performer;
            newProject.Priority = project.Priority;
            newProject.DateStart = project.DateStart;
            newProject.DateEnd = project.DateEnd;

            if (ModelState.IsValid)
            {
                newProject.Workers.Clear();
                if (selectedWorkers != null)
                {

                    foreach (var c in db.Workers.Where(co => selectedWorkers.Contains(co.Id)))
                    {
                        newProject.Workers.Add(c);
                    }
                }

                db.Entry(newProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            ViewBag.Workers = db.Workers.ToList();
            return View(project);
        }

        public ActionResult PrjAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PrjAdd(Project prj)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(prj);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            return View();
        }

        public ActionResult PrjDel(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }
        [HttpPost]
        public ActionResult PrjDel(Project project)
        {

            Project dataw = db.Projects
                .Where(o => o.Id == project.Id)
                .FirstOrDefault();

            db.Projects.Remove(dataw);

            db.SaveChanges();
            return RedirectToAction("../Home/Index");
        }



    }
}
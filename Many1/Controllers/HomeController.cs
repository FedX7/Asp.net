using Many1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Many1.Controllers
{
    public class HomeController : Controller
    {
        private TeamContext db = new TeamContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.Projects = db.Projects;
            ViewBag.Workers = db.Workers;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PrioritySortParm = sortOrder == "Priority" ? "Priority_desc" : "Priority";
            ViewBag.DateStartSortParm = sortOrder == "DateStart" ? "DateStart_desc" : "DateStart";
            ViewBag.DateEndSortParm = sortOrder == "DateEnd" ? "DateEnd_desc" : "DateEnd";

            var sorts = from s in db.Projects
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    sorts = sorts.OrderByDescending(s => s.Name);
                    break;
                case "Priority":
                    sorts = sorts.OrderBy(s => s.Priority);
                    break;
                case "Priority_desc":
                    sorts = sorts.OrderByDescending(s => s.Priority);
                    break;
                case "DateStart":
                    sorts = sorts.OrderBy(s => s.DateStart);
                    break;
                case "DateStart_desc":
                    sorts = sorts.OrderByDescending(s => s.DateStart);
                    break;
                case "DateEnd":
                    sorts = sorts.OrderBy(s => s.DateEnd);
                    break;
                case "DateEnd_desc":
                    sorts = sorts.OrderByDescending(s => s.DateEnd);
                    break;
                default:
                    sorts = sorts.OrderBy(s => s.Name);
                    break;
            }
            
            return View(sorts.ToList());
        }



    }
}
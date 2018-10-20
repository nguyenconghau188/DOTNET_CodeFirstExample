using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOTNET_CodeFirstExample.Models;

namespace DOTNET_CodeFirstExample.Controllers
{
    public class ProjectJoinsController : Controller
    {
        private ProjectManagement db = new ProjectManagement();

        // GET: ProjectJoins
        public ActionResult Index()
        {
            var projectJoin = db.ProjectJoin.Include(p => p.Employee).Include(p => p.Project);
            return View(projectJoin.ToList());
        }

        // GET: ProjectJoins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectJoin projectJoin = db.ProjectJoin.Find(id);
            if (projectJoin == null)
            {
                return HttpNotFound();
            }
            return View(projectJoin);
        }

        // GET: ProjectJoins/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FullName");
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectJoins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropjectJoinId,EmployeeId,ProjectId,StarDate,FinishDate")] ProjectJoin projectJoin)
        {
            if (ModelState.IsValid)
            {
                db.ProjectJoin.Add(projectJoin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FullName", projectJoin.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", projectJoin.ProjectId);
            return View(projectJoin);
        }

        // GET: ProjectJoins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectJoin projectJoin = db.ProjectJoin.Find(id);
            if (projectJoin == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FullName", projectJoin.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", projectJoin.ProjectId);
            return View(projectJoin);
        }

        // POST: ProjectJoins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropjectJoinId,EmployeeId,ProjectId,StarDate,FinishDate")] ProjectJoin projectJoin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectJoin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FullName", projectJoin.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", projectJoin.ProjectId);
            return View(projectJoin);
        }

        // GET: ProjectJoins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectJoin projectJoin = db.ProjectJoin.Find(id);
            if (projectJoin == null)
            {
                return HttpNotFound();
            }
            return View(projectJoin);
        }

        // POST: ProjectJoins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectJoin projectJoin = db.ProjectJoin.Find(id);
            db.ProjectJoin.Remove(projectJoin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

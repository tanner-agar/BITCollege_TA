using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BITCollege_TA.Data;
using BITCollege_TA.Models;

namespace BITCollege_TA.Controllers
{
    public class MasteryCoursesController : Controller
    {
        private BITCollege_TAContext db = new BITCollege_TAContext();

        // GET: MasteryCourses
        public ActionResult Index()
        {
            var masteryCourses = db.MasteryCourses.Include(m => m.AcademicProgram).ToList();
            return View(masteryCourses);
        }

        // GET: MasteryCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasteryCourse masteryCourse = (MasteryCourse)db.Courses.Find(id);
            if (masteryCourse == null)
            {
                return HttpNotFound();
            }
            return View(masteryCourse);
        }

        // GET: MasteryCourses/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            return View();
        }

        // POST: MasteryCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,MaximumAttempts")] MasteryCourse masteryCourse)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(masteryCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", masteryCourse.AcademicProgramId);
            return View(masteryCourse);
        }

        // GET: MasteryCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasteryCourse masteryCourse = (MasteryCourse)db.Courses.Find(id);
            if (masteryCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", masteryCourse.AcademicProgramId);
            return View(masteryCourse);
        }

        // POST: MasteryCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes,MaximumAttempts")] MasteryCourse masteryCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masteryCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", masteryCourse.AcademicProgramId);
            return View(masteryCourse);
        }

        // GET: MasteryCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasteryCourse masteryCourse = (MasteryCourse)db.Courses.Find(id);
            if (masteryCourse == null)
            {
                return HttpNotFound();
            }
            return View(masteryCourse);
        }

        // POST: MasteryCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasteryCourse masteryCourse = (MasteryCourse)db.Courses.Find(id);
            db.Courses.Remove(masteryCourse);
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

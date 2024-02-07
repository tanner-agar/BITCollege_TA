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
    public class AuditCoursesController : Controller
    {
        private BITCollege_TAContext db = new BITCollege_TAContext();

        // GET: AuditCourses
        public ActionResult Index()
        {
            var auditCourses = db.AuditCourses.Include(m => m.AcademicProgram).ToList();
            return View(auditCourses);
        }

        // GET: AuditCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditCourse auditCourse = (AuditCourse)db.Courses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            return View(auditCourse);
        }

        // GET: AuditCourses/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            return View();
        }

        // POST: AuditCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes")] AuditCourse auditCourse)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(auditCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // GET: AuditCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditCourse auditCourse = (AuditCourse)db.Courses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // POST: AuditCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,Notes")] AuditCourse auditCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", auditCourse.AcademicProgramId);
            return View(auditCourse);
        }

        // GET: AuditCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditCourse auditCourse = (AuditCourse)db.Courses.Find(id);
            if (auditCourse == null)
            {
                return HttpNotFound();
            }
            return View(auditCourse);
        }

        // POST: AuditCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuditCourse auditCourse = (AuditCourse)db.Courses.Find(id);
            db.Courses.Remove(auditCourse);
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

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
    public class GradedCoursesController : Controller
    {
        private BITCollege_TAContext db = new BITCollege_TAContext();

        // GET: GradedCourses
        public ActionResult Index()
        {
            var gradedCourses = db.GradedCourses.Include(g => g.AcademicProgram).ToList();
            return View(gradedCourses);
        }

        // GET: GradedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // GET: GradedCourses/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            return View();
        }

        // POST: GradedCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,AssignmentWeight,ExamWeight")] GradedCourse gradedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(gradedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // POST: GradedCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,AcademicProgramId,CourseNumber,Title,CreditHours,TuitionAmount,AssignmentWeight,ExamWeight")] GradedCourse gradedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", gradedCourse.AcademicProgramId);
            return View(gradedCourse);
        }

        // GET: GradedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            if (gradedCourse == null)
            {
                return HttpNotFound();
            }
            return View(gradedCourse);
        }

        // POST: GradedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradedCourse gradedCourse = (GradedCourse)db.Courses.Find(id);
            db.Courses.Remove(gradedCourse);
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

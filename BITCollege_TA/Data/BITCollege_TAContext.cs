using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BITCollege_TA.Models;
namespace BITCollege_TA.Data
{
    public class BITCollege_TAContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BITCollege_TAContext() : base("name=BITCollege_TAContext")
        {
            Console.WriteLine("BITCollege_TAContext constructor called.");
        }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.GradedCourse> GradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.MasteryCourse> MasteryCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.SuspendedState> SuspendedStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.AuditCourse> AuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.AcademicProgram> AcademicPrograms { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.GradePointState> GradePointStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.Registration> Registrations { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TA.Models.HonoursState> HonoursState { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.ProbationState> ProbationState { get; set; }
        
        public System.Data.Entity.DbSet<BITCollege_TA.Models.RegularState> RegularState { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TA.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextUniqueNumber> NextUniqueNumbers { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextAuditCourse> NextAuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextGradedCourse> NextGradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextMasteryCourse> NextMasteryCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextRegistration> NextRegistrations { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TA.Models.NextStudent> NextStudents { get; set; }
    }
}

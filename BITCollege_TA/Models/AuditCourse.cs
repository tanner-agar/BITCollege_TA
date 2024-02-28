using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class AuditCourse : Course 
    { 
        public override void SetNextCourseNumber()
        {
            CourseNumber = "A-";
            long? nextNum = StoredProcedure.NextNumber("A");
            string appendString = CourseNumber + nextNum.ToString();
            if (nextNum != null)
            {
                CourseNumber += nextNum.ToString();
            }
        }
    }


}
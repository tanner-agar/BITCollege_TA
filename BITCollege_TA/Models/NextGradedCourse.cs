using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class NextGradedCourse : NextUniqueNumber
    {
        private static NextGradedCourse _nextGradedCourse;

        private NextGradedCourse() 
        {
            NextAvailableNumber = 200000;
            db = new BITCollege_TAContext();
        }

        public static NextGradedCourse GetInstance()
        {
            if (_nextGradedCourse == null)
            {
                _nextGradedCourse = db.NextGradedCourses.SingleOrDefault();

                if (_nextGradedCourse == null)
                {
                    _nextGradedCourse = new NextGradedCourse();
                    db.NextUniqueNumbers.Add(_nextGradedCourse);
                    db.SaveChanges();

                }
            }
            return _nextGradedCourse;
        }

    }
}
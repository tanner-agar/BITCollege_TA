using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class NextAuditCourse : NextUniqueNumber
    {
        private static NextAuditCourse _nextAuditCourse;

        private NextAuditCourse()
        {
            NextAvailableNumber = 2000;
            db = new BITCollege_TAContext();
        }

        public static NextAuditCourse GetInstance()
        {
            if (_nextAuditCourse == null)
            {
                _nextAuditCourse = db.NextAuditCourses.SingleOrDefault();

                if (_nextAuditCourse == null)
                {
                    _nextAuditCourse = new NextAuditCourse();
                    db.NextUniqueNumbers.Add(_nextAuditCourse);
                    db.SaveChanges();

                }
            }
            return _nextAuditCourse;
        }
    }
}
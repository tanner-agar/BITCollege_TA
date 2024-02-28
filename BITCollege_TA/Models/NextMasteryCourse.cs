using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class NextMasteryCourse : NextUniqueNumber
    {
        private static NextMasteryCourse _nextMasteryCourse;

        private NextMasteryCourse() 
        {
            NextAvailableNumber = 20000;
            db = new BITCollege_TAContext();
        }

        public static NextMasteryCourse GetInstance()
        {
            if (_nextMasteryCourse == null)
            {
                _nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();

                if (_nextMasteryCourse == null)
                {
                    _nextMasteryCourse = new NextMasteryCourse();
                    db.NextUniqueNumbers.Add(_nextMasteryCourse);
                    db.SaveChanges();

                }
            }
            return _nextMasteryCourse;
        }
    }
}
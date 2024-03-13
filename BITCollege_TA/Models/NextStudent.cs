using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class NextStudent : NextUniqueNumber
    {
        private static NextStudent _nextStudent;

        private NextStudent()
        {
            //set next available number
            NextAvailableNumber = 20000000;
            db = new BITCollege_TAContext();
        }

        public static NextStudent GetInstance()
        {
            if (_nextStudent == null)
            {
                _nextStudent = db.NextStudents.SingleOrDefault();

                if (_nextStudent == null)
                {
                    _nextStudent = new NextStudent();
                    db.NextUniqueNumbers.Add(_nextStudent);
                    db.SaveChanges();
                }
            }
            return _nextStudent;
        }
    }
}
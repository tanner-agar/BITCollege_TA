using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class NextRegistration : NextUniqueNumber
    {
        private static NextRegistration _nextRegistration;

        private NextRegistration()
        {
            NextAvailableNumber = 700;
            db = new BITCollege_TAContext();
        }

        public static NextRegistration GetInstance()
        {
            if (_nextRegistration == null)
            {
                _nextRegistration = db.NextRegistrations.SingleOrDefault();

                if (_nextRegistration == null)
                {
                    _nextRegistration = new NextRegistration();
                    db.NextUniqueNumbers.Add(_nextRegistration);
                    db.SaveChanges();

                }
            }
            return _nextRegistration;
        }
    }
}
using BITCollege_TA.Data;
using BITCollege_TA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace BITCollege_TA.Models
{
    public class SuspendedState : GradePointState
    {
        //instance class
        //preventing the constructor of singleton, from being accessed outside class definition
        //private static instance of class
        private static SuspendedState _populatedObject;

        //no public constructors
        private SuspendedState()
        {
            LowerLimit = 0.00;
            UpperLimit = 1.00;
            TuitionRateFactor = 1.1;
            db = new BITCollege_TAContext();
        }


        public static SuspendedState GetInstance()
        {
            // check if the instance is null
            if (_populatedObject == null)
            {
                // use inherited data context object; calling SingleOrDefault to tell if a record of this type exists in the database
                _populatedObject = db.SuspendedStates.SingleOrDefault();

                // persist to database if null
                if (_populatedObject == null)
                {
                    _populatedObject = new SuspendedState();
                    db.GradePointStates.Add(_populatedObject);
                    db.SaveChanges();
                }
            }
            return _populatedObject;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                // One way to ProbationState if GPA exceeds SuspendedState's upper limit
                // track state
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
                stateChanged = true;
            }
            else
            {
                stateChanged = false;
            }
        }

        public override void TuitionRateAdjustment(Student student)
        {

            //refer from/to HonoursState for pattern
            double charge = 0.10;

            if (student.GradePointAverage < 0.75)
            {
                charge += 0.02;
            }

            if (student.GradePointAverage < 0.50)
            {
                charge += 0.05;
            }

            double calculateFinalTuition = student.OutstandingFees * (1 + charge);
            student.OutstandingFees = calculateFinalTuition - student.OutstandingFees;
        }
    }
}

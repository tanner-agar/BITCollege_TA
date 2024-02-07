using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Linq;
using BITCollege_TA.Data;
using System.Web;
using BITCollege_TA.Models;

namespace BITCollege_TA.Models
{

        public class HonoursState : GradePointState
        {
            private static HonoursState _populatedObject;
            public HonoursState()
            {
                LowerLimit = 3.70;
                UpperLimit = 4.50;
                TuitionRateFactor = 0.9;
                db = new BITCollege_TAContext();
        }

            public static HonoursState GetInstance()
            {

            // Check if the instance is null
            if (_populatedObject == null)
            {
                // Use the inherited data context object to determine if a record of this type exists in the database
                _populatedObject = db.HonoursState.SingleOrDefault();

                // If no record exists in the database, create a new instance and persist it
                if (_populatedObject == null)
                {
                    _populatedObject = new HonoursState();
                    db.GradePointStates.Add(_populatedObject);
                    db.SaveChanges();
                }
            }
            return _populatedObject;
        }
        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage < LowerLimit)
            {
                // Move to RegularState if GPA falls below HonoursState's lower limit
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
                stateChanged = true;

            }
            else
            {
                stateChanged = false;
            }
        }
        public override void TuitionRateAdjustment(Student student)
        {
            //store our discounting and add/increment the percents as we make decisions
            double discount = 0;

            //10% off initial
            discount += 0.10;

            if(student.Registration.Count >= 5)
            {
                discount += 0.05;
            }

            if(student.GradePointAverage > 4.25)
            {
                discount += 0.02;
            }

            // calculate the final free, i.e. 17% being accumulated discount. 1 - .17 = .83 then multiply by student.OutstandingFees, and subtract the outcome with outstanding fees
            double calculateFinalTuition = student.OutstandingFees * (1 - discount);
            student.OutstandingFees = calculateFinalTuition - student.OutstandingFees;
        }
    }

}

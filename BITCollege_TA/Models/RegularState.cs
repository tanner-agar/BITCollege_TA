using BITCollege_TA.Data;
using System.Linq;

namespace BITCollege_TA.Models

    {
        public class RegularState : GradePointState
        
        {
            private static RegularState _populatedObject;
                private RegularState()
                {
                    LowerLimit = 2.00;
                    UpperLimit = 3.70;
                    TuitionRateFactor = 1.0;
                 }

                public static RegularState GetInstance()
                {
                if (_populatedObject == null)
                {
                    _populatedObject = db.RegularState.SingleOrDefault();

                    if (_populatedObject == null)
                    {
                        _populatedObject = new RegularState();
                        db.GradePointStates.Add(_populatedObject);
                        db.SaveChanges();
                    }
                }
                return _populatedObject;
                }
            public override void StateChangeCheck(Student student)
            {
                //change state based on lower and upper limits, or boundaries of RegularState
                if (student.GradePointAverage < LowerLimit)
                {
                    student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
                }
                else if (student.GradePointAverage > UpperLimit)
                {
                    student.GradePointStateId = HonoursState.GetInstance().GradePointStateId;
                }
            }

            public override void TuitionRateAdjustment(Student student)
            {
            }
        }

}

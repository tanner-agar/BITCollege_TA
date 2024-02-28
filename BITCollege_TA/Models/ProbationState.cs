using BITCollege_TA.Data;
using System.Linq;
namespace BITCollege_TA.Models

{
    public class ProbationState : GradePointState
    {
        private static ProbationState _populatedObject;

        private ProbationState()
        {
            LowerLimit = 1.00;
            UpperLimit = 2.00;
            TuitionRateFactor = 1.075;
            db = new BITCollege_TAContext();
        }



      public static ProbationState GetInstance()
      {
        if (_populatedObject == null)
        {
            _populatedObject = db.ProbationState.SingleOrDefault();

            if (_populatedObject == null)
            {
                _populatedObject = new ProbationState();
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
            // move to SuspendedState if GPA falls below ProbationState's lower limit
            // track state change
            student.GradePointStateId = SuspendedState.GetInstance().GradePointStateId;
            stateChanged = true;
        }
        else if (student.GradePointAverage > UpperLimit)
        {
            // move to RegularState if GPA exceeds ProbationState's upper limit
            // track state change
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
            double charge = 0.075;

            if (student.Registration.Count >= 5)
            {
                charge -= 0.035;
            }

            double finalTuition = student.OutstandingFees * (1 + charge);
            student.OutstandingFees = finalTuition - student.OutstandingFees;
    }
  }
}






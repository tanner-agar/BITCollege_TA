using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {

        [OperationContract]
        //return bool
        bool DropCourse(int registrationId);

        [OperationContract]
        //return int
        int RegisterCourse(int studentid, int courseId, string notes);

        [OperationContract]
        //return double?
        double? UpdateGrade(double grade, int registrationId, string notes);

    }
}

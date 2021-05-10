using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vkbdbwebapi.Models
{
    public class stud
    {
        public bool insertstudentbyEF(student studentrequest, ref string Errormessage)
        {
            bool result = false;
            try
            {
                using (project1Entities1 p1e = new project1Entities1())
                {
                    student record = new student();

                    record.studentid = studentrequest.studentid;
                    record.firstname = studentrequest.firstname;
                    record.lastname = studentrequest.lastname;
                    record.genderid = Convert.ToByte(studentrequest.genderid);
                    record.DOB = Convert.ToDateTime(studentrequest.DOB.ToString());
                    record.emailid = studentrequest.emailid;
                    record.location = studentrequest.location;
                    p1e.student.Add(record);
                    p1e.SaveChanges();
                    result = true;


                }
            }
            catch (Exception ex)
            {
                Errormessage = ex.Message;
            }
            return result;
        }
    }
}

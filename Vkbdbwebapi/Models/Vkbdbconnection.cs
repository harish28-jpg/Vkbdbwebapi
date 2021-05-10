using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Vkbdbwebapi.Models
{
    public class Vkbdbconnection
    {
        public bool insertstudent(studentinsertrequest studentrequest, ref string Errormessage)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Vkbdbconnection"].ToString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "insertstudent";
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@studentid", studentrequest.studentid);
                        cmd.Parameters.AddWithValue("@firstname", studentrequest.firstname);
                        cmd.Parameters.AddWithValue("@lastname", studentrequest.lastname);
                        cmd.Parameters.AddWithValue("@genderid", studentrequest.genderid);
                        cmd.Parameters.AddWithValue("@DOB", studentrequest.DOB);
                        cmd.Parameters.AddWithValue("@emailid", studentrequest.emailid);
                        cmd.Parameters.AddWithValue("@location", studentrequest.location);
                        using (DataTable dt = new DataTable())
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    if (bool.Parse(dt.Rows[0]["updated"].ToString()) == true)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        Errormessage = dt.Rows[0]["Errormessage"] != null ? dt.Rows[0]["Errormessage"].ToString() : string.Empty;

                                    }
                                }
                                }
                            }
                        }

                        conn.Close();
                    }
                }

                
                catch (Exception ex)
            {
                Errormessage = ex.Message;
            }
            return result;

        }


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

        public bool insertfriendEF(friend friendrequest,ref string Errormessage)
        {
            bool result = false;
            try
            {
                using(project1Entities2 p2e=new project1Entities2())
                {
                    friend record = new friend();
                    record.fid = friendrequest.fid;
                    record.fname = friendrequest.fname;
                    record.genderid = Convert.ToByte(friendrequest.genderid);
                    record.fathername = friendrequest.fathername;
                    record.DOB = Convert.ToDateTime(friendrequest.DOB.ToString());
                    record.location = friendrequest.location;
                    p2e.friend.Add(record);
                    p2e.SaveChanges();
                    result = true;

                }
            }
            catch(Exception ex)
            {
                Errormessage = ex.Message;
            }
            return result;
        }

    }

    public class studentinsertrequest
    {
        public int studentid { set; get; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public int genderid { set; get; }
        public  string DOB { set; get; }
        public string emailid { set; get; }
        public string location { set; get; }


    }
}
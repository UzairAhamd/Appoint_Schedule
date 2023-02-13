using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Appointment_Scheduling_Project.BusinessLayer;
using Microsoft.Extensions.Configuration;
using Appointment_Scheduling_Project.Model;

namespace Appointment_Scheduling_Project.DataLayer
{
    public class SQLDataHelper : ISQLDataHelper
    {
        private readonly IConfiguration _configuration;
        string connectionString = "Data Source = cmdlhrltx318; Initial Catalog = SchedulingAssignemnt1; Integrated Security = True";
        public int LoginData(string UserName, string Password)
        {
            {
                int check;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    check = cmd.ExecuteNonQuery(); 
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        check= Convert.ToInt32(sdr["Returned"]);
                    }
                    con.Close();
                }
                return check;
            }
        }
        public UnitPatient GetPatientData(string UserName, string PatName)
        {
            UnitPatient Patient_Obj = new UnitPatient();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PatName", PatName); 
                cmd.ExecuteNonQuery(); 
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Patient_Obj.PatID = Convert.ToInt32(sdr["PatID"]);
                    Patient_Obj.UserName = sdr["UserName"].ToString();
                    Patient_Obj.FirstName = sdr["FirstName"].ToString();
                    Patient_Obj.LastName = sdr["LastName"].ToString();
                    Patient_Obj.PhoneNumber = Convert.ToInt32(sdr["PhoneNumber"]);
                    Patient_Obj.vPassword = sdr["vPassword"].ToString();
                    if (sdr["DOB"] != DBNull.Value)
                    {
                        Patient_Obj.DOB = Convert.ToDateTime(sdr["DOB"]);
                    }
                    if (sdr["InDate"] != DBNull.Value)
                    {
                        Patient_Obj.InDate = Convert.ToDateTime(sdr["InDate"]);
                    }
                    if (sdr["OutDate"] != DBNull.Value)
                    {
                        Patient_Obj.OutDate = Convert.ToDateTime(sdr["OutDate"]);
                    }
                    Patient_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                }
                con.Close();
            }
            return Patient_Obj;
        }
        public UnitEmployee GetEmployeeData(string UserName, string EmpName)
        {
            UnitEmployee Employee_Obj = new UnitEmployee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.ExecuteNonQuery(); SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Employee_Obj.EmpID = Convert.ToInt32(sdr["EmpID"]);
                    Employee_Obj.EmpIdentifier = sdr["EmpIdentifier"].ToString();
                    Employee_Obj.UserName = sdr["UserName"].ToString();
                    Employee_Obj.FirstName = sdr["FirstName"].ToString();
                    Employee_Obj.LastName = sdr["LastName"].ToString();
                    Employee_Obj.PhoneNumber = Convert.ToInt32(sdr["PhoneNumber"]); 
                    Employee_Obj.EmpPassword = sdr["EmpPassword"].ToString();
                    if (sdr["Experience"] != DBNull.Value)
                    {
                        Employee_Obj.Experience = Convert.ToInt32(sdr["Experience"]);
                    }
                    Employee_Obj.Available = Convert.ToBoolean(sdr["Available"]);
                    Employee_Obj.SpecialityCode = sdr["SpecialityCode"].ToString();
                    if (sdr["DOB"] != DBNull.Value)
                    {
                        Employee_Obj.DOB = Convert.ToDateTime(sdr["DOB"]);
                    }
                    if (sdr["CreateDate"] != DBNull.Value)
                    {
                        Employee_Obj.CreateDate = Convert.ToDateTime(sdr["CreateDate"]);
                    }
                    Employee_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                }
                con.Close();
            }
            return Employee_Obj;
        }


        public List<UnitPatient> GetPatientsData(string UserName, string Segregator)
        {
            List<UnitPatient> lstPatients = new List<UnitPatient>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPatients", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@Segregator", Segregator);
                cmd.ExecuteNonQuery(); SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UnitPatient Patient_Obj = new UnitPatient();

                    Patient_Obj.PatID = Convert.ToInt32(sdr["PatID"]);
                    Patient_Obj.UserName = sdr["UserName"].ToString();
                    Patient_Obj.FirstName = sdr["FirstName"].ToString();
                    Patient_Obj.LastName = sdr["LastName"].ToString();
                    Patient_Obj.PhoneNumber = Convert.ToInt32(sdr["PhoneNumber"]); 
                    Patient_Obj.vPassword = sdr["vPassword"].ToString();
                    if (sdr["DOB"] != DBNull.Value)
                    {
                        Patient_Obj.DOB = Convert.ToDateTime(sdr["DOB"]);
                    }
                    if (sdr["InDate"] != DBNull.Value)
                    {
                        Patient_Obj.InDate = Convert.ToDateTime(sdr["InDate"]);
                    }
                    if (sdr["OutDate"] != DBNull.Value)
                    {
                        Patient_Obj.OutDate = Convert.ToDateTime(sdr["OutDate"]);
                    }
                    Patient_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                    lstPatients.Add(Patient_Obj);
                }
                con.Close();
            }
            return lstPatients;
        }

        public List<UnitDTO> GetProvidersData(string UserName, string Segregator)
        {
            List<UnitDTO> lstEmployee = new List<UnitDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllProviders", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@Segregator", Segregator); 
                cmd.ExecuteNonQuery(); SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UnitDTO Employee_Obj = new UnitDTO();
                    Employee_Obj.EmpID = Convert.ToInt32(sdr["EmpID"]);
                    Employee_Obj.EmpIdentifier = sdr["EmpIdentifier"].ToString();
                    Employee_Obj.UserName = sdr["UserName"].ToString();
                    Employee_Obj.FirstName = sdr["FirstName"].ToString();
                    Employee_Obj.LastName = sdr["LastName"].ToString();
                    Employee_Obj.PhoneNumber = Convert.ToInt32(sdr["PhoneNumber"]);
                    Employee_Obj.EmpPassword = sdr["EmpPassword"].ToString();
                    if (sdr["Experience"] != DBNull.Value)
                    {
                        Employee_Obj.Experience = Convert.ToInt32(sdr["Experience"]);
                    }
                    Employee_Obj.Available = Convert.ToBoolean(sdr["Available"]);
                    Employee_Obj.SpecialityCode = sdr["SpecialityCode"].ToString();
                    Employee_Obj.Speciality= sdr["Speciality"].ToString();
                    if (sdr["DOB"] != DBNull.Value)
                    {
                        Employee_Obj.DOB = Convert.ToDateTime(sdr["DOB"]);
                    }
                    if (sdr["CreateDate"] != DBNull.Value)
                    {
                        Employee_Obj.CreateDate = Convert.ToDateTime(sdr["CreateDate"]);
                    }
                    Employee_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                    lstEmployee.Add(Employee_Obj);
                }
                con.Close();
            }
            return lstEmployee;
        }
        public List<UnitAppointment> GeOwnerAppointmentsData(string UserName, string OwnerName, string Segregator)
        {
            List<UnitAppointment> lstAppointments = new List<UnitAppointment>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllAppointmentOf", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@OwnerName", OwnerName); 
                cmd.Parameters.AddWithValue("@Segregator", Segregator);
                cmd.ExecuteNonQuery(); SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UnitAppointment Appointment_Obj = new UnitAppointment();

                    Appointment_Obj.AptID = Convert.ToInt32(sdr["AptID"]);
                    Appointment_Obj.PatientName = sdr["PatientName"].ToString();
                    Appointment_Obj.ProviderName = sdr["ProviderName"].ToString();
                    Appointment_Obj.Title = sdr["Title"].ToString();
                    Appointment_Obj.AptDescription = sdr["AptDescription"].ToString();
                    Appointment_Obj.SeverityLevel = sdr["SeverityLevel"].ToString();
                    if (sdr["StartTime"] != DBNull.Value)
                    {
                        Appointment_Obj.StartTime = Convert.ToDateTime(sdr["StartTime"]);
                    }
                    if (sdr["EndTime"] != DBNull.Value)
                    {
                        Appointment_Obj.EndTime = Convert.ToDateTime(sdr["EndTime"]);
                    }
                    Appointment_Obj.StatusCode = sdr["StatusCode"].ToString();
                    Appointment_Obj.Comment = sdr["Comment"].ToString();
                    Appointment_Obj.InitiatedBy = sdr["InitiatedBy"].ToString();

                    Appointment_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                    lstAppointments.Add(Appointment_Obj);
                }
                con.Close();
            }
            return lstAppointments;
        }

        public List<UnitAppointment> GeEveryAppointmentData(string UserName, string Segregator)
        {
            List<UnitAppointment> lstAppointments = new List<UnitAppointment>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEveryAppointment", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@Segregator", Segregator);
                cmd.ExecuteNonQuery(); SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UnitAppointment Appointment_Obj = new UnitAppointment();

                    Appointment_Obj.AptID = Convert.ToInt32(sdr["AptID"]);
                    Appointment_Obj.PatientName = sdr["PatientName"].ToString();
                    Appointment_Obj.ProviderName = sdr["ProviderName"].ToString();
                    Appointment_Obj.Title = sdr["Title"].ToString();
                    Appointment_Obj.AptDescription = sdr["AptDescription"].ToString();
                    Appointment_Obj.SeverityLevel = sdr["SeverityLevel"].ToString();
                    if (sdr["StartTime"] != DBNull.Value)
                    {
                        Appointment_Obj.StartTime = Convert.ToDateTime(sdr["StartTime"]);
                    }
                    if (sdr["EndTime"] != DBNull.Value)
                    {
                        Appointment_Obj.EndTime = Convert.ToDateTime(sdr["EndTime"]);
                    }
                    Appointment_Obj.StatusCode = sdr["StatusCode"].ToString();
                    Appointment_Obj.Comment = sdr["Comment"].ToString();
                    Appointment_Obj.InitiatedBy = sdr["InitiatedBy"].ToString();

                    Appointment_Obj.IsDeleted = Convert.ToBoolean(sdr["IsDeleted"]);
                    lstAppointments.Add(Appointment_Obj);
                }
                con.Close();
            }
            return lstAppointments;
        }
        public string AddEmployeeData(UnitEmployee UnitEmp, string Name)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", Name);
                cmd.Parameters.AddWithValue("@EmpIdentifier", UnitEmp.EmpIdentifier);
                cmd.Parameters.AddWithValue("@EmpName", UnitEmp.UserName);
                cmd.Parameters.AddWithValue("@FirstName", UnitEmp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", UnitEmp.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", UnitEmp.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmpPassword", UnitEmp.EmpPassword);
                cmd.Parameters.AddWithValue("@Experience", UnitEmp.Experience);
                cmd.Parameters.AddWithValue("@Available", UnitEmp.Available);
                cmd.Parameters.AddWithValue("@SpecialityCode", UnitEmp.SpecialityCode);
                cmd.Parameters.AddWithValue("@DOB", UnitEmp.DOB);
                cmd.Parameters.AddWithValue("@IsDeleted", UnitEmp.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Employee Added";
        }
        public string AddPatientData(UnitPatient unitPatient, string Name)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPatient", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", Name); 
                cmd.Parameters.AddWithValue("@Name", unitPatient.UserName); 
                cmd.Parameters.AddWithValue("@FirstName", unitPatient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", unitPatient.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", unitPatient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", unitPatient.vPassword);
                cmd.Parameters.AddWithValue("@DOB", unitPatient.DOB);
                cmd.Parameters.AddWithValue("@InDate", unitPatient.InDate);
                cmd.Parameters.AddWithValue("@OutDate", unitPatient.OutDate);
                cmd.Parameters.AddWithValue("@IsDeleted", unitPatient.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Patient Added";
        }
        public string AddAppointmentData(UnitAppointment unitAppointment, string UserName)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInitiateAppt", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@PatientName", unitAppointment.PatientName); 
                cmd.Parameters.AddWithValue("@ProviderName", unitAppointment.ProviderName);
                cmd.Parameters.AddWithValue("@Title", unitAppointment.Title);
                cmd.Parameters.AddWithValue("@AptDescription", unitAppointment.AptDescription);
                cmd.Parameters.AddWithValue("@SeverityLevel", unitAppointment.SeverityLevel);
                cmd.Parameters.AddWithValue("@StartTime", unitAppointment.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", unitAppointment.EndTime);
                cmd.Parameters.AddWithValue("@Comment", "");
                cmd.Parameters.AddWithValue("@IsDeleted", unitAppointment.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            else if (check == -2)
                return "Patient Deleted";
            else if (check == -3)
                return "Provider Deleted";
            else if (check == -4)
                return "Patient Doesn't Exist";
            else if (check == -5)
                return "Provider Doesn't Exist";
            return "Appointment Created";
        }
        public string AddAppointmentCommentData(string UserName, int AptID, string Comment)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAptComment", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@AptID", AptID); 
                cmd.Parameters.AddWithValue("@Comment", Comment);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Comment Created";
        }


        public string UpdatePatientData(UnitPatient unitPatient, string Name)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePatient", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", Name); 
                cmd.Parameters.AddWithValue("@PatName", unitPatient.UserName);
                cmd.Parameters.AddWithValue("@FirstName", unitPatient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", unitPatient.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", unitPatient.PhoneNumber);
                cmd.Parameters.AddWithValue("@vPassword", unitPatient.vPassword);
                cmd.Parameters.AddWithValue("@DOB", unitPatient.DOB);
                cmd.Parameters.AddWithValue("@InDate", unitPatient.InDate);
                cmd.Parameters.AddWithValue("@OutDate", unitPatient.OutDate);
                cmd.Parameters.AddWithValue("@IsDeleted", unitPatient.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Patient Updated";
        }

        public string UpdateEmployeeData(UnitEmployee unitEmployee, string Name)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", Name); 
                cmd.Parameters.AddWithValue("@EmpIdentifier", unitEmployee.EmpIdentifier);
                cmd.Parameters.AddWithValue("@EmpName", unitEmployee.UserName); 
                cmd.Parameters.AddWithValue("@FirstName", unitEmployee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", unitEmployee.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", unitEmployee.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmpPassword", unitEmployee.EmpPassword);
                cmd.Parameters.AddWithValue("@Experience", unitEmployee.Experience);
                cmd.Parameters.AddWithValue("@Available", unitEmployee.Available);
                cmd.Parameters.AddWithValue("@SpecialityCode", unitEmployee.SpecialityCode);
                cmd.Parameters.AddWithValue("@DOB", unitEmployee.DOB);
                cmd.Parameters.AddWithValue("@CreateDate", unitEmployee.CreateDate);
                cmd.Parameters.AddWithValue("@IsDeleted", unitEmployee.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Employee Updated";
        }
        public string UpdateAppointmentData(UnitAppointment unitAppointment, string UserName)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateAppt", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@AptID", unitAppointment.AptID); 
                cmd.Parameters.AddWithValue("@PatientName", unitAppointment.PatientName);
                cmd.Parameters.AddWithValue("@ProviderName", unitAppointment.ProviderName);
                cmd.Parameters.AddWithValue("@Title", unitAppointment.Title);
                cmd.Parameters.AddWithValue("@AptDescription", unitAppointment.AptDescription);
                cmd.Parameters.AddWithValue("@SeverityLevel", unitAppointment.SeverityLevel);
                cmd.Parameters.AddWithValue("@StartTime", unitAppointment.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", unitAppointment.EndTime);
                cmd.Parameters.AddWithValue("@Comment", unitAppointment.Comment);
                cmd.Parameters.AddWithValue("@StatusCode", unitAppointment.StatusCode);
                cmd.Parameters.AddWithValue("@InitiatedBy", unitAppointment.InitiatedBy);
                cmd.Parameters.AddWithValue("@IsDeleted", unitAppointment.IsDeleted);
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Appointment Updated";
        }


        public string RemovePatientData(string UserName, string PatName)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRemovePat", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@PatName", PatName); 
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Patient Removed with related Appointments";
        }
        public string RemoveEmployeeData(string UserName, string EmpName)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRemoveEmp", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@EmpName", EmpName); 
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Employee Removed with related Appointments";
        }

        public string RemoveAppointmentData(string UserName, int AptID)
        {
            int check;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRemoveApp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@AptID", AptID); 
                check = cmd.ExecuteNonQuery(); con.Close();
            }
            if (check == -1)
                return "Invalid";
            return "Appointment Removed";
        }

    }
}

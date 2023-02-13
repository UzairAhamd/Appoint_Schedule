using System;
using System.Collections.Generic;
using Appointment_Scheduling_Project.Model;

namespace Appointment_Scheduling_Project.BusinessLayer
{
    public class AppointmentBuisness : IAppointmentBuisness
    {
        //DAL to BAL Dependency Injection 
        ISQLDataHelper _sqlDataHelper;
        public AppointmentBuisness(ISQLDataHelper sqlDataHelper)
        {
            this._sqlDataHelper = sqlDataHelper;
        }

        public object LoginData(UnitDTO unitDTO)
        {
            int check;
            string UserName = unitDTO.UserName;
            string Password = unitDTO.Password;
            UnitEmployee unitEmployee = new UnitEmployee();
            UnitPatient unitPatient = new UnitPatient();
            check = this._sqlDataHelper.LoginData(UserName, Password);
            if (check == 101)
            { 
                string PatName = UserName;
                return unitPatient=this._sqlDataHelper.GetPatientData(UserName, PatName);
            }
            else if(check == 102)
            {
                string EmpName = UserName;
                return unitEmployee = this._sqlDataHelper.GetEmployeeData(UserName, EmpName);
            }
            return "Invalid Credentials";

        }
        public UnitPatient GetPatientData(string UserName, string PatName)
        {
            return this._sqlDataHelper.GetPatientData(UserName,PatName);
        }


        public UnitEmployee GetEmployeeData(string UserName, string EmpName)
        {
            return this._sqlDataHelper.GetEmployeeData(UserName, EmpName);
        }

        public List<UnitPatient> GetPatientsData(string UserName, string Segregator)

        {
            return this._sqlDataHelper.GetPatientsData(UserName, Segregator);

        }

        public List<UnitDTO> GetProvidersData(string UserName, string Segregator)
        {
            return this._sqlDataHelper.GetProvidersData(UserName, Segregator);

        }

        public List<UnitAppointment> GeOwnerAppointmentsData(string UserName, string OwnerName, string Segregator)
        {
            return this._sqlDataHelper.GeOwnerAppointmentsData(UserName, OwnerName,Segregator);

        }

        public List<UnitAppointment> GeEveryAppointmentData(string UserName, string Segregator)
        {
            return this._sqlDataHelper.GeEveryAppointmentData(UserName, Segregator);

        }
        public string AddEmployeeData(UnitDTO unitDTO)
        {
            UnitEmployee UnitEmp = new UnitEmployee();
            string Name = unitDTO.Name;
            UnitEmp.EmpIdentifier = unitDTO.EmpIdentifier;
            UnitEmp.UserName = unitDTO.UserName;
            UnitEmp.FirstName = unitDTO.FirstName;
            UnitEmp.LastName = unitDTO.LastName;
            UnitEmp.PhoneNumber = unitDTO.PhoneNumber;
            UnitEmp.EmpPassword = unitDTO.EmpPassword;
            UnitEmp.Experience = unitDTO.Experience;
            UnitEmp.Available = unitDTO.Available;
            UnitEmp.SpecialityCode = unitDTO.SpecialityCode;
            UnitEmp.DOB = unitDTO.DOB;
            UnitEmp.IsDeleted = unitDTO.IsDeleted;

            return this._sqlDataHelper.AddEmployeeData(UnitEmp, Name);

        }


        public string AddPatientData(UnitDTO unitDTO)
        {
            UnitPatient unitPatient = new UnitPatient();
            string Name = unitDTO.UserName;
            unitPatient.UserName = unitDTO.Name;
            unitPatient.FirstName = unitDTO.FirstName;
            unitPatient.LastName = unitDTO.LastName;
            unitPatient.PhoneNumber = unitDTO.PhoneNumber;
            unitPatient.vPassword = unitDTO.vPassword;
            unitPatient.DOB = unitDTO.DOB;
            unitPatient.InDate = unitDTO.InDate;
            unitPatient.OutDate = unitDTO.OutDate;
            unitPatient.IsDeleted = unitDTO.IsDeleted;
            return this._sqlDataHelper.AddPatientData(unitPatient, Name);
        }

        public string AddAppointmentData(UnitDTO unitDTO)
        {
            UnitAppointment unitAppointment = new UnitAppointment();
            string UserName = unitDTO.UserName;
            unitAppointment.PatientName = unitDTO.PatientName;
            unitAppointment.ProviderName = unitDTO.ProviderName;
            unitAppointment.Title = unitDTO.Title;
            unitAppointment.AptDescription = unitDTO.AptDescription;
            unitAppointment.SeverityLevel = unitDTO.SeverityLevel;
            unitAppointment.StartTime = unitDTO.StartTime;
            unitAppointment.EndTime= unitDTO.EndTime;
            unitAppointment.Comment = unitDTO.Comment;
            unitAppointment.IsDeleted = unitDTO.IsDeleted;
            return this._sqlDataHelper.AddAppointmentData(unitAppointment, UserName);
        }
        public string AddAppointmentCommentData(UnitDTO unitDTO)
        {
            string UserName = unitDTO.UserName;
            int AptID = unitDTO.AptID;
            string Comment = unitDTO.Comment;
            return this._sqlDataHelper.AddAppointmentCommentData(UserName, AptID, Comment);
        }

        public string UpdatePatientData(UnitDTO unitDTO)
        {
            UnitPatient unitPatient = new UnitPatient();
            string Name = unitDTO.UserName;
            unitPatient.UserName = unitDTO.PatName;
            unitPatient.FirstName = unitDTO.FirstName;
            unitPatient.LastName = unitDTO.LastName;
            unitPatient.PhoneNumber = unitDTO.PhoneNumber;
            unitPatient.vPassword = unitDTO.vPassword;
            unitPatient.DOB = unitDTO.DOB;
            unitPatient.InDate = unitDTO.InDate;
            unitPatient.OutDate = unitDTO.OutDate;
            unitPatient.IsDeleted = unitDTO.IsDeleted;
            return this._sqlDataHelper.UpdatePatientData(unitPatient,Name);
        }

        public string UpdateEmployeeData(UnitDTO unitDTO)
        {
            UnitEmployee UnitEmp = new UnitEmployee();
            string Name = unitDTO.UserName;
            UnitEmp.EmpIdentifier = unitDTO.EmpIdentifier;
            UnitEmp.UserName = unitDTO.EmpName;
            UnitEmp.FirstName = unitDTO.FirstName;
            UnitEmp.LastName = unitDTO.LastName;
            UnitEmp.PhoneNumber = unitDTO.PhoneNumber;
            UnitEmp.EmpPassword = unitDTO.EmpPassword;
            UnitEmp.Experience = unitDTO.Experience;
            UnitEmp.Available = unitDTO.Available;
            UnitEmp.SpecialityCode = unitDTO.SpecialityCode;
            UnitEmp.DOB = unitDTO.DOB;
            UnitEmp.CreateDate = unitDTO.CreateDate;
            UnitEmp.IsDeleted = unitDTO.IsDeleted;

            return this._sqlDataHelper.UpdateEmployeeData(UnitEmp, Name);
        }
        public string UpdateAppointmentData(UnitDTO unitDTO)
        {
            UnitAppointment unitAppointment = new UnitAppointment();
            string UserName = unitDTO.UserName;
            unitAppointment.AptID = unitDTO.AptID;
            unitAppointment.PatientName = unitDTO.PatientName;
            unitAppointment.ProviderName = unitDTO.ProviderName;
            unitAppointment.Title = unitDTO.Title;
            unitAppointment.AptDescription = unitDTO.AptDescription;
            unitAppointment.SeverityLevel = unitDTO.SeverityLevel;
            unitAppointment.StartTime = unitDTO.StartTime;
            unitAppointment.EndTime = unitDTO.EndTime;
            unitAppointment.Comment = unitDTO.Comment;
            unitAppointment.StatusCode = unitDTO.StatusCode;
            unitAppointment.InitiatedBy  = unitDTO.InitiatedBy;
            unitAppointment.IsDeleted = unitDTO.IsDeleted;
            return this._sqlDataHelper.UpdateAppointmentData(unitAppointment, UserName);
        }

        public string RemovePatientData(UnitDTO unitDTO)
        {
            string UserName = unitDTO.UserName;
            string PatName = unitDTO.PatName;
            return this._sqlDataHelper.RemovePatientData(UserName,PatName);
        }
        public string RemoveEmployeeData(UnitDTO unitDTO)
        {
            string UserName = unitDTO.UserName;
            string EmpName = unitDTO.EmpName;
            return this._sqlDataHelper.RemoveEmployeeData(UserName, EmpName);
        }

        public string RemoveAppointmentData(UnitDTO unitDTO)
        {
            string UserName = unitDTO.UserName;
            int AptID = unitDTO.AptID;
            return this._sqlDataHelper.RemoveAppointmentData(UserName, AptID);
        }

    }
}

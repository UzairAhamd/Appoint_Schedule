using System;
using System.Collections.Generic;
using Appointment_Scheduling_Project.Model;
namespace Appointment_Scheduling_Project.BusinessLayer
{
    public interface ISQLDataHelper
    {
        public int LoginData(string UserName, string Password);
        public UnitPatient GetPatientData(string UserName, string PatName);  //get patient

        public UnitEmployee GetEmployeeData(string UserName, string EmpName);
        public List<UnitPatient> GetPatientsData(string UserName, string Segregator);
        public List<UnitDTO> GetProvidersData(string UserName, string Segregator);
        public List<UnitAppointment> GeOwnerAppointmentsData(string UserName, string OwnerName, string Segregator);

        public List<UnitAppointment> GeEveryAppointmentData(string UserName, string Segregator);
        public string AddEmployeeData(UnitEmployee UnitEmp, string Name);
        public string AddPatientData(UnitPatient unitPatient, string Name);
        public string AddAppointmentData(UnitAppointment unitAppointment, string UserName);
        public string AddAppointmentCommentData(string UserName, int AptID, string Comment);

        public string UpdatePatientData(UnitPatient unitPatient, string Name);
        public string UpdateEmployeeData(UnitEmployee unitEmployee, string Name);
        public string UpdateAppointmentData(UnitAppointment unitAppointment, string UserName);
        public string RemovePatientData(string UserName, string PatName);

        public string RemoveEmployeeData(string UserName, string EmpName);
        public string RemoveAppointmentData(string UserName, int AptID);

    }
}

using System;
using Appointment_Schedule_Project.Model;
using System.Collections.Generic;

namespace Appointment_Schedule_Project.BusinessLayer
{
    public interface IAppointmentBuisness
    {
        public object LoginData(UnitDTO unitDTO);
        public UnitPatient GetPatientData(string UserName, string PatName);

        public UnitEmployee GetEmployeeData(string UserName, string EmpName);

        public List<UnitPatient> GetPatientsData(string UserName, string Segregator);
        public List<UnitDTO> GetProvidersData(string UserName, string Segregator);

        public List<UnitAppointment> GeOwnerAppointmentsData(string UserName, string OwnerName, string Segregator);

        public List<UnitAppointment> GeEveryAppointmentData(string UserName, string Segregator);

        public string AddEmployeeData(UnitDTO unitDTO);
        public string AddPatientData(UnitDTO unitDTO);
        public string AddAppointmentData(UnitDTO unitDTO);

        public string AddAppointmentCommentData(UnitDTO unitDTO);
        public string UpdatePatientData(UnitDTO unitDTO);
        public string UpdateEmployeeData(UnitDTO unitDTO);
        public string UpdateAppointmentData(UnitDTO unitDTO);

        public string RemovePatientData(UnitDTO unitDTO);

        public string RemoveEmployeeData(UnitDTO unitDTO);
        public string RemoveAppointmentData(UnitDTO unitDTO);

    }
}

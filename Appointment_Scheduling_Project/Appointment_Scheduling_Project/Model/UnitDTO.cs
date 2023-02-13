using System;

namespace Appointment_Scheduling_Project.Model
{
    public class UnitDTO
    {
        public string PatName { get; set; }
        public string EmpName { get; set; }
        public string Segregator  { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        //UnitEmployee+
        public int EmpID { get; set; }
        public string EmpIdentifier { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmpPassword { get; set; }
        public int Experience { get; set; }
        public bool Available { get; set; }
        public string SpecialityCode { get; set; }
        public string Speciality { get; set; }


        //+UnitPatient
        public DateTime DOB { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int PatID { get; set; }
        public string vPassword { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }


        //+UnitAppointment
        public int AptID { get; set; }
        public string PatientName { get; set; }
        public string ProviderName { get; set; }
        public string Title { get; set; }
        public string AptDescription { get; set; }
        public string SeverityLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StatusCode { get; set; }
        public string Comment { get; set; }
        public string InitiatedBy { get; set; }
    }
}

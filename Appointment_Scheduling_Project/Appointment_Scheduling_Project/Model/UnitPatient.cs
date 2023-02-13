using System;

namespace Appointment_Scheduling_Project.Model
{
    public class UnitPatient
    {
        public int PatID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string vPassword { get; set; }
        public DateTime DOB{ get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

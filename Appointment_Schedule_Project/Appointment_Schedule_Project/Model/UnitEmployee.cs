using System;

namespace Appointment_Schedule_Project.Model
{
    public class UnitEmployee
    {
        public int EmpID { get; set; }
        public string EmpIdentifier { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmpPassword { get; set; }
        public int Experience { get; set; }
        public bool Available  { get; set; }
        public string SpecialityCode { get; set; }
        public DateTime DOB{ get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

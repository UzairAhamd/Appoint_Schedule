using System;

namespace Appointment_Schedule_Project.Model
{
    public class UnitLogin
    {
        public int ID { get; set; }
        public string Identifier { get; set; }
        public string UserName { get; set; }
        public string cPassword { get; set; }
        public bool IsDeleted { get; set; }
    }
}

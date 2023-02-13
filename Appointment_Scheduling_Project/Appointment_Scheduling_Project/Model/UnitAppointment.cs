using System;

namespace Appointment_Scheduling_Project.Model
{
    public class UnitAppointment
    {
        public int AptID { get; set; }
        public string PatientName { get; set; }
        public string ProviderName { get; set; }
        public string Title { get; set; }
        public string AptDescription { get; set; }
        public string SeverityLevel { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public string StatusCode { get; set; }
        public string Comment { get; set; }
        public string InitiatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

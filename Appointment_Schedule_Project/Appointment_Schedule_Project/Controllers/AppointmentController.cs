using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Appointment_Schedule_Project.BusinessLayer;
using Appointment_Schedule_Project.Model;
using Microsoft.AspNetCore.Cors;

namespace Appointment_Schedule_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class AppointmentController : Controller
    {
        //BAL to Controller Dependency Injection 
        IAppointmentBuisness _appointmentBuisness;
        public AppointmentController(IAppointmentBuisness penaltyCalculator)
        {
            _appointmentBuisness = penaltyCalculator;
        }
        [HttpPost]
        [Route("login")]
        public object Login([FromBody] UnitDTO unitDTO)
        {
            if ((unitDTO.UserName != null) && (unitDTO.Password!= null))
                return _appointmentBuisness.LoginData(unitDTO);
            return "Error";
        }


        [HttpPost]
        [Route("Patient")]
        public UnitPatient GetPatient([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.GetPatientData(unitDTO.UserName, unitDTO.PatName);
        }
        [HttpPost]
        [Route("Employee")]
        public UnitEmployee GetEmployee([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.GetEmployeeData(unitDTO.UserName, unitDTO.EmpName);

        }

        [HttpPost]
        [Route("Patients")]
        public object GetPatients([FromBody] UnitDTO unitDTO)
        {
            
            //if ((unitDTO.UserName != null) && (unitDTO.Segregator != null))
                return _appointmentBuisness.GetPatientsData(unitDTO.UserName, unitDTO.Segregator);
            //return "Error";
        }


        [HttpPost]
        [Route("Providers")]
        public List<UnitDTO> GetProviders([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.GetProvidersData(unitDTO.UserName, unitDTO.Segregator);

        }


        [HttpPost]
        [Route("OwnerAppointments")]
        public List<UnitAppointment> GeOwnerAppointments([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.GeOwnerAppointmentsData(unitDTO.UserName,unitDTO.OwnerName, unitDTO.Segregator);

        }
        [HttpPost]
        [Route("EveryAppointment")]
        public List<UnitAppointment> GeEveryAppointment([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.GeEveryAppointmentData(unitDTO.UserName,  unitDTO.Segregator);

        }
        [HttpPost]
        [Route("AddEmployee")]
        public string AddEmployee([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.AddEmployeeData(unitDTO);

        }

        [HttpPost]
        [Route("AddPatient")]
        public string AddPatient([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.AddPatientData(unitDTO);

        }

        [HttpPost]
        [Route("AddAppointment")]
        public string AddAppointment([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.AddAppointmentData(unitDTO);

        }


        [HttpPost]
        [Route("AddAppointmentComment")]
        public string AddAppointmentComment([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.AddAppointmentCommentData(unitDTO);

        }


        [HttpPut]
        [Route("UpdatePatient")]
        public string UpdatePatient([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.UpdatePatientData(unitDTO);

        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public string UpdateEmployee([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.UpdateEmployeeData(unitDTO);

        }

        [HttpPut]
        [Route("UpdateAppointment")]
        public string UpdateAppointment([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.UpdateAppointmentData(unitDTO);

        }

        [HttpDelete]
        [Route("RemovePatient")]
        public string RemovePatient([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.RemovePatientData(unitDTO);

        }
        [HttpDelete]
        [Route("RemoveEmployee")]
        public string RemoveEmployee([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.RemoveEmployeeData(unitDTO);

        }

        [HttpDelete]
        [Route("RemoveAppointment")]
        public string RemoveAppointment([FromBody] UnitDTO unitDTO)
        {
            return _appointmentBuisness.RemoveAppointmentData(unitDTO);

        }
    }
}

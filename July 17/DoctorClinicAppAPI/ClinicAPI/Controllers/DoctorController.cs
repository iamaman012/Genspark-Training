using ClinicAPI.Interfaces;
using ClinicAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [Route("GetDoctorBySpec")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorBySpecialization(string spec)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpeciality(spec); 
                return Ok(doctors);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpPut]

        public async Task<ActionResult<Doctor>> UpdateDoctorsExperience(int id,int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id,experience);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }



    }
}

using MedicalRecord.Business;
using MedicalRecord.Common.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRecord.API.Controllers
{
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private readonly IPatientBusiness _patientBusness;
        public PatientController(IPatientBusiness patientBusiness)
        {
            _patientBusness = patientBusiness;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _patientBusness.Get());
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _patientBusness.GetById(id));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PatientsDto patient)
        {
            if (patient == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _patientBusness.Insert(patient);

            return CreatedAtRoute("GetById", new { id = result.Id }, patient);
        }

        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Update(int id,
            [FromBody] PatientsDto patient)
        {
            if (!await _patientBusness.CheckIfExist(id))
                return BadRequest();

            if (patient == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _patientBusness.Update(patient);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdate([FromBody] PatientsDto patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _patientBusness.Update(patchDoc);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var result =  _patientBusness.DeletePatient(id);

            return NoContent();
        }
    }
}

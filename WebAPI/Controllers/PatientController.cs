using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HospitalDAL;
using HospitalDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPIDemo.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("MyCorsPolicy")]
    [Route("api/PatientAPI")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private HospitalDB hospitalDB = null;

        public PatientController(HospitalDB hDB)
        {
            hospitalDB = hDB;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            List<Patient> list = hospitalDB.patients.Include(i => i.Problems).ThenInclude(it => it.Treatments).ToList();
            return list;
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<PatientDTO> dtoobjlist)
        {
            HttpContext.Session.SetString("key", "ddd");
            HashSet<ValidationResult> errRes = new HashSet<ValidationResult>();
            foreach (var dtoobj in dtoobjlist)
            {
                List<Problem> probj = new List<Problem>();
                foreach (var item in dtoobj.Problems)
                {
                    List<Treatment> tobj = new List<Treatment>();
                    foreach (var tre in item.Treatments)
                    {
                        Treatment x = new Treatment
                        {
                            Name = tre.Name,
                            Dosage = tre.Dosage
                        };
                        tobj.Add(x);
                    }
                    Problem y = new Problem
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Treatments = tobj
                    };
                    probj.Add(y);
                }
                Patient obj = new Patient
                {
                    Address = dtoobj.Address,
                    Name = dtoobj.Name,
                    Phone = dtoobj.Phone,
                    Problems = probj
                };
                var context = new ValidationContext(obj, null, null);
                bool isValid = Validator.TryValidateObject(obj, context, errRes, true);
                if (isValid)
                {
                    hospitalDB.patients.Add(obj);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, errRes);
                }
            }
            hospitalDB.SaveChanges();
            List<Patient> list = hospitalDB.patients.ToList();
            return Ok(list);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntryRepresents.lib.Model.Request;
using EntryRepresents.lib.Model.Response;
using EntryRepresents.lib.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntryRepresents.api.Controllers
{
    [Route("api/patient-group")]
    [Produces("application/json")]
    public class PatientsGroup : Controller
    {
        private readonly IGroupMyPatients<int> groupMyPatients;

        public PatientsGroup(IGroupMyPatients<int> groupMyPatients)
        {
            this.groupMyPatients = groupMyPatients;
        }
        /// <summary>
        /// Takes in a Matrix as input and returns the patient group
        /// </summary>
        /// <param name="patientGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [AcceptVerbs("POST")]
      
        public IActionResult Calculate([FromBody]PatientGroup<int> patientGroup)
        {
            var returnvalue = new PatientsCount(0);
            try
            {
                var length = patientGroup.Matrix.GetLength(0);
                returnvalue= new PatientsCount(groupMyPatients.GroupedCount(patientGroup));
                return Ok(returnvalue);
            }
            catch (Exception ex)
            {
                //This should be logged 
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        
    }
}

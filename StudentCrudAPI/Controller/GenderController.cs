using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;
using StudentCrudAPI.Service;

namespace StudentCrudAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGender _gender;

        public GenderController(IGender gender)
        {
            _gender = gender;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGender()
        {
            try
            {
                return Ok(await _gender.GetAllGenders());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Occured while reterieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenderViewModel>> GetGender(int id)
        {
            try
            {
                var result = await _gender.GetGender(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error Occured while reterieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<GenderViewModel>> AddGender(GenderViewModel gvm)
        {
            try
            {
                if (gvm == null)
                {
                    return BadRequest();
                }

                var createdGen = await _gender.AddGender(gvm);

                return createdGen;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Adding Gender");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GenderViewModel>> UpdateGender(int id, GenderViewModel gvm)
        {
            try
            {
                if (id != gvm.Id)
                    return BadRequest("Gender ID Does not match");

                var genToUpdate = await _gender.GetGender(id);

                if (genToUpdate == null)
                    return NotFound($"Gender with Id = {id} not found");

                return await _gender.UpdateGender(gvm);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Gender>> DeleteGender(int id)
        {
            try
            {
                var genToDelete = await _gender.GetGender(id);

                if (genToDelete == null)
                {
                    return NotFound($"Gender with Id = {id} not found");
                }

                return await _gender.DeleteGender(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

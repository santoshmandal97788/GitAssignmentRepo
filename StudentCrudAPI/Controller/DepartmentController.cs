using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;
using StudentCrudAPI.Service;

namespace StudentCrudAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _department.GetAllDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Occured while reterieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentViewModel>> GetDepartment(int id)
        {
            try
            {
                var result = await _department.GetDepartment(id);

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
        public async Task<ActionResult<DepartmentViewModel>> AddDepartment(DepartmentViewModel dvm)
        {
            try
            {
                if (dvm == null)
                {
                    return BadRequest();
                }

                var createdDept = await _department.AddDepartment(dvm);

                return createdDept;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Adding new Department");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DepartmentViewModel>> UpdateDepartment(int id, DepartmentViewModel dvm)
        {
            try
            {
                if (id != dvm.Id)
                    return BadRequest("Department ID Does not match");

                var deptToUpdate = await _department.GetDepartment(id);

                if (deptToUpdate == null)
                    return NotFound($"Department with Id = {id} not found");

                return await _department.UpdateDepartment(dvm);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            try
            {
                var deptToDelete = await _department.GetDepartment(id);

                if (deptToDelete == null)
                {
                    return NotFound($"Department with Id = {id} not found");
                }

                return await _department.DeleteDepartment(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;
using StudentCrudAPI.Service;

namespace StudentCrudAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            try
            {
                return Ok(await _student.GetAllStudents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Occured while reterieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentViewModel>> GetStudent(int id)
        {
            try
            {
                var result = await _student.GetStudent(id);

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
        public async Task<ActionResult<StudentViewModel>> AddStudent(StudentViewModel svm)
        {
            try
            {
                if (svm == null)
                {
                    return BadRequest();
                }

                var createdStudent = await _student.AddStudent(svm);

                return createdStudent;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Adding new Student");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentViewModel>> UpdateStudent(int id, StudentViewModel svm)
        {
            try
            {
                if (id != svm.Id)
                    return BadRequest("Student ID Does not match");

                var studentToUpdate = await _student.GetStudent(id);

                if (studentToUpdate == null)
                    return NotFound($"Student with Id = {id} not found");

                return await _student.UpdateStudent(svm);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var stuToDelete = await _student.GetStudent(id);

                if (stuToDelete == null)
                {
                    return NotFound($"Student with Id = {id} not found");
                }

                return await _student.DeleteStudent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

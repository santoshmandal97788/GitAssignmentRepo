using StudentCrudAPI.Data;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCrudAPI.Service
{
    public class StudentService : IStudent
    {
        private readonly AppDbContext _appDbContext;
        public StudentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<StudentViewModel> AddStudent(StudentViewModel svm)
        {
            var entity = new Student
            {
                FirstName = svm.FirstName,
                lastName = svm.lastName,
                PhoneNumber = svm.PhoneNumber,
                Email = svm.Email,
                GenderId = svm.GenderId,
                DepartmentId = svm.DepartmentId,
                CreatedDate = DateTime.Now
            };
            await _appDbContext.Students.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return svm;
        }

        public async Task<Student> DeleteStudent(int studentId)
        {
            var result = await _appDbContext.Students.SingleOrDefaultAsync(e => e.Id == studentId);
            if (result != null)
            {
                _appDbContext.Students.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            List<StudentViewModel> lstStu = new List<StudentViewModel>();
            var result = _appDbContext.Students.ToListAsync();
            foreach (var item in await result)
            {
                lstStu.Add(new StudentViewModel()
                {
                    Id = item.Id,
                    FullName = item.FirstName + " " + item.lastName,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    GenderId = item.GenderId,
                    Gender = item.Gender.GenderName,
                    DepartmentId = item.DepartmentId,
                    Department = item.Department.DepartmentName
                });
            }
            return lstStu;
        }

        public async Task<StudentViewModel> GetStudent(int studentId)
        {
            var student = await _appDbContext.Students.Include(x => x.Gender).Include(x => x.Department).SingleOrDefaultAsync(x => x.Id == studentId);
            var result = new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                lastName = student.lastName,
                FullName = student.FirstName + " " + student.lastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                GenderId = student.GenderId,
                Gender = student.Gender.GenderName,
                DepartmentId = student.DepartmentId,
                Department = student.Department.DepartmentName
            };
            return result;
        }

        public async Task<StudentViewModel> UpdateStudent(StudentViewModel svm)
        {
            var result = await _appDbContext.Students.FirstOrDefaultAsync(e => e.Id == svm.Id);

            if (result != null)
            {
                result.FirstName = svm.FirstName;
                result.lastName = svm.lastName;
                result.Email = svm.Email;
                result.PhoneNumber = svm.PhoneNumber;
                result.GenderId = svm.GenderId;
                result.DepartmentId = svm.DepartmentId;
                result.UpdatedDate = DateTime.Now;

                await _appDbContext.SaveChangesAsync();

                return svm;
            }

            return null;
        }
    }
}

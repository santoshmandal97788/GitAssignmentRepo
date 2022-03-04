using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;

namespace StudentCrudAPI.Service
{
    public interface IStudent
    {
        Task<IEnumerable<StudentViewModel>> GetAllStudents();
        Task<StudentViewModel> GetStudent(int studentId);
        Task<StudentViewModel> AddStudent(StudentViewModel svm);
        Task<StudentViewModel> UpdateStudent(StudentViewModel svm);
        Task<Student> DeleteStudent(int studentId);
    }
}

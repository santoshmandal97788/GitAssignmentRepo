using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;

namespace StudentCrudAPI.Service
{
    public interface IDepartment
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartments();
        Task<DepartmentViewModel> GetDepartment(int dept_Id);
        Task<DepartmentViewModel> AddDepartment(DepartmentViewModel dvm);
        Task<DepartmentViewModel> UpdateDepartment(DepartmentViewModel dvm);
        Task<Department> DeleteDepartment(int dept_Id);
    }
}

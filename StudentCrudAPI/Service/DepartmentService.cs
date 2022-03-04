using Microsoft.EntityFrameworkCore;
using StudentCrudAPI.Data;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;

namespace StudentCrudAPI.Service
{
    public class DepartmentService : IDepartment
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<DepartmentViewModel> AddDepartment(DepartmentViewModel dvm)
        {
            var entity = new Department
            {
                DepartmentName = dvm.DepartmentName,
                CreatedDate = DateTime.Now
            };
            await _appDbContext.Departments.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return dvm;
        }

        public async Task<Department> DeleteDepartment(int dept_Id)
        {
            var result = await _appDbContext.Departments.SingleOrDefaultAsync(e => e.Id == dept_Id);
            if (result != null)
            {
                _appDbContext.Departments.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartments()
        {
            List<DepartmentViewModel> lstDept = new List<DepartmentViewModel>();
            var result = _appDbContext.Departments.ToListAsync();
            foreach (var item in await result)
            {
                lstDept.Add(new DepartmentViewModel() { Id = item.Id, DepartmentName = item.DepartmentName });
            }
            return lstDept;
        }

        public async Task<DepartmentViewModel> GetDepartment(int dept_Id)
        {
            var dept = await _appDbContext.Departments.SingleOrDefaultAsync(x => x.Id == dept_Id);
            var result = new DepartmentViewModel
            {
                Id = dept.Id,
                DepartmentName = dept.DepartmentName
            };
            return result;
        }

        public async Task<DepartmentViewModel> UpdateDepartment(DepartmentViewModel dvm)
        {
            var result = await _appDbContext.Departments.FirstOrDefaultAsync(e => e.Id == dvm.Id);

            if (result != null)
            {
                result.DepartmentName = dvm.DepartmentName;
                result.UpdatedDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();

                return dvm;
            }

            return null;
        }

    }
}

using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;

namespace StudentCrudAPI.Service
{
    public interface IGender
    {
        Task<IEnumerable<GenderViewModel>> GetAllGenders();
        Task<GenderViewModel> GetGender(int gen_Id);
        Task<GenderViewModel> AddGender(GenderViewModel gvm);
        Task<GenderViewModel> UpdateGender(GenderViewModel gvm);
        Task<Gender> DeleteGender(int gen_Id);
    }
}

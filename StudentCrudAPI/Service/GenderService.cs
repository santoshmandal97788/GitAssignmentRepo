using Microsoft.EntityFrameworkCore;
using StudentCrudAPI.Data;
using StudentCrudAPI.Entities;
using StudentCrudAPI.Models;

namespace StudentCrudAPI.Service
{
    public class GenderService : IGender
    {
        private readonly AppDbContext _appDbContext;
        public GenderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<GenderViewModel> AddGender(GenderViewModel gvm)
        {
            var entity = new Gender
            {
                GenderName = gvm.Gender,
                CreatedDate = DateTime.Now
            };
            await _appDbContext.Genders.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return gvm;
        }

        public async Task<Gender> DeleteGender(int gen_Id)
        {
            var result = await _appDbContext.Genders.SingleOrDefaultAsync(e => e.Id == gen_Id);
            if (result != null)
            {
                _appDbContext.Genders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<GenderViewModel>> GetAllGenders()
        {
            List<GenderViewModel> lstGen = new List<GenderViewModel>();
            var result = _appDbContext.Genders.ToListAsync();
            foreach (var item in await result)
            {
                lstGen.Add(new GenderViewModel() { Id = item.Id, Gender = item.GenderName });
            }
            return lstGen;
        }

        public async Task<GenderViewModel> GetGender(int gen_Id)
        {
            var gen = await _appDbContext.Genders.SingleOrDefaultAsync(x => x.Id == gen_Id);
            var result = new GenderViewModel
            {
                Id = gen.Id,
                Gender = gen.GenderName
            };
            return result;
        }

        public async Task<GenderViewModel> UpdateGender(GenderViewModel gvm)
        {
            var result = await _appDbContext.Genders.FirstOrDefaultAsync(e => e.Id == gvm.Id);

            if (result != null)
            {
                result.GenderName = gvm.Gender;
                result.UpdatedDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();

                return gvm;
            }

            return null;
        }

    }
}

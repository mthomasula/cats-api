using System;
using CatsAPI.Data;
using CatsAPI.DTOs;

namespace CatsAPI.Services.CatsService
{
	public class CatsService : ICatsService
	{

        
        private readonly DataContext _context;

        public CatsService(DataContext context)
        {
            _context = context;
        }

       

        public async Task<List<CatModel>> AddCat(CatCreateDto cat)
        {
            var newCat = new CatModel
            {
                Name = cat.Name
            };

            _context.Cats.Add(newCat);
            await _context.SaveChangesAsync();
            return await _context.Cats.ToListAsync();
        }

        public async Task<List<CatModel>?> DeleteCat(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat is null)
                return null;

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            return await _context.Cats.ToListAsync();
        }

        public async Task<List<CatModel>> GetAllCats()
        {
            //This will work once DTOs are implemented
           var cats = await _context.Cats.Include(c => c.Addresses).ToListAsync();
            return cats;

            //var cats = await _context.Cats.ToListAsync();
            //return cats;
        }

        public async Task<CatModel?> GetCat(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat is null)
                return null;
            return cat;
        }

        public async Task<List<CatModel>?> UpdateCat(int id, CatModel request)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat is null)
                return null;
            

            cat.Name = request.Name;
            //cat.Location = request.Location;

            await _context.SaveChangesAsync();
            return await _context.Cats.ToListAsync();
        }
    }
}

 
using JohannasReactProject.Data;
using JohannasReactProject.Models;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class FixedCostCategoryRepo : IFixedCostCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public FixedCostCategoryRepo(ApplicationDbContext context) => _context = context;
        public async Task Edit(FixedCostsCategories editedFixedCostCategory)
        {
            var foundCategory = _context.FixedCostsCategories.Where(x => x.Id == editedFixedCostCategory.Id).FirstOrDefault();
            foundCategory = editedFixedCostCategory;
            await _context.SaveChangesAsync();
        }

        public IEnumerable<FixedCostsCategories> Get(ApplicationUser user)
        {
            return _context.FixedCostsCategories.Where(x => x.User == user).ToList();
        }

        public async Task Post(FixedCostsCategories fixedCostsCategory)
        {
            _context.FixedCostsCategories.Add(fixedCostsCategory);
            await _context.SaveChangesAsync();
        }
    }
}

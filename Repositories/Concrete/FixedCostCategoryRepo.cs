using JohannasReactProject.Data;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
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
        public async Task Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
            var foundCategory = _context.FixedCostsCategories.Where(x => x.Id == editFixedCostCategoryDTO.Id).FirstOrDefault();

            foundCategory.Name = editFixedCostCategoryDTO.Name;
            foundCategory.Cost = editFixedCostCategoryDTO.Cost;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<FixedCostCategoryDTO> Get(string userId)
        {
            var returnList = new List<FixedCostCategoryDTO>();
            var fixedCostCateogry = _context.FixedCostsCategories.Where(x => x.User.Id == userId).ToList();
            foreach (var item in fixedCostCateogry)
            {
                returnList.Add(new FixedCostCategoryDTO
                {
                    Name = item.Name,
                    Cost = item.Cost
                });
            }
            return returnList;
        }

        public async Task Post(FixedCostsCategories fixedCostsCategory, string userId)
        {
            var budget = _context.Budgets.Where(b => b.User.Id == userId).OrderByDescending(b => b.StartDate).FirstOrDefault();
            budget.FixedCostsCategories.Add(fixedCostsCategory);
            budget.Unbudgeted -= fixedCostsCategory.Cost;
            var person = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            fixedCostsCategory.User = person;
            _context.FixedCostsCategories.Add(fixedCostsCategory);
            await _context.SaveChangesAsync();
        }
    }
}

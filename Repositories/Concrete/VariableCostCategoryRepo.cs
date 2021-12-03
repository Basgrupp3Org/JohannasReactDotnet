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
    public class VariableCostCategoryRepo : IVariableCostCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public VariableCostCategoryRepo (ApplicationDbContext context) => _context = context;
        public async Task Edit(VariableCostsCategories editedVariableCostCategory)
        {
            var foundCategory = _context.VariableCostsCategories.Where(x => x.Id == editedVariableCostCategory.Id).FirstOrDefault();
            foundCategory = editedVariableCostCategory;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<VariableCostsCategories> Get(ApplicationUser user)
        {
            return _context.VariableCostsCategories.Where(x => x.User == user).ToList();
        }

        //public IEnumerable<VariableCostsCategories> GetForCurrentBudget(ApplicationUser user)
        //{
        //    var returnList = new List<VariableCostsCategories>();
        //    return returnList;
        //}

        public async Task Post(VariableCostsCategories variableCostsCategories)
        {
            _context.VariableCostsCategories.Add(variableCostsCategories);
            await _context.SaveChangesAsync();
        }
    }
}

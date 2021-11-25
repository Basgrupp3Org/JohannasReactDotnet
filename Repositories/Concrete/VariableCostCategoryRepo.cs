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
        public async Task Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO)
        {
            var foundCategory = _context.VariableCostsCategories.Where(x => x.Id == editVariableCostCategoryDTO.Id).FirstOrDefault();

            foundCategory.Name = editVariableCostCategoryDTO.Name;
            foundCategory.Spent= editVariableCostCategoryDTO.Spent;
            foundCategory.ToSpend = editVariableCostCategoryDTO.ToSpend;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<VariableCostsCategories> Get(ApplicationUser user)
        {
            var variableCostsCategories = new List<VariableCostsCategories>();
            return variableCostsCategories;
        }

        public IEnumerable<VariableCostsCategories> GetForCurrentBudget(ApplicationUser user)
        {
            var returnList = new List<VariableCostsCategories>();
            return returnList;
        }

        public async Task Post(VariableCostsCategories variableCostsCategories, string userId)
        {
            var person = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var budget = _context.Budgets.Where(b => b.User == person).OrderByDescending(b => b.StartDate).FirstOrDefault();
            variableCostsCategories.User = person;
            _context.VariableCostsCategories.Add(variableCostsCategories);
            budget.Unbudgeted -= variableCostsCategories.ToSpend - variableCostsCategories.Spent;
            var budgetCategory = new BudgetCategory();
            budgetCategory.Budget = budget;
            budgetCategory.User = person;
            budgetCategory.VariableCostsCategory = variableCostsCategories;
            budgetCategory.MaxSpent = variableCostsCategories.ToSpend;
            _context.BudgetCategories.Add(budgetCategory);
            await _context.SaveChangesAsync();
        }
    }
}

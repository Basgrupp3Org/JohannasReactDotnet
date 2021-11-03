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

        public IEnumerable<VariableCostCategoryDTO> Get(string userId)
        {
            var returnList = new List<VariableCostCategoryDTO>();
            var variableCostCateogry = _context.VariableCostsCategories.Where(x => x.User.Id == userId).ToList();
           foreach(var item in variableCostCateogry)
           {
                returnList.Add(new VariableCostCategoryDTO
                {
                    Name = item.Name,
                    Spent = item.Spent,
                    ToSpend = item.ToSpend,
                });
           }
            return returnList;
        }

        public IEnumerable<VariableCostCategoryDTO> GetForCurrentBudget(string userId)
        {
          var returnList = new List<VariableCostCategoryDTO>();

            
            var budgetCategories = _context.BudgetCategories.Where(x => userId == x.User.Id).Include("VariableCostsCategories").ToList();
            
                foreach(var item in budgetCategories)
            {
                returnList.Add(new VariableCostCategoryDTO
                {
                    Name = item.VariableCostsCategory.Name,
                    Spent = item.VariableCostsCategory.Spent,
                    ToSpend = item.VariableCostsCategory.ToSpend
                });
            }

            return returnList;
        }

        public async Task Post(VariableCostsCategories variableCostsCategories, string userId)
        {
            var person = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var budget = _context.Budgets.Where(b => b.User == person).OrderByDescending(b => b.StartDate).FirstOrDefault();
            variableCostsCategories.User = person;
            _context.VariableCostsCategories.Add(variableCostsCategories);
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

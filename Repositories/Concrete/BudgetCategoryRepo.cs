using JohannasReactProject.Data;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class BudgetCategoryRepo : IBudgetCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public BudgetCategoryRepo(ApplicationDbContext context) => _context = context;

        public IEnumerable<BudgetCategory> Get(Budget currentBudget)
        {
           return _context.BudgetCategories.Where(x => x.Budget.Id == currentBudget.Id).Include(v => v.VariableCostsCategory).ToList();
        }

        public void Post(BudgetCategory budgetCategory)
        {
             _context.BudgetCategories.Add(budgetCategory);
            _context.SaveChanges();
        }
    }
}

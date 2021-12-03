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
    public class BudgetRepo : IBudgetRepo
    {
        private readonly ApplicationDbContext _context;

        public BudgetRepo(ApplicationDbContext context) => _context = context;
        public async Task Edit(EditBudgetDTO budget)
        {
            var foundBudget = _context.Budgets.Where(x => x.Id == budget.Id).FirstOrDefault();
           
                foundBudget.Income = budget.Income;
                foundBudget.StartDate = budget.StartDate;
                foundBudget.EndDate = budget.EndDate;

            await _context.SaveChangesAsync();
            
        }

        public ICollection<Budget> Get(ApplicationUser user)
        {
            var budgets = _context.Budgets.Where(b => b.User == user).ToList();
            return budgets;
        }

        public Budget GetCurrentBudget(ApplicationUser user)
        {
            return _context.Budgets.Where(b => b.User == user ).OrderByDescending(b => b.StartDate).FirstOrDefault();
        }

        public async Task Post(Budget budget)
        {
            _context.Budgets.Add(budget);
           await _context.SaveChangesAsync();
        }
    }
}

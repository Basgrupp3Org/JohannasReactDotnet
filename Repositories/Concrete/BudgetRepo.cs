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
    public class BudgetRepo : IBudgetRepo
    {
        private readonly ApplicationDbContext _context;

        public BudgetRepo(ApplicationDbContext context) => _context = context;
        public void Edit(EditBudgetDTO budget)
        {
            var foundBudget = _context.Budgets.Where(x => x.Id == budget.Id).FirstOrDefault();
            if (foundBudget != null)
            {
                foundBudget.Income = budget.Income;
                foundBudget.Housing = budget.Housing;
                foundBudget.Vehicle = budget.Vehicle;
                foundBudget.StartDate = budget.StartDate;
                foundBudget.EndDate = budget.EndDate;

                _context.SaveChanges();
            }
        }

        public void Post(Budget budget)
        {
            _context.Budgets.Add(budget);
            _context.SaveChanges();
        }
    }
}

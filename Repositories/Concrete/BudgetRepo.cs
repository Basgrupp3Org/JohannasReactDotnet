using JohannasReactProject.Data;
using JohannasReactProject.Models;
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
        public async Task Edit(EditBudgetDTO budget)
        {
            var foundBudget = _context.Budgets.Where(x => x.Id == budget.Id).FirstOrDefault();
           
                foundBudget.Income = budget.Income;
                foundBudget.StartDate = budget.StartDate;
                foundBudget.EndDate = budget.EndDate;

            await _context.SaveChangesAsync();
            
        }

        public IEnumerable<BudgetDTO> Get(ApplicationUser applicationUser)
        {
            var list = new List<BudgetDTO>();

            var budget = _context.Budgets.Where(b => b.User.Id == applicationUser.Id).ToList();
            foreach (var item in budget)
            {
                list.Add(new BudgetDTO
                {
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Income = item.Income,
                    Unbudgeted = item.Unbudgeted
                });
            }
            return list;
        }

        public async Task Post(Budget budget)
        {
            var user = budget.User.Id;
            var person = _context.Users.Where(u => u.Id == user).FirstOrDefault();
            budget.User = person;
            _context.Budgets.Add(budget);
           await _context.SaveChangesAsync();
        }
    }
}

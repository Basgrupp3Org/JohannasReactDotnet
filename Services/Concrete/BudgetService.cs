using JohannasReactProject.Models;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using JohannasReactProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Services.Concrete
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepo;
        private readonly IUserRepo _userRepo;
        private readonly IFixedCostCategoryRepo _fixedCostRepo;

        public BudgetService(IBudgetRepo budgetRepo, IUserRepo userRepo, IFixedCostCategoryRepo fixedCostCategoryRepo)
        {
            _budgetRepo = budgetRepo;
            _userRepo = userRepo;
            _fixedCostRepo = fixedCostCategoryRepo;
        }
        public async Task Edit(EditBudgetDTO budgetDTO, string userId)
        {
            var user = _userRepo.GetUser(userId);
            var budget = new Budget { }
            await _budgetRepo.Edit(budget);
        }

        public IEnumerable<BudgetDTO> Get(string userId)
        {
            var list = new List<BudgetDTO>();
            var user = _userRepo.GetUser(userId);
            var budgets = _budgetRepo.Get(user);
            foreach (var item in budgets)
            {
                list.Add(new BudgetDTO
                {
                    StartDate = item.StartDate.ToString("yyyy-mm-dd"),
                    EndDate = item.EndDate.ToString("yyyy-mm-dd"),
                    Income = item.Income,
                    Unbudgeted = item.Unbudgeted,
                    Name = item.Name
                });
            }
            return list;
        }

        public Budget GetCurrentBudget(string userId)
        {
            var user = _userRepo.GetUser(userId);
           return _budgetRepo.GetCurrentBudget(user);
        }

        public async Task Post(Budget budget, string userId)
        {
            var person = _userRepo.GetUser(userId);
            var fixedCosts = _fixedCostRepo.Get(person).ToList();
            decimal totalFixedCostSum = 0;
            foreach (var item in fixedCosts)
            {
                totalFixedCostSum += item.Cost;
            }
            budget.User = person;
            budget.FixedCostsCategories = fixedCosts;
            budget.Unbudgeted = budget.Income - totalFixedCostSum;
            await _budgetRepo.Post(budget);
        }
    }
}

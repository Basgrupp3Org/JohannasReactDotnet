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
        private readonly IFixedCostCategoryRepo _fixedCostCategoryRepo;

        public BudgetService(IBudgetRepo budgetRepo, IFixedCostCategoryRepo fixedCostCategoryRepo, IUserRepo userRepo)
        {
            _budgetRepo = budgetRepo;
            _fixedCostCategoryRepo = fixedCostCategoryRepo;
            _userRepo = userRepo;
        } 
        public async Task Edit(EditBudgetDTO budget)
        {
            await _budgetRepo.Edit(budget);
        }

        public IEnumerable<BudgetDTO> Get(string userId)
        {
            return _budgetRepo.Get(userId);
        }

        public async Task Post(Budget budget, string userId)
        {
            var fixedListDto = _fixedCostCategoryRepo.Get(userId);
            var fixedList = new List<FixedCostsCategories>();
            foreach (var item in fixedListDto)
            {
                fixedList.Add(new FixedCostsCategories
                {
                    Name = item.Name,
                    Id = item.Id,
                    Cost = item.Cost

                }) ;
            }
            decimal totalFixedCostSum = 0;
            foreach (var item in fixedList)
            {
                totalFixedCostSum += item.Cost;
            }
            budget.User = _userRepo.GetUser(userId);
            budget.FixedCostsCategories = fixedList;
            budget.Unbudgeted = budget.Income - totalFixedCostSum;
            await _budgetRepo.Post(budget, userId);

        }
    }
}

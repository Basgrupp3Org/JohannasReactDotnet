using JohannasReactProject.Data;
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
    public class VariableCostCategoryService : IVariableCostCategoryService

    {
        private readonly IVariableCostCategoryRepo _variableCostCategoryRepo;
        private readonly IUserRepo _userRepo;
        private readonly IBudgetCategoryRepo _budgetCategoryRepo;
        private readonly IBudgetRepo _budgetRepo;
        public VariableCostCategoryService(IVariableCostCategoryRepo variableCostCategoryRepo, IUserRepo userRepo, IBudgetCategoryRepo budgetCategoryRepo, IBudgetRepo budgetRepo)
        {
            _variableCostCategoryRepo = variableCostCategoryRepo;
            _userRepo = userRepo;
            _budgetCategoryRepo = budgetCategoryRepo;
            _budgetRepo = budgetRepo;
        }
        public async Task Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO, string userId)
        {
            var user = _userRepo.GetUser(userId);
            var editedVariableCostCategory = new VariableCostsCategories { User = user, Name = editVariableCostCategoryDTO.Name, Spent = editVariableCostCategoryDTO.Spent, ToSpend = editVariableCostCategoryDTO.ToSpend, Id = editVariableCostCategoryDTO.Id };
            await _variableCostCategoryRepo.Edit(editedVariableCostCategory);
        }

        public IEnumerable<VariableCostCategoryDTO> Get(string userId)
        {
            var returnList = new List<VariableCostCategoryDTO>();
            var user = _userRepo.GetUser(userId);
            var variableList = _variableCostCategoryRepo.Get(user);
            foreach (var item in variableList)
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
            //var currentBudget = _context.Budgets.Where(b => b.User.Id == userId).OrderByDescending(b => b.StartDate).FirstOrDefault();
            var user = _userRepo.GetUser(userId);
            var currentBudget = _budgetRepo.GetCurrentBudget(user);
            var budgetCategories = _budgetCategoryRepo.Get(currentBudget);

            foreach (var item in budgetCategories)
            {
                returnList.Add(new VariableCostCategoryDTO
                {
                    Id = item.VariableCostsCategory.Id,
                    Name = item.VariableCostsCategory.Name,
                    Spent = item.VariableCostsCategory.Spent,
                    ToSpend = item.VariableCostsCategory.ToSpend
                });
            }
            return returnList;
        }

        public async Task Post(VariableCostsCategories variableCostsCategories, string userId)
        {
            var user = _userRepo.GetUser(userId);
            var currentBudget = _budgetRepo.GetCurrentBudget(user);
            variableCostsCategories.User = user;
            await _variableCostCategoryRepo.Post(variableCostsCategories);
            currentBudget.Unbudgeted -= variableCostsCategories.ToSpend - variableCostsCategories.Spent;
            var budgetCategory = new BudgetCategory
            {
                Budget = currentBudget,
                User = user,
                VariableCostsCategory = variableCostsCategories,
                MaxSpent = variableCostsCategories.ToSpend
            };
            _budgetCategoryRepo.Post(budgetCategory);
        }
    }
}

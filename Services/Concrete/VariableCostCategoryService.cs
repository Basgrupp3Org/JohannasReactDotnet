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
        public VariableCostCategoryService(IVariableCostCategoryRepo variableCostCategoryRepo, IUserRepo userRepo)
        {
            _variableCostCategoryRepo = variableCostCategoryRepo;
            _userRepo = userRepo;
        }
        public async Task Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO)
        {
            await _variableCostCategoryRepo.Edit(editVariableCostCategoryDTO);
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
            var currentBudget = _context.Budgets.Where(b => b.User.Id == userId).OrderByDescending(b => b.StartDate).FirstOrDefault();
            var budgetCategories = _context.BudgetCategories.Where(x => x.Budget.Id == currentBudget.Id).Include(v => v.VariableCostsCategory).ToList();

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
            await _variableCostCategoryRepo.Post(variableCostsCategories, userId);
        }
    }
}

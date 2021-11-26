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
    public class FixedCostCategoryService : IFixedCostCategoryService
    {
        private readonly IFixedCostCategoryRepo _fixedCostCategoryRepo;
        private readonly IUserRepo _userRepo;
        private readonly IBudgetRepo _budgetRepo;

        public FixedCostCategoryService(IFixedCostCategoryRepo fixedCostCategoryRepo, IUserRepo userRepo, IBudgetRepo budgetRepo)
        {
            _fixedCostCategoryRepo = fixedCostCategoryRepo;
            _userRepo = userRepo;
            _budgetRepo = budgetRepo;
        }
        public async Task Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO, string userId)
        {
            var user = _userRepo.GetUser(userId);
            var budget = _budgetRepo.Get(user);
            var editedFixedCostCategory = new FixedCostsCategories { User = user, Name = editFixedCostCategoryDTO.Name, Cost = editFixedCostCategoryDTO.Cost, Budget = budget, Id = editFixedCostCategoryDTO.Id };
           await _fixedCostCategoryRepo.Edit(editedFixedCostCategory);
        } 

        public IEnumerable<FixedCostCategoryDTO> Get(string userId)
        {
            var returnList = new List<FixedCostCategoryDTO>();
            var user = _userRepo.GetUser(userId);
            var fixedList = _fixedCostCategoryRepo.Get(user);
            foreach (var item in fixedList)
            {
                returnList.Add(new FixedCostCategoryDTO
                {
                    Name = item.Name,
                    Cost = item.Cost
                });
            }
            return returnList;
        }

        public async Task Post(FixedCostsCategories fixedCostsCategory, string userId)
        {
            var user = _userRepo.GetUser(userId);
            var budget = _budgetRepo.GetCurrentBudget(user);
            fixedCostsCategory.User = user;
            budget.FixedCostsCategories.Add(fixedCostsCategory);
            budget.Unbudgeted -= fixedCostsCategory.Cost;
            await _fixedCostCategoryRepo.Post(fixedCostsCategory);
        }
    }
}

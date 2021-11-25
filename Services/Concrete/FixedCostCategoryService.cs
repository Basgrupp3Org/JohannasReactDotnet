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

        public FixedCostCategoryService(IFixedCostCategoryRepo fixedCostCategoryRepo, IUserRepo userRepo)
        {
            _fixedCostCategoryRepo = fixedCostCategoryRepo;
            _userRepo = userRepo;
        }
        public async Task Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
           await _fixedCostCategoryRepo.Edit(editFixedCostCategoryDTO);
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

        public async Task Post(FixedCostsCategories fixedCostsCategories, string userId)
        {
            await _fixedCostCategoryRepo.Post(fixedCostsCategories, userId);
        }
    }
}

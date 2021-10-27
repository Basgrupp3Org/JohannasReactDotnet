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
        public FixedCostCategoryService(IFixedCostCategoryRepo fixedCostCategoryRepo) => _fixedCostCategoryRepo = fixedCostCategoryRepo;
        public async Task Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
           await _fixedCostCategoryRepo.Edit(editFixedCostCategoryDTO);
        }

        public async Task Post(FixedCostsCategories fixedCostsCategories)
        {
            await _fixedCostCategoryRepo.Post(fixedCostsCategories);
        }
    }
}

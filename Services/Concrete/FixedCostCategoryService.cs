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
        public void Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
            _fixedCostCategoryRepo.Edit(editFixedCostCategoryDTO);
        }

        public void Post(FixedCostsCategories fixedCostsCategories)
        {
            _fixedCostCategoryRepo.Post(fixedCostsCategories);
        }
    }
}

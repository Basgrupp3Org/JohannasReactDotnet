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
        public VariableCostCategoryService(IVariableCostCategoryRepo variableCostCategoryRepo) => _variableCostCategoryRepo = variableCostCategoryRepo;
        public void Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO)
        {
            _variableCostCategoryRepo.Edit(editVariableCostCategoryDTO);
        }

        public void Post(VariableCostsCategories variableCostsCategories)
        {
            _variableCostCategoryRepo.Post(variableCostsCategories);
        }
    }
}

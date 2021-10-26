using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;

namespace JohannasReactProject.Services.Abstract
{
   public interface IVariableCostCategoryService
    {
        void Post(VariableCostsCategories variableCostsCategories);
        void Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO);
    }
}

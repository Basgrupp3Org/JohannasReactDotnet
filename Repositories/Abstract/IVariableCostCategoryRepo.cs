using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Abstract
{
    public interface IVariableCostCategoryRepo
    {
        void Post(VariableCostsCategories variableCostsCategories);
        void Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO);
    }
}

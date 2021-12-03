using JohannasReactProject.Models;
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
        Task Post(VariableCostsCategories variableCostsCategories);
        Task Edit(VariableCostsCategories editedVariableCostCategories);
        IEnumerable<VariableCostsCategories> Get(ApplicationUser user);
        //IEnumerable<VariableCostCategoryDTO> GetForCurrentBudget(string userId);
    }
}

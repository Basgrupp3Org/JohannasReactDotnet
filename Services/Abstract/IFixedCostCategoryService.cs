using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Services.Abstract
{
    public interface IFixedCostCategoryService
    {
        Task Post(FixedCostsCategories fixedCostsCategory, string userId);
        Task Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO, string userId);
        IEnumerable<FixedCostCategoryDTO> Get(string userId);
    }
}

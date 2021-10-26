using JohannasReactProject.Data;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class VariableCostCategoryRepo : IVariableCostCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public VariableCostCategoryRepo (ApplicationDbContext context) => _context = context;
        public void Edit(EditVariableCostCategoryDTO editVariableCostCategoryDTO)
        {
            var foundCategory = _context.VariableCostsCategories.Where(x => x.Id == editVariableCostCategoryDTO.Id).FirstOrDefault();

            foundCategory.Name = editVariableCostCategoryDTO.Name;
            foundCategory.Spent= editVariableCostCategoryDTO.Spent;
            foundCategory.ToSpend = editVariableCostCategoryDTO.ToSpend;

            _context.SaveChanges();
        }

        public void Post(VariableCostsCategories variableCostsCategories)
        {
            _context.VariableCostsCategories.Add(variableCostsCategories);
            _context.SaveChanges();
        }
    }
}

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
    public class FixedCostCategoryRepo : IFixedCostCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public FixedCostCategoryRepo(ApplicationDbContext context) => _context = context;
        public void Edit(EditFixedCostCategoryDTO editFixedCostCategoryDTO)
        {
            var foundCategory = _context.FixedCostsCategories.Where(x => x.Id == editFixedCostCategoryDTO.Id).FirstOrDefault();

            foundCategory.Name = editFixedCostCategoryDTO.Name;
            foundCategory.Cost = editFixedCostCategoryDTO.Cost;

            _context.SaveChanges();
        }

        public void Post(FixedCostsCategories fixedCostsCategories)
        {
            _context.FixedCostsCategories.Add(fixedCostsCategories);
            _context.SaveChanges();
        }
    }
}

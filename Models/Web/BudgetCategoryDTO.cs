using JohannasReactProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Models.Web
{
    public class BudgetCategoryDTO
    {
        public virtual Budget Budget { get; set; }

        public virtual VariableCostsCategories VariableCostsCategory { get; set; }
        public decimal MaxSpent { get; set; }
    }
}

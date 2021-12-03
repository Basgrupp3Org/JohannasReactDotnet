using JohannasReactProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Abstract
{
    public interface IBudgetCategoryRepo
    {
        IEnumerable<BudgetCategory> Get(Budget currentBudget);
        void Post(BudgetCategory budgetCategory);
    }
}

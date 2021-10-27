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
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepo;
        public BudgetService(IBudgetRepo budgetRepo) => _budgetRepo = budgetRepo;
        public async Task Edit(EditBudgetDTO budget)
        {
            await _budgetRepo.Edit(budget);
        }

        public async Task Post(Budget budget)
        {
           await _budgetRepo.Post(budget);
        }
    }
}

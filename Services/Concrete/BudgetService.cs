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
        public void Edit(EditBudgetDTO budget)
        {
            _budgetRepo.Edit(budget);
        }

        public void Post(Budget budget)
        {
            _budgetRepo.Post(budget);
        }
    }
}

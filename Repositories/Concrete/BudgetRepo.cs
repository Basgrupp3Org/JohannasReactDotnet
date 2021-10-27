﻿using JohannasReactProject.Data;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class BudgetRepo : IBudgetRepo
    {
        private readonly ApplicationDbContext _context;

        public BudgetRepo(ApplicationDbContext context) => _context = context;
        public async Task Edit(EditBudgetDTO budget)
        {
            var foundBudget = _context.Budgets.Where(x => x.Id == budget.Id).FirstOrDefault();
           
                foundBudget.Income = budget.Income;
                foundBudget.StartDate = budget.StartDate;
                foundBudget.EndDate = budget.EndDate;

            await _context.SaveChangesAsync();
            
        }

        public async Task Post(Budget budget)
        {
            _context.Budgets.Add(budget);
           await _context.SaveChangesAsync();
        }
    }
}

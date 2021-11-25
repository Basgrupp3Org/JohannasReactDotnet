﻿using JohannasReactProject.Data;
using JohannasReactProject.Models;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<BudgetDTO> Get(string userId)
        {
            var list = new List<BudgetDTO>();
            var fixedList = new List<FixedCostCategoryDTO>();

            var budget = _context.Budgets.Where(b => b.User.Id == userId).ToList();

            foreach (var item in budget)
            {
                list.Add(new BudgetDTO
                {
                    StartDate = item.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = item.EndDate.ToString("yyyy-MM-dd"),
                    Income = item.Income,
                    Unbudgeted = item.Unbudgeted,
                    Name = item.Name
                });
            }
            return list;
        }

        public async Task Post(Budget budget, string userId)
        {
            var person = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var fixedCosts = _context.FixedCostsCategories.Where(f => f.User.Id == userId).ToList();
            decimal totalFixedCostSum = 0;
            foreach(var item in fixedCosts)
            {
                totalFixedCostSum += item.Cost;
            }
            budget.User = person;
            budget.FixedCostsCategories = fixedCosts;
            budget.Unbudgeted = budget.Income - totalFixedCostSum;
            _context.Budgets.Add(budget);
           await _context.SaveChangesAsync();
        }
    }
}

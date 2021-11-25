using JohannasReactProject.Data;
using JohannasReactProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class BudgetCategoryRepo : IBudgetCategoryRepo
    {
        private readonly ApplicationDbContext _context;
    }
}

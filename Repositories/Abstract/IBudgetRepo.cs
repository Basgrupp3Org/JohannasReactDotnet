using JohannasReactProject.Models;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Abstract
{
    public interface IBudgetRepo
    {
        Task Post(Budget budget);
        Task Edit(EditBudgetDTO budget);
        ICollection<Budget> Get(ApplicationUser user);
        Budget GetCurrentBudget(ApplicationUser user);
    }
}

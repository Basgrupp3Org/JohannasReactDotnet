using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Services.Abstract
{
    public interface ISavingGoalService
    {
        void Post(SavingGoal savingGoal);
        void Edit(EditSavingGoalDTO editSavingGoalDTO);
    }
}

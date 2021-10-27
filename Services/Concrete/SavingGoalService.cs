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
    public class SavingGoalService : ISavingGoalService
    {
        private readonly ISavingGoalRepo _savingGoalRepo;
        public SavingGoalService(ISavingGoalRepo savingGoalRepo) => _savingGoalRepo = savingGoalRepo;
        public async Task Edit(EditSavingGoalDTO editSavingGoalDTO)
        {
            await _savingGoalRepo.Edit(editSavingGoalDTO);
        }

        public async Task Post(SavingGoal savingGoal)
        {
            await _savingGoalRepo.Post(savingGoal);
        }
    }
}

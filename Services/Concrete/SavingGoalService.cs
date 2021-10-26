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
        public void Edit(EditSavingGoalDTO editSavingGoalDTO)
        {
            _savingGoalRepo.Edit(editSavingGoalDTO);
        }

        public void Post(SavingGoal savingGoal)
        {
            _savingGoalRepo.Post(savingGoal);
        }
    }
}

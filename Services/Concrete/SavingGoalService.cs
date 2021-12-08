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
        private readonly IUserRepo _userRepo;
        public SavingGoalService(ISavingGoalRepo savingGoalRepo, IUserRepo userRepo)
        {
            _savingGoalRepo = savingGoalRepo;
            _userRepo = userRepo;
        }

        public async Task Edit(EditSavingGoalDTO editSavingGoalDTO)
        {
            await _savingGoalRepo.Edit(editSavingGoalDTO);
        }

        public IEnumerable<SavingGoalDTO> Get(string userId)
        {
            var returnList = new List<SavingGoalDTO>();
            var user = _userRepo.GetUser(userId);
            var savingGoalList = _savingGoalRepo.Get(user);

            foreach (var item in savingGoalList)
            {
                returnList.Add(new SavingGoalDTO
                {
                    Name = item.Name,
                    Saved = item.Saved,
                    ToSave = item.ToSave

                });
            }

            return returnList;
        }

        public async Task Post(SavingGoal savingGoal, string userId)
        {
            var person = _userRepo.GetUser(userId);
            savingGoal.User = person;
            await _savingGoalRepo.Post(savingGoal);
        }
    }
}

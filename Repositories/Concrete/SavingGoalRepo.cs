using JohannasReactProject.Data;
using JohannasReactProject.Models.Entities;
using JohannasReactProject.Models.Web;
using JohannasReactProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class SavingGoalRepo : ISavingGoalRepo
    {
        private readonly ApplicationDbContext _context;
        public SavingGoalRepo(ApplicationDbContext context) => _context = context;
        public void Edit(EditSavingGoalDTO editSavingGoalDTO)
        {
            var foundSavingGoal = _context.SavingGoals.Where(x => x.Id == editSavingGoalDTO.Id).FirstOrDefault();

            foundSavingGoal.Name = editSavingGoalDTO.Name;
            foundSavingGoal.Saved = editSavingGoalDTO.Saved;
            foundSavingGoal.ToSave = editSavingGoalDTO.ToSave;

            _context.SaveChanges();
        }

        public void Post(SavingGoal savingGoal)
        {
            _context.SavingGoals.Add(savingGoal);
            _context.SaveChanges();
        }
    }
}

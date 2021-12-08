using JohannasReactProject.Data;
using JohannasReactProject.Models;
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
        
        public async Task Edit(EditSavingGoalDTO editSavingGoalDTO)
        {
            var foundSavingGoal = _context.SavingGoals.Where(x => x.Id == editSavingGoalDTO.Id).FirstOrDefault();

            foundSavingGoal.Name = editSavingGoalDTO.Name;
            foundSavingGoal.Saved = editSavingGoalDTO.Saved;
            foundSavingGoal.ToSave = editSavingGoalDTO.ToSave;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<SavingGoal> Get(ApplicationUser user)
        {
            return _context.SavingGoals.Where(u => u.User == user).ToList();
        }

        public async Task Post(SavingGoal savingGoal)
        {
            _context.SavingGoals.Add(savingGoal);
            await _context.SaveChangesAsync();
        }
    }
}

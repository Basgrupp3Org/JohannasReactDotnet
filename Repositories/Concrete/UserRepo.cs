using JohannasReactProject.Data;
using JohannasReactProject.Models;
using JohannasReactProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Concrete
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context) => _context = context;
    
        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}

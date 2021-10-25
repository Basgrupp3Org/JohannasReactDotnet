using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Models.Entities
{
    public class Budget : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Income { get; set; }
        public decimal Housing { get; set; }
        public decimal Vehicle { get; set; }
        public decimal Unbudgeted { get; set; }
        //public virtual JohannasBaksidaUser User { get; set; }
        //public virtual ICollection<BudgetCategory> BudgetCategory { get; set; }
    }

    
}

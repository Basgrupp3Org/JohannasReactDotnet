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
    public class PurchaseRepo  : IPurchaseRepo
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepo(ApplicationDbContext context) => _context = context;
        public void Edit(EditPurchaseDTO editPurchaseDTO)
        {
            var foundPurchase = _context.Purchases.Where(x => x.Id == editPurchaseDTO.Id).FirstOrDefault();

            foundPurchase.Name = editPurchaseDTO.Name;

            foundPurchase.Price = editPurchaseDTO.Price;

            foundPurchase.Date = editPurchaseDTO.Date;



            _context.SaveChanges();
        }

        public void Post(Purchase purchases)
        {
            _context.Purchases.Add(purchases);
            _context.SaveChanges();
        }
    }
}

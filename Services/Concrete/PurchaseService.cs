using JohannasReactProject.Data;
using JohannasReactProject.Models;
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
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepo _purchaseRepo;
        private readonly IUserRepo _userRepo;


        public PurchaseService(IPurchaseRepo purchaseRepo, IUserRepo userRepo)
        {
            _purchaseRepo = purchaseRepo;
            _userRepo = userRepo;

            
        }
        public async Task Edit(EditPurchaseDTO purchase)
        {
            await _purchaseRepo.Edit(purchase);
        }

        public ICollection<PurchaseDTO> Get(string userId)
        {
            var returnList = new List<PurchaseDTO>();
            var user = _userRepo.GetUser(userId);
            var purchases = _purchaseRepo.Get(user);

            foreach (var item in purchases)
            {
                returnList.Add(new PurchaseDTO
                {
                    Price = item.Price,
                    Date = item.Date,
                    Name = item.Name

                });

            }
            return returnList;
        }

        public async Task Post(Purchase purchase, string userId)
        {
            var person = _userRepo.GetUser(userId);
            purchase.User = person;
            await _purchaseRepo.Post(purchase);
        }
    }
}

    
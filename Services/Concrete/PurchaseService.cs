﻿using JohannasReactProject.Models.Entities;
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
        public PurchaseService(IPurchaseRepo purchaseRepo) => _purchaseRepo = purchaseRepo;
        public async Task Edit(EditPurchaseDTO purchase)
        {
            await _purchaseRepo.Edit(purchase);
        }

        public async Task Post(Purchase purchase)
        {
            await _purchaseRepo.Post(purchase);
        }
    }
}

    
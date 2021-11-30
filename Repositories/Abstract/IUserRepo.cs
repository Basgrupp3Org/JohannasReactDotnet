﻿using JohannasReactProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohannasReactProject.Repositories.Abstract
{
    public interface IUserRepo
    {
        public ApplicationUser GetUser(string userId);
    }
}

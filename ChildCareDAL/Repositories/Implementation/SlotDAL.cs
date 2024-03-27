﻿using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCareDAL.Repositories.Implementation
{
    public class SlotDAL :GenericRepository<SlotList> ,ISlotDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SlotDAL(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}

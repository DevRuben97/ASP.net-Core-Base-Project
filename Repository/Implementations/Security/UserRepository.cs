﻿using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository.Base;
using Repository.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations.Security
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetFullUserInfo(int Id)
        {
            return await   _Dbcontext.Users
                .Include(x => x.UserRoles).ThenInclude(x => x.Rol)
                .FirstOrDefaultAsync();
        }
    }
}

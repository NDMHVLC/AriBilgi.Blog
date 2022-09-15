﻿using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext context) : base(context)
        {
        }
    }
}

using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Persistence.Contexts
{
    public class MsSqlDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MsSqlDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}

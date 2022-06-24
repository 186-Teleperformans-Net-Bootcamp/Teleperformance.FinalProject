using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Persistence.Contexts
{
    public class MsSqlDbContext : DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {

        }


    }
}

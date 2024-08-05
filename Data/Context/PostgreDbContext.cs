using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class PostgreDbContext : ProjectDbContext
    {
        public PostgreDbContext()
        {

        }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options, IConfiguration configuration)
            : base(options, configuration)
        {
        }
    }
}

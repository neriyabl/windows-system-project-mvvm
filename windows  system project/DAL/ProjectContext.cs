using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}

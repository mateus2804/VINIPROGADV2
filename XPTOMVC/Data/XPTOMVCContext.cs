using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPTOMVC.Models;

namespace XPTOMVC.Data
{
    public class XPTOMVCContext : DbContext
    {
        public XPTOMVCContext (DbContextOptions<XPTOMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Servico> Servico { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<PrestadorServico> PrestadorServico { get; set; }
    }
}

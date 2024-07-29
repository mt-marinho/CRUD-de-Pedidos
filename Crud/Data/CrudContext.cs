using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crud1.Models;

namespace Crud.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext (DbContextOptions<CrudContext> options)
            : base(options)
        {
        }

        public DbSet<Crud1.Models.Pedido> Pedido { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Desconto)
                .HasColumnType("decimal(18,2)");

           
        }
    }
}

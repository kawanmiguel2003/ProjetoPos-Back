using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProjetoPos.Domain.Entities;
using ProjetoPos.Infra.CrossCutting.NotificationPattern.DTOs;

namespace ProjetoPos.Infra.Data.Context
{
    public class ProjetoPosContext : DbContext
    {
        public ProjetoPosContext(DbContextOptions<ProjetoPosContext> options) : base(options)
        {
        }
        public DbSet<Professor> ProfessorSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

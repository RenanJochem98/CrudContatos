
using FrontEndAspNetMvc.Models;
using FrontEndAspNetMvc.Services;
using Microsoft.EntityFrameworkCore;

namespace FrontEndAspNetMvc.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext() { }
        public AgendaContext(DbContextOptions<AgendaContext> dbContext) : base(dbContext) { }
    
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppSettingsService.GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

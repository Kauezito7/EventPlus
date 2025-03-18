using Event_plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Context
{
    public class Evento_Context : DbContext
    {
        public Evento_Context()
        {
        }

        public Evento_Context(DbContextOptions<Evento_Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<PresencaEventos> PresencaEventos { get; set; }

     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =NOTE03-S28\\SQLEXPRESS; Database = event_plus; User Id=sa; Pwd = Senai@134; TrustServerCertificate=true;");

            }

        }
    

    }
}

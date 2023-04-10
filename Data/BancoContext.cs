using AgendaDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}

using CrudDotNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNetMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<UsuariosModel> Usuarios { get; set; }
        public DbSet<TasksModel> Tasks { get; set; }
    }
}

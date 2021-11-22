using EFCoreWorkService.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWorkService.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Usuarios { get; set; }

       
    }
}

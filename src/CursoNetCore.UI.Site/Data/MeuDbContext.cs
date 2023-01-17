using Microsoft.EntityFrameworkCore;

namespace CursoNetCore.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
        : base(options)
        {

        }
    }
}

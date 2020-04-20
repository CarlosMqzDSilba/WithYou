using Microsoft.EntityFrameworkCore;
using WithYou.Web.Data.Entities;

namespace WithYou.Web.Data
{
    public class DataContext : DbContext
    {
        DbSet<Gender> Genders { get; set; }
        DbSet<TipoProyecto> TipoProyectos { get; set; }
        DbSet<Investigation> Investigations { get; set; }
        DbSet<Researcher> Researchers { get; set; }
        DbSet<RepublicState> RepublicStates { get; set; }
        DbSet<Leader> Leaders { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
    }
}

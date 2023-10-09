using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TesteAutoGlass.Core.Entities;

namespace TesteAutoGlass.Infrastructure.Persistence
{
    public class AutoGlassDbContext : DbContext
    {
        public AutoGlassDbContext(DbContextOptions<AutoGlassDbContext> options) : base(options)
        {
            //Products = new List<Product>
            //{
            //    new Product("Produto 1", new DateTime(2021,10,01), new DateTime(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
            //    new Product("Produto 2", new DateTime(2020,09,11), new DateTime(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
            //    new Product("Produto 3", new DateTime(2022,04,21), new DateTime(2023,12,30), 3, "Fornecedor 3", "99.999.999/9999-99"),
            //    new Product("Produto 4", new DateTime(2019,08,13), new DateTime(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
            //    new Product("Produto 5", new DateTime(2017,05,17), new DateTime(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
            //};
        }
        //public List<Product> Products { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Codigo);
        }
    }

    //public class AutoGlassDbContextFactory : IDesignTimeDbContextFactory<AutoGlassDbContext>
    //{
    //    public AutoGlassDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<AutoGlassDbContext>();
    //        optionsBuilder.UseSqlServer(@$"Server=DESKTOP-QGCLP84\RafaelTonon; Database=AutoGlass;Trusted_Connection=True");

    //        return new AutoGlassDbContext(optionsBuilder.Options);
    //    }
    //}
}

using TesteAutoGlass.Core.Entities;

namespace TesteAutoGlass.Infrastructure.Persistence
{
    public class AutoGlassDbContext
    {
        public AutoGlassDbContext()
        {
            Products = new List<Product>
            {
                new Product("Produto 1", new DateOnly(2021,10,01), new DateOnly(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
                new Product("Produto 2", new DateOnly(2020,09,11), new DateOnly(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
                new Product("Produto 3", new DateOnly(2022,04,21), new DateOnly(2023,12,30), 3, "Fornecedor 3", "99.999.999/9999-99"),
                new Product("Produto 4", new DateOnly(2019,08,13), new DateOnly(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
                new Product("Produto 5", new DateOnly(2017,05,17), new DateOnly(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
            };
        }
        public List<Product> Products { get; set; }
    }
}

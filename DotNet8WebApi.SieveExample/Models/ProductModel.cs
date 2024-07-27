using Sieve.Attributes;

namespace DotNet8WebApi.SieveExample.Models;

public class ProductModel
{
    [Sieve(CanSort = true)]
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public decimal Price { get; set; }
}

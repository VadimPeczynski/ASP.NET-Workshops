using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Database
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context;

        public EFProductRepository()
        {
            context = new EFDbContext();
        }
        public IEnumerable<Product> Products => context.Products;
    }
}

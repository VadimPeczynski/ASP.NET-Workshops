using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Domain.DatabaseAccess
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context;

        public EFProductRepository()
        {
            context = new EFDbContext();
        }

        public IEnumerable<Product> Products => context.Products;
    }
}

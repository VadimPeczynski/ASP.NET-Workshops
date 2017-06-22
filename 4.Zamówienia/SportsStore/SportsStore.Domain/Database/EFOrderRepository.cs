using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Database
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EFDbContext _context;

        public EFOrderRepository()
        {
            _context = new EFDbContext();
        }

        public IEnumerable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}

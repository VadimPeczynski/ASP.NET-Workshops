using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
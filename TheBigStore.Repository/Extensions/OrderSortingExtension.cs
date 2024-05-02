using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBigStore.Repository.Enums;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Extensions
{
    public static class OrderSortingExtension
    {
        public static IQueryable<Order> OrderOrdersBy(this IQueryable<Order> order, OrderByOptionsOrder orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptionsOrder.IDDes:
                    return order.OrderByDescending(x => x.Id);

                case OrderByOptionsOrder.IDAsc:
                    return order.OrderBy(x => x.Id);

                case OrderByOptionsOrder.DateAsc:
                    return order.OrderBy(x => x.OrderDate);

                case OrderByOptionsOrder.DateDes:
                    return order.OrderByDescending(x => x.OrderDate);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

    }
}

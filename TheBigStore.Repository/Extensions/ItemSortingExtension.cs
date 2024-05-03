using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBigStore.Repository.Enums;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Extensions
{
    public static class ItemSortingExtension
    {
        public static IQueryable<Item> OrderItemsBy(this IQueryable<Item> item, OrderByOptionsItem orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptionsItem.IDDes:
                    return item.OrderByDescending(x => x.Id);

                case OrderByOptionsItem.IDAsc:
                    return item.OrderBy(x => x.Id);

                case OrderByOptionsItem.PriceAsc:
                    return item.OrderBy(x => x.Price);

                case OrderByOptionsItem.PriceDes:
                    return item.OrderByDescending(x => x.Price);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

    }
}

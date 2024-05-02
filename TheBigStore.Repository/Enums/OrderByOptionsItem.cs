using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Enums
{
    public enum OrderByOptionsItem
    {
        [Display(Name = "ID Descending ↓")]
        IDDes = 0,
        [Display(Name = "ID Ascending ↑")]
        IDAsc,
        [Display(Name = "Price ↓")]
        PriceDes,
        [Display(Name = "Price ↑")]
        PriceAsc
    }
}

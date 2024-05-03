using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Enums
{
    public enum OrderByOptionsOrder
    {
        [Display(Name = "Order Id Descending ↓")]
        IDDes = 0,
        [Display(Name = "Order Id Ascending ↑")]
        IDAsc,
        [Display(Name = "Created Date ↓")]
        DateDes,
        [Display(Name = "Created Date ↑")]
        DateAsc
    }
}

using Microsoft.AspNetCore.JsonPatch;
using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Extensions
{
    public static class ItemPatchExtension
    {
        public static JsonPatchDocument<Item> PatchModel(this Item OldItem, Item NewItem)
        {

            if (NewItem == null)
            {
                return new JsonPatchDocument<Item>(); // No Changes
            }
            else if (OldItem == null)
            {
                return new JsonPatchDocument<Item>();
            }


            JsonPatchDocument<Item> patchdoc = new();


            if (NewItem.ItemName != OldItem.ItemName)
            {
                patchdoc.Replace(p => p.ItemName, NewItem.ItemName);
            }
            if (NewItem.Description != OldItem.Description)
            {
                patchdoc.Replace(p => p.Description, NewItem.Description);
            }
            if (NewItem.Price != OldItem.Price)
            {
                patchdoc.Replace(p => p.Price, NewItem.Price);
            }
            if (NewItem.CategoryId != OldItem.CategoryId)
            {
                patchdoc.Replace(p => p.CategoryId, NewItem.CategoryId);
            }
            //var props = OldItem.GetType().GetProperties();

            //foreach (PropertyInfo propertyInfo in props)
            //{
            //    PropertyInfo correspondingProperty = NewItem.GetType().GetProperty(propertyInfo.Name);

            //    if (correspondingProperty != null)
            //    {
            //        object OldValue = propertyInfo.GetValue(OldItem);
            //        object NewValue = correspondingProperty.GetValue(NewItem);

            //        if (OldValue != NewValue)
            //        {
            //            patchdoc.Replace(p => propertyInfo.Name, NewValue);
            //        }
            //    }
            //}

            return patchdoc;
        }

    }
}

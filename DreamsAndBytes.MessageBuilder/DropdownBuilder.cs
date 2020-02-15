using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamsAndBytes.Builder
{
    public static class DropdownBuilder
    {
        private static List<SelectListItem> selectListItems;

        public static List<SelectListItem> CreateProductTypeDropdownList(List<ProductTypeEntity> productTypeEntities)
        {
            selectListItems = new List<SelectListItem>();
            Parallel.ForEach(productTypeEntities, (productTypeEntity) =>
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = productTypeEntity.Name,
                    Value = productTypeEntity.ID.ToString(),
                    Selected = false
                });
            });
            return selectListItems;
        }

    }
}

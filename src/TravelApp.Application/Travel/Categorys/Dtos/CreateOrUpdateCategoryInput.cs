

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Travel.Categorys;

namespace TravelApp.Travel.Categorys.Dtos
{
    public class CreateOrUpdateCategoryInput
    {
        [Required]
        public CategoryEditDto Category { get; set; }

    }
}
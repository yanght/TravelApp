

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Travel;

namespace TravelApp.Travel.Dtos
{
    public class CreateOrUpdateCategoryInput
    {
        [Required]
        public CategoryEditDto Category { get; set; }

    }
}
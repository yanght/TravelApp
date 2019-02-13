

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelApp.Travel;

namespace TravelApp.Travel.Dtos
{
    public class CreateOrUpdateProjectInput
    {
        [Required]
        public ProjectEditDto Project { get; set; }

    }
}
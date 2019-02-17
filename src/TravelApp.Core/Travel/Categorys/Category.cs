using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelApp.Travel.Categorys
{
    public class Category : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        public virtual string CategoryName { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int ParentId { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int State { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int Sort { get; set; }
    }
}

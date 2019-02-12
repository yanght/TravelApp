using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelApp.Travel
{
    public class Category : Entity<int>
    {
        [Required]
        [MaxLength(10)]
        public virtual string CategoryName { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int ParentId { get; set; }

        [Required]
        [DefaultValue(true)]
        public virtual bool Enable { get; set; }
    }
}

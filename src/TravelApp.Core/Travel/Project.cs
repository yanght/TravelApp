using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace TravelApp.Travel
{
    public class Project : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int CategoryId { get; set; }

        [MaxLength(500)]
        public virtual string Describe { get; set; }

        [Column(TypeName = "text")]
        public virtual string Content { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual decimal Price { get; set; }

        public virtual string Picture { get; set; }

        public virtual string StartDate { get; set; }

        [Required]
        [DefaultValue(0)]
        public virtual int State { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsRecommend { get; set; }


    }
}

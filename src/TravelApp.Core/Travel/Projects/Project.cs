using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace TravelApp.Travel.Projects
{
    public class Project : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Describe { get; set; }
        public virtual string Content { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Picture { get; set; }
        public virtual string StartDate { get; set; }
        public virtual int State { get; set; }
        public virtual bool IsRecommend { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}

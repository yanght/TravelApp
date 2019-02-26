
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using TravelApp.Travel;

namespace  TravelApp.Travel.Dtos
{
    public class ProjectEditDto
    {
        public int? Id { get; set; }         
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public string Describe { get; set; }
		public string Content { get; set; }
		public decimal Price { get; set; }
		public string Picture { get; set; }
		public string StartDate { get; set; }
		public int State { get; set; }
		public bool IsRecommend { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using TravelApp.Travel;

namespace  TravelApp.Travel.Dtos
{
    public class ProjectEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
[MaxLength(100)]
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public int CategoryId { get; set; }



		/// <summary>
		/// Describe
		/// </summary>
[MaxLength(500)]
		public string Describe { get; set; }



		/// <summary>
		/// Content
		/// </summary>
		public string Content { get; set; }



		/// <summary>
		/// Price
		/// </summary>
		[Required(ErrorMessage="Price不能为空")]
		public decimal Price { get; set; }



		/// <summary>
		/// Picture
		/// </summary>
		public string Picture { get; set; }



		/// <summary>
		/// StartDate
		/// </summary>
		public string StartDate { get; set; }



		/// <summary>
		/// State
		/// </summary>
		[Required(ErrorMessage="State不能为空")]
		public int State { get; set; }



		/// <summary>
		/// IsRecommend
		/// </summary>
		[Required(ErrorMessage="IsRecommend不能为空")]
		public bool IsRecommend { get; set; }




    }
}
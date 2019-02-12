
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using TravelApp.Travel;

namespace  TravelApp.Travel.Dtos
{
    public class CategoryEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// CategoryName
		/// </summary>
[MaxLength(10)]
		[Required(ErrorMessage="CategoryName不能为空")]
		public string CategoryName { get; set; }



		/// <summary>
		/// ParentId
		/// </summary>
		[Required(ErrorMessage="ParentId不能为空")]
		public int ParentId { get; set; }



		/// <summary>
		/// Enable
		/// </summary>
		[Required(ErrorMessage="Enable不能为空")]
		public bool Enable { get; set; }




    }
}
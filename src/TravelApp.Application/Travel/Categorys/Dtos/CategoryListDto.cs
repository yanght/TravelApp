

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using TravelApp.Travel.Categorys;

namespace TravelApp.Travel.Categorys.Dtos
{
    public class CategoryListDto : EntityDto<int> 
    {

        
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
		/// State
		/// </summary>
		[Required(ErrorMessage="State不能为空")]
		public int State { get; set; }



		/// <summary>
		/// Sort
		/// </summary>
		[Required(ErrorMessage="Sort不能为空")]
		public int Sort { get; set; }




    }
}
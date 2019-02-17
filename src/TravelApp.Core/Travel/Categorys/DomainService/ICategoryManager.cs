

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using TravelApp.Travel.Categorys;


namespace TravelApp.Travel.Categorys.DomainService
{
    public interface ICategoryManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCategory();



		 
      
         

    }
}

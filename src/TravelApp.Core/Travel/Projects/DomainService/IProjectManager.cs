

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using TravelApp.Travel;


namespace TravelApp.Travel.DomainService
{
    public interface IProjectManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitProject();



		 
      
         

    }
}

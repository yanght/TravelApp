

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using TravelApp;
using TravelApp.Travel;
using TravelApp.Travel.Projects;

namespace TravelApp.Travel.DomainService
{
    /// <summary>
    /// Project领域层的业务管理
    ///</summary>
    public class ProjectManager :TravelAppDomainServiceBase, IProjectManager
    {
		
		private readonly IRepository<Project,int> _repository;

		/// <summary>
		/// Project的构造方法
		///</summary>
		public ProjectManager(
			IRepository<Project, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitProject()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}

using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Travel.Trips
{
    public class Trip : Entity<int>
    {
        /// <summary>
        /// 行程名称
        /// </summary>
        public string TripName { get; set; }
        /// <summary>
        /// 行程简介
        /// </summary>
        public string TripDesc { get; set; }
        /// <summary>
        /// 行程价格
        /// </summary>
        public decimal TripPrice { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 状态 1 正常 
        /// </summary>
        public int Status { get; set; }
    }
}

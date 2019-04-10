using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Travel.TripAttends
{
    public class TripAttend : Entity<int>
    {
        /// <summary>
        /// 班级
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNo { get; set; }
        /// <summary>
        /// 家长手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 行程Id
        /// </summary>
        public string TripId { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public string PayState { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }
        /// <summary>
        /// 微信openid
        /// </summary>
        public string WxopenId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public string PayTime { get; set; }
    }
}

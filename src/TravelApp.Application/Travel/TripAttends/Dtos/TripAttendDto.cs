using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Travel.TripAttends.Dtos
{
    public class TripAttendDto : EntityDto<int>
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
        public int TripId { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int PayState { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 微信openid
        /// </summary>
        public string WxopenId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PayTime { get; set; }
    }
}

/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/13/2016 2:37:05 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportBuyOrderDetailsSearchInput
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 子机构仓库
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 采购单编码
        /// </summary>
        public string BuyID { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// SKU编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime2 { get; set; }

        /// <summary>
        /// 过账时间
        /// </summary>
        public DateTime? PostingTime1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PostingTime2 { get; set; }

        /// <summary>
        /// 账期开始时间
        /// </summary>
        public DateTime? SettDateStart { get; set; }

        /// <summary>
        /// 账期结束时间
        /// </summary>
        public DateTime? SettDateEnd { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int? CategoryId1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CategoryId2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CategoryId3 { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IReportBuyOrderDetailsDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable GetReport(ReportBuyOrderDetailsSearchInput input);

    }
}

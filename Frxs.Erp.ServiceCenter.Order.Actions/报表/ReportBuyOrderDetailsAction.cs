/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/13/2016 2:32:04 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.Utility;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.IDAL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 采购收货明细报表
    /// </summary>
    [ActionName("Report.BuyOrderDetails")]
    [ActionResultCache(1)]
    public class ReportBuyOrderDetailsAction : ActionBase<ReportBuyOrderDetailsAction.ReportBuyOrderDetailsActionRequestDto, string>
    {
        /// <summary>
        /// 上送参数
        /// </summary>
        public class ReportBuyOrderDetailsActionRequestDto : RequestDtoBase
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

            /// <summary>
            /// 账期开始时间
            /// </summary>
            public DateTime? SettDateStart { get; set; }

            /// <summary>
            /// 账期结束时间
            /// </summary>
            public DateTime? SettDateEnd { get; set; }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0)
                {
                    yield return new RequestDtoValidatorResultError("WID");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            var dal = DALFactory.GetLazyInstance<IReportBuyOrderDetailsDAO>(this.RequestDto.WID.ToString());
            DataTable data = dal.GetReport(new ReportBuyOrderDetailsSearchInput()
            {
                WID = this.RequestDto.WID,
                SubWID = this.RequestDto.SubWID,
                CreateUserName = this.RequestDto.CreateUserName,
                BarCode = this.RequestDto.BarCode,
                BuyID = this.RequestDto.BuyID,
                ProductName = this.RequestDto.ProductName,
                SKU = this.RequestDto.SKU,
                VendorCode = this.RequestDto.VendorCode,
                VendorName = this.RequestDto.VendorName,
                CreateTime1 = this.RequestDto.CreateTime1,
                CreateTime2 = this.RequestDto.CreateTime2,
                PostingTime1 = this.RequestDto.PostingTime1,
                PostingTime2 = this.RequestDto.PostingTime2,
                CategoryId1 = this.RequestDto.CategoryId1,
                CategoryId2 = this.RequestDto.CategoryId2,
                CategoryId3 = this.RequestDto.CategoryId3,
                SettDateStart = this.RequestDto.SettDateStart,
                SettDateEnd = this.RequestDto.SettDateEnd
            });


            decimal? sumBuyQty = 0;
            decimal? sumTotalBuyQty = 0;
            decimal? sumBuyQtyNoFaxMoney = 0;
            decimal? sumBuyQtyFaxMoney = 0;
            decimal? sumSh = 0;
            foreach (DataRow item in data.Rows)
            {
                sumBuyQty += DataTypeHelper.GetDecimalNull(item["数量"]);
                sumTotalBuyQty += DataTypeHelper.GetDecimalNull(item["数量合计"]);
                sumBuyQtyNoFaxMoney += DataTypeHelper.GetDecimalNull(item["不含税金额"]);
                sumBuyQtyFaxMoney += DataTypeHelper.GetDecimalNull(item["含税金额"]);
                sumSh += DataTypeHelper.GetDecimalNull(item["散数"]);

                item["包装数"] = DataTypeHelper.GetDecimal(item["包装数"], 0).ToString("0.0000");
                item["含税单价"] = DataTypeHelper.GetDecimal(item["含税单价"], 0).ToString("0.0000"); ;
                item["不含税单价"] = DataTypeHelper.GetDecimal(item["不含税单价"], 0).ToString("0.0000"); ;
                item["税率"] = DataTypeHelper.GetInt(item["税率"], 0);
            }
            DataRow dr = data.NewRow();
            dr["用户单号"] = "合计";
            //dr["包装数"] = "";
            //dr["含税单价"] = "";
            //dr["不含税单价"] = "";
            //dr["税率"] = "";
            dr["散数"] = sumSh;
            dr["数量"] = sumTotalBuyQty;
            dr["数量合计"] = sumTotalBuyQty;
            dr["不含税金额"] = sumBuyQtyNoFaxMoney;
            dr["含税金额"] = sumBuyQtyFaxMoney;
            data.Rows.Add(dr);
            return this.SuccessActionResult(new { total = data.Rows.Count, rows = data }.SerializeObjectToJosn());
        }

    }
}

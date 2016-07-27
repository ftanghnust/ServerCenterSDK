/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/13/2016 2:40:29 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Report
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportBuyOrderDetailsDAO : BaseDAL, IReportBuyOrderDetailsDAO
    {
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public ReportBuyOrderDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public DataTable GetReport(ReportBuyOrderDetailsSearchInput input)
        {

            var sql = @"SELECT 
                            用户单号 = bo.BuyID,
                            过账日 = CONVERT(varchar(100),bo.PostingTime,112),
                            日期 =  CONVERT(varchar(100),bo.PostingTime,120),
                            公司机构 = bo.WName,
                            结算机构 = bo.WName,
                            供应商 = bo.VendorName,
                            供应商编码= bo.VendorCode,
                            仓库 = bo.SubWName,
                            经办人 = bo.PostingUserName,
                            开单人 = bo.CreateUserName,
                            备注 = bo.Remark,
                            商品名称 = bod.ProductName,
                            商品编码 = bod.SKU,
                            商品单位 = bod.BuyUnit,
                            规格 = bod.BuyPackingQty,
                            条码 = bod.BarCode,
                            包装数 =bod.BuyPackingQty,
                            数量 = bod.BuyQty,
                            散数 = 0,
                            数量合计 = bod.BuyPackingQty * bod.BuyQty,
                            不含税单价 = bod.BuyPrice,
                            税率 = 0,
                            含税单价 =bod.BuyPrice,
                            不含税金额 = bod.BuyPrice * bod.BuyQty,
                            含税金额 = bod.BuyPrice * bod.BuyQty,
                            品牌=  bode.BrandId1Name +'-'+ bode.BrandId2Name,
          
                            主供应商 = bo.VendorName,
                            商品分类 = bode.CategoryId1Name +'-'+bode.CategoryId2Name+'-'+ bode.CategoryId3Name,
                            单位 = bod.BuyUnit,
                            账期=CONVERT(varchar(100),bo.Sett_Date,120)

                            FROM BuyOrder bo 
                            INNER JOIN BuyOrderDetails bod ON  bod.BuyID=bo.BuyID 
                            INNER JOIN BuyOrderDetailsExt bode ON bod.ID=bode.ID AND bo.BuyID=bode.BuyID

                            WHERE bo.WID = @WID ";

            SqlParamrterBuilder sqlParamrterBuilder = new SqlParamrterBuilder();

            //仓库ID必须传
            sqlParamrterBuilder.Add("WID", input.WID);

            //仓库子机构
            if (input.SubWID.HasValue)
            {
                sql += " AND bo.SubWID=@SubWID ";
                sqlParamrterBuilder.Add("SubWID", input.SubWID);
            }

            //单据编号
            if (!string.IsNullOrWhiteSpace(input.BuyID))
            {
                sql += " AND bo.BuyID = @BuyID ";
                sqlParamrterBuilder.Add("BuyID", input.BuyID);
            }

            //供应商编码
            if (!string.IsNullOrWhiteSpace(input.VendorCode))
            {
                sql += " AND bo.VendorCode = @VendorCode ";
                sqlParamrterBuilder.Add("VendorCode", input.VendorCode);
            }

            //供应商名称
            if (!string.IsNullOrWhiteSpace(input.VendorName))
            {
                sql += " AND bo.VendorName LIKE @VendorName ";
                sqlParamrterBuilder.Add("VendorName", '%' + input.VendorName + '%');
            }

            //创建用户
            if (!string.IsNullOrWhiteSpace(input.CreateUserName))
            {
                sql += " AND bo.CreateUserName LIKE @CreateUserName ";
                sqlParamrterBuilder.Add("CreateUserName", '%' + input.CreateUserName + '%');
            }

            //SKU 商品编码
            if (!string.IsNullOrWhiteSpace(input.SKU))
            {
                sql += " AND bod.SKU = @SKU ";
                sqlParamrterBuilder.Add("SKU", input.SKU);
            }

            //商品名称
            if (!string.IsNullOrWhiteSpace(input.ProductName))
            {
                sql += " AND bod.ProductName LIKE @ProductName ";
                sqlParamrterBuilder.Add("ProductName", '%' + input.ProductName + '%');
            }

            //商品条码
            if (!string.IsNullOrWhiteSpace(input.BarCode))
            {
                sql += " AND bod.BarCode LIKE @BarCode ";
                sqlParamrterBuilder.Add("BarCode", '%' + input.BarCode + '%');
            }

            //创建时间
            if (input.CreateTime1.HasValue)
            {
                sql += " AND bo.CreateTime >= @CreateTime1 ";
                sqlParamrterBuilder.Add("CreateTime1", input.CreateTime1);
            }
            if (input.CreateTime2.HasValue)
            {
                sql += " AND bo.CreateTime <= @CreateTime2 ";
                sqlParamrterBuilder.Add("CreateTime2", input.CreateTime2);
            }

            //过账时间
            if (input.PostingTime1.HasValue)
            {
                sql += " AND bo.PostingTime >= @PostingTime1 ";
                sqlParamrterBuilder.Add("PostingTime1", input.PostingTime1);
            }
            if (input.PostingTime2.HasValue)
            {
                sql += " AND bo.PostingTime <= @PostingTime2 ";
                sqlParamrterBuilder.Add("PostingTime2", input.PostingTime2);
            }

            //分类
            if (input.CategoryId1.HasValue)
            {
                sql += " AND bode.CategoryId1=@CategoryId1 ";
                sqlParamrterBuilder.Add("CategoryId1", input.CategoryId1.Value);
            }
            if (input.CategoryId2.HasValue)
            {
                sql += " AND bode.CategoryId2=@CategoryId2 ";
                sqlParamrterBuilder.Add("CategoryId2", input.CategoryId2.Value);
            }
            if (input.CategoryId3.HasValue)
            {
                sql += " AND bode.CategoryId3=@CategoryId3 ";
                sqlParamrterBuilder.Add("CategoryId3", input.CategoryId3.Value);
            }

            //账期时间
            if (input.SettDateStart.HasValue)
            {
                sql += " AND bo.Sett_Date >= @SettDateStart ";
                sqlParamrterBuilder.Add("SettDateStart", input.SettDateStart.Value);
            }

            if (input.SettDateEnd.HasValue)
            {
                sql += " AND bo.Sett_Date <= @SettDateEnd ";
                sqlParamrterBuilder.Add("SettDateEnd", input.SettDateEnd.Value);
            }

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);

            DataSet ds = helper.GetDataSet(sql, sqlParamrterBuilder.ToSqlParameters(), true);


            return ds.Tables[0];
        }
    }
}

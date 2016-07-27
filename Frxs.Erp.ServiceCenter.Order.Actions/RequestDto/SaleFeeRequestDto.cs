/*********************************************************
 * FRXS(ISC) chujl 2015-03-23
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// SaleFee.AddOrEditAction
    /// </summary>
    public class SaleFeeAddOrEditActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Required]
        public int WareHouseId { get; set; }

        /// <summary>
        /// 门店费用
        /// </summary>
        [Required]
        public SaleFeeRequestDto saleFee { get; set; }
        /// <summary>
        /// 门店费用明细
        /// </summary>
     
        public SaleFeeDetailsRequestDto saleFeeDetails { get; set; }

        /// <summary>
        /// 门店费用明细集合
        /// </summary>
           [Required]
        public IList<SaleFeeDetailsRequestDto> orderdetailsList { get; set; }
        /// <summary>
        /// 门店费用RequestDto（包括待处理）
        /// </summary>
        public class SaleFeeRequestDto
        {

            #region 模型
            /// <summary>
            /// 费用ID(SaleFee.FeeID)
            /// </summary>
            public string FeeID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WCode)
            /// </summary>
            public string WCode { get; set; }

            /// <summary>
            /// 仓库名称(Warehouse.WarehouseName)
            /// </summary>
            public string WName { get; set; }

            /// <summary>
            /// 仓库子机构ID
            /// </summary>
            public int SubWID { get; set; }

            /// <summary>
            /// 仓库子机构编号(Warehouse.WCode)
            /// </summary>
            public string SubWCode { get; set; }

            /// <summary>
            /// 仓库子机构名称(Warehouse.WName)
            /// </summary>
            public string SubWName { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已提交;2:已过帐;3:已结算)
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// 费用金额(小于0代表销售退回;大于0代表销售增加)(=sum(SaleFeeDetail.FeeAmt)
            /// </summary>
            public double TotalFeeAmt { get; set; }


            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreateTime { get; set; }

            /// <summary>
            /// 创建用户ID
            /// </summary>
            public int CreateUserID { get; set; }

            /// <summary>
            /// 创建用户名称
            /// </summary>
            public string CreateUserName { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime ModifyTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int ModifyUserID { get; set; }

            /// <summary>
            /// 最后修改用户名称
            /// </summary>
            public string ModifyUserName { get; set; }

            /// <summary>
            /// 费用日期
            /// </summary>
            public DateTime FeeDate { get; set; }
            #endregion


        }


        /// <summary>
        /// 门店费用明细RequestDetailsDto（包括待处理）
        /// </summary>
        public class SaleFeeDetailsRequestDto
        {
            #region 模型
            /// <summary>
            /// 主键ID(GUID)
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 费用ID(SaleFee.FeeID)
            /// </summary>
            public string FeeID { get; set; }

            /// <summary>
            /// 结算ID
            /// </summary>
            public string SettleID { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int ShopID { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            public string ShopCode { get; set; }

            /// <summary>
            /// 门店名称
            /// </summary>
            public string ShopName { get; set; }

            /// <summary>
            /// 费用项目ID(数据字典; SaleFeeCode)
            /// </summary>
            public int FeeCode { get; set; }

            /// <summary>
            /// 费用项目名称
            /// </summary>
            public string FeeName { get; set; }

            /// <summary>
            /// 费用原因
            /// </summary>
            public string Reason { get; set; }

            /// <summary>
            /// 费用订单编号(SaleOrders.OrderId)
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 费用金额(小于0代表销售退回;大于0代表销售增加)
            /// </summary>
            public double FeeAmt { get; set; }

            /// <summary>
            /// 结算完成时间
            /// </summary>
            public DateTime? SettleTime { get; set; }

            /// <summary>
            /// 序号(输入的序号,每一个单据从1开始)
            /// </summary>
            public int SerialNumber { get; set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime ModifyTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int ModifyUserID { get; set; }

            /// <summary>
            /// 最后修改用户名称
            /// </summary>
            public string ModifyUserName { get; set; }

            #endregion

        }
       

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    /// <summary>
    /// SaleFee.Del
    /// </summary>
    public class SaleFeeDelActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 消息ID 集合
        /// </summary>
        [Required]
        public string IDs { get; set; }

        
        /// <summary>
        /// 消息ID 集合
        /// </summary>
        [Required]
        public int WareHouseId { get; set; }
        
        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }
    }

    /// <summary>
    /// SaleFee.GetList
    /// </summary>
    public class SaleFeeGetListActionRequestDto : PageListRequestDto
    {
        #region 模型  用于查询检索
        /// <summary>
        /// 费用ID(SaleFee.FeeID)
        /// </summary>
        public string FeeID { get; set; }
        
        /// <summary>
        /// wid
        /// </summary>
        public int? SubWID { get; set; }

        /// <summary>
        /// 仓库ID  
        /// </summary>
        public int WarehouseID { get; set; }
        
        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WarehouseName)
        /// </summary>
        public string WName { get; set; }


        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;3:已结算)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 费用金额(小于0代表销售退回;大于0代表销售增加)(=sum(SaleFeeDetail.FeeAmt)
        /// </summary>
        public double? TotalFeeAmt { get; set; } 
        

        /// <summary>
        /// 确认人员
        /// </summary>
        public string ConfUserName { get; set; }

       
        /// <summary>
        /// 费用日期
        /// </summary>
        public DateTime? FeeDate { get; set; } 

        #endregion

        #region 扩展查询 
          
        /// <summary>
        /// 门店编码
        /// </summary>
        public string ShopCode { get; set; }


        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }



        /// <summary>
        /// 费用日期（开始）
        /// </summary>
        public DateTime? StartFeeDate { get; set; }


        /// <summary>
        /// 费用日期（结束）
        /// </summary>
        public DateTime? EndFeeDate { get; set; }




        #endregion

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }


    /// <summary>
    /// SaleFeeDetails.GetList 用于查询 
    /// </summary>
    public class SaleFeeDetailsGetListActionRequestDto : PageListRequestDto
    {


        #region 模型 

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 费用ID(SaleFee.FeeID)
        /// </summary>
        public string FeeID { get; set; }

        /// <summary>
        /// 费用订单编号(SaleOrders.OrderId)
        /// </summary>
        public string OrderId { get; set; }



        #endregion

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }

    /// <summary>
    /// SaleFee.ChangeStatus
    /// </summary>
    public class SaleFeeChangeStatusActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// ID 批量
        /// </summary>
        [Required]
        public string FeeIDs { get; set; }

        /// <summary>
        /// 状态状态(0:未提交;1:已提交;2:已过帐;3:已结算)
        /// </summary>
        [Required]
        public int Status { get; set; }

      /// <summary>
      /// 
      /// </summary>
        [Required]
        public int WareHouseId { get; set; }



        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }


    /// <summary>
    /// SaleFee.GetModel
    /// </summary>
    public class SaleFeeGetModelActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 消息ID
        /// </summary>
        [Required]
        public string FeeID { get; set; }

        /// <summary>
        /// wid
        /// </summary>
        [Required]
        public int WareHouseId { get; set; }


        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }

    /// <summary>
    /// SaleFeeDetails.GetModel
    /// </summary>
    public class SaleFeeDetailsGetModelActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 消息ID
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// 校验上送参数是否正确
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            return base.Valid();
        }

    }
}

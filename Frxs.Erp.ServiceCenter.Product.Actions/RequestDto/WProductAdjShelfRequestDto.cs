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
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// WProductAdjShelf.AddOrEditAction
    /// </summary>
    public class WProductAdjShelfAddOrEditActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int ? WareHouseId { get; set; }
        /// <summary>
        /// 货位调整
        /// </summary>
        [Required]
        public WProductAdjShelfRequestDto WProductAdjShelf { get; set; }
        /// <summary>
        /// 货位调整明细
        /// </summary>
     
        public WProductAdjShelfDetailsRequestDto WProductAdjShelfDetails { get; set; }

        /// <summary>
        /// 货位调整明细集合
        /// </summary>
           [Required]
        public IList<WProductAdjShelfDetailsRequestDto> orderdetailsList { get; set; }
        /// <summary>
        /// 货位调整RequestDto
        /// </summary>
        public class WProductAdjShelfRequestDto
        {
            #region 模型
            /// <summary>
            /// 调整ID
            /// </summary>
            public string AdjID { get; set; }

            /// <summary>
            /// 仓库ID(WarehouseID)
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 状态(0:未提交;1:已确认;2:已过帐;)
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// Remark
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 调整类型(0:货架[固定])
            /// </summary>
            public int AdjType { get; set; }

            
            #endregion

        
        }


        /// <summary>
        /// 货位调整明细RequestDetailsDto（）
        /// </summary>
        public class WProductAdjShelfDetailsRequestDto
        {


            #region 模型
            /// <summary>
            /// 主键ID
            /// </summary>
            public long ID { get; set; }

            /// <summary>
            /// 调整ID(WProductAdjPrice.AdjID)
            /// </summary>
            public string AdjID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID 二级)
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 仓库商品ID(WProducts.WProductID)
            /// </summary>
            public int WProductID { get; set; }

            /// <summary>
            /// 商品ID(product.ProductID)
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 原货架ID
            /// </summary>
            public int OldShelfID { get; set; }

            /// <summary>
            /// 原货架编号
            /// </summary>
            public string OldShelfCode { get; set; }

            /// <summary>
            /// 新货架ID
            /// </summary>
            public int ShelfID { get; set; }

            /// <summary>
            /// 新货架编号
            /// </summary>
            public string ShelfCode { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

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
    /// WProductAdjShelf.Del
    /// </summary>
    public class WProductAdjShelfDelActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 消息ID 集合
        /// </summary>
        [Required]
        public IList<string> AdjIDs { get; set; }

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
    /// WProductAdjShelf.GetList
    /// </summary>
    public class WProductAdjShelfGetListActionRequestDto : PageListRequestDto
    {
        #region 模型  用于查询检索

        /// <summary>
        ///  单据
        /// </summary>
        public string AdjID { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [Required]
        public int? WID { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;)
        /// </summary>
        public int? Status { get; set; }


        #endregion

        #region 扩展查询 
          
        /// <summary>
        /// 日期（开始）
        /// </summary>
        public DateTime? StartDate { get; set; }


        /// <summary>
        /// 日期（结束）
        /// </summary>
        public DateTime? EndDate { get; set; }




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
    /// WProductAdjShelfDetails.GetList 用于查询 
    /// </summary>
    public class WProductAdjShelfDetailsGetListActionRequestDto : PageListRequestDto
    {


        #region 模型 

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 单据ID(WProductAdjShelf.AdjID)
        /// </summary>
        public string AdjID { get; set; }



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
    /// WProductAdjShelf.ChangeStatus
    /// </summary>
    public class WProductAdjShelfChangeStatusActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// ID 批量
        /// </summary>
        [Required]
        public IList<string> AdjIDs { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        [Required]
        public int Status { get; set; }

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
    /// WProductAdjShelf.GetModel
    /// </summary>
    public class WProductAdjShelfGetModelActionRequestDto : RequestDtoBase
    {
        
        /// <summary>
        /// 货位调整单据ID
        /// </summary>
        [Required]
        public string AdjId { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

       
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
    /// WProductAdjShelfDetails.GetModel
    /// </summary>
    public class WProductAdjShelfDetailsGetModelActionRequestDto : RequestDtoBase
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

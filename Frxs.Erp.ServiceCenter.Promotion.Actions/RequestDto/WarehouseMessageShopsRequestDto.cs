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

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    /// <summary>
    /// WarehouseMessageShops.AddOrEditAction
    /// </summary>
    public class WarehouseMessageShopsAddOrEditActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 新增仓库消息
        /// </summary>
        [Required]
        public WarehouseMessageShopsRequestDto order { get; set; }


        /// <summary>
        /// 仓库消息RequestDto
        /// </summary>
        public class WarehouseMessageShopsRequestDto
        {

            #region 模型
            /// <summary>
            /// 主键ID
            /// </summary>
            public int ID { get; set; }

            /// <summary>
            /// 消息主表ID(WarehouseMessage.ID)
            /// </summary>
            public int WarehouseMessageID { get; set; }

            /// <summary>
            /// 仓库ID(Warehouse.WID 二级)
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 门店群组ID(ShopGroup.GroupID)
            /// </summary>
            public int GroupID { get; set; }

            /// <summary>
            /// 门店群组名称
            /// </summary>
            public string GroupName { get; set; }
            /// <summary>
            /// 门店群组编码
            /// </summary>
            public string GroupCode { get; set; }

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

            #endregion

        }

        /// <summary>
        /// 
        /// </summary>
        public override void BeforeValid()
        {
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
    /// WarehouseMessageShops.GetList
    /// </summary>
    public class WarehouseMessageShopsGetListActionRequestDto : PageListRequestDto
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 消息主表ID(WarehouseMessage.ID)
        /// </summary>
        public int? WarehouseMessageID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
       [Required]
        public int WarehouseId { get; set; }

        /// <summary>
        /// 门店群组ID(ShopGroup.GroupID)
        /// </summary>
        public int? GroupID { get; set; }

        /// <summary>
        /// 门店群组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

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
    /// WarehouseMessageShops.GetModel
    /// </summary>
    public class WarehouseMessageShopsGetModelActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 消息ID
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void BeforeValid()
        {
            base.BeforeValid();
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
}

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
using Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto;
using System.Collections;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    /// <summary>
    /// WarehouseMessage.AddOrEditAction
    /// </summary>
    public class WarehouseMessageAddOrEditActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WareHouseId { get; set; }

        /// <summary>
        /// 新增仓库消息
        /// </summary>
        [Required]
        public WarehouseMessageRequestDto order { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public IList<WarehouseMessageShopsRequestDto> orderdetailsList { get; set; }

        /// <summary>
        /// 仓库消息RequestDto
        /// </summary>
        public class WarehouseMessageRequestDto
        {
           
            /// <summary>
            /// 主键ID
            /// </summary>
            public int? ID { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WID)
            /// </summary>
            public int? WID { get; set; }
          

            /// <summary>
            /// 消息头
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 消息类型(0：重要消息;1:促销;2:其他)
            /// </summary>
            public int? MessageType { get; set; }

            /// <summary>
            /// 消息类型(0:全部门店;1:指定群组；等于2时，表示后台仓库调用)
            /// </summary>
            public int? RangType { get; set; }

            /// <summary>
            /// 发布时间开始（yyyy-MM-dd hh:mm:ss)
            /// </summary>
            public DateTime? BeginTime { get; set; }

            /// <summary>
            /// 发布时间结束（yyyy-MM-dd hh:mm:ss)
            /// </summary>
            public DateTime? EndTime { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 状态(0:未发布;1:已发布;2:已停止/已删除)
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// 确认时间
            /// </summary>
            public DateTime? ConfTime { get; set; }

            /// <summary>
            /// 确认人员ID
            /// </summary>
            public int? ConfUserID { get; set; }

            /// <summary>
            /// 确认人员名称
            /// </summary>
            public string ConfUserName { get; set; }

            /// <summary>
            /// 置顶显示
            /// </summary>
            public int? IsFirst { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime? CreateTime { get; set; }

            /// <summary>
            /// 创建用户 ID
            /// </summary>
            public int? CreateUserID { get; set; }

            /// <summary>
            /// 创建用户名称
            /// </summary>
            public string CreateUserName { get; set; }

            /// <summary>
            /// 修改时间
            /// </summary>
            public DateTime? ModityTime { get; set; }

            /// <summary>
            /// 最后修改用户ID
            /// </summary>
            public int? ModityUserID { get; set; }

            /// <summary>
            /// 最后修改用记名称
            /// </summary>
            public string ModityUserName { get; set; }

        }


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
            [Required(ErrorMessage = "{0}不能为空")]
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
    /// WarehouseMessage.Del
    /// </summary>
    public class WarehouseMessageDelActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 消息ID 集合
        /// </summary>
        [Required]
        public string IDs { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
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
    /// WarehouseMessage.GetList
    /// </summary>
    public class WarehouseMessageGetListActionRequestDto : PageListRequestDto
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ? ID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WareHouseId { get; set; }

        /// <summary>
        /// 消息头
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息类型(0：重要消息;1:促销;2:其他)
        /// </summary>
        public int ? MessageType { get; set; }

        /// <summary>
        /// 消息类型(0:全部门店;1:指定群组)
        /// 消息类型(0:全部门店;1:指定群组;2:全部)        
        /// </summary>
        public int ? RangType { get; set; }

        /// <summary>
        /// 发布时间开始（yyyy-MM-dd hh:mm:ss)
        /// </summary>
        public DateTime ? BeginTime { get; set; }

        /// <summary>
        /// 发布时间结束（yyyy-MM-dd hh:mm:ss)
        /// </summary>
        public DateTime ? EndTime { get; set; }

        /// <summary>
        /// 状态(0:未发布;1:已发布;2:已停止/已删除)
        /// </summary>
        public int ? Status { get; set; }

        /// <summary>
        /// 确认人员名称
        /// </summary>
        public string ConfUserName { get; set; }

        /// <summary>
        /// 置顶显示
        /// </summary>
        public int ? IsFirst { get; set; }


        #region 扩展字段
      

        /// <summary>
        /// 门店群组ID
        /// </summary>
        public string GroupIDList { get; set; }

        /// <summary>
        /// 查询时间
        /// </summary>
        public int? SearchTime { get; set; }
             

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
    /// WarehouseMessage.ChangeStatus
    /// </summary>
    public class WarehouseMessageChangeStatusActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// ID 批量
        /// </summary>
        [Required]
        public string IDs { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WareHouseId { get; set; }

        /// <summary>
        /// 状态(0:未发布;1:已发布;2:已停止/已删除)
        /// </summary>
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
    /// WarehouseMessage.GetModel
    /// </summary>
    public class WarehouseMessageGetModelActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 消息ID
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int WareHouseId { get; set; }

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

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
    public class WAdvertisementRequestDto
    {
        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public int AdvertisementID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>

        public int WID { get; set; }

        /// <summary>
        /// 广告位置（1、轮播广告，2、底部广告，3、橱窗）
        /// </summary>

        public int AdvertisementPosition { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string AdvertisementName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>

        public string ImagesSrc { get; set; }

        /// <summary>
        /// 选中后的图标
        /// </summary>

        public string SelectImagesSrc { get; set; }

        /// <summary>
        /// 广告类型（1、促销，2、分类，3、商品）注：橱窗与此字段无关
        /// </summary>
        public int AdvertisementType { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLocked { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>

        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>

        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用记名称
        /// </summary>
        public string ModityUserName { get; set; }
        #endregion
    }
    
    /// <summary>
    /// WAdvertisement.AddOrEditAction
    /// </summary>
    public class WAdvertisementAddOrEditActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 新增橱窗推荐
        /// </summary>
        [Required]
        public WAdvertisementRequestDto order { get; set; }

        /// <summary>
        /// 橱窗推荐所含商品
        /// </summary>
        [Required]
        public List<WAdvertisementProductRequestDto> advertisementProduct { get; set; }

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
    /// WAdvertisement.Del
    /// </summary>
    public class WAdvertisementDelActionRequestDto : RequestDtoBase
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
    /// WAdvertisement.GetList
    /// </summary>
    public class WAdvertisementGetListActionRequestDto : PageListRequestDto
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public int AdvertisementID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>

        public int WID { get; set; }

        /// <summary>
        /// 广告位置（1、轮播广告，2、底部广告，3、橱窗）
        /// </summary>

        public int AdvertisementPosition { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string AdvertisementName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>

        public string ImagesSrc { get; set; }

        /// <summary>
        /// 选中后的图标
        /// </summary>

        public string SelectImagesSrc { get; set; }

        /// <summary>
        /// 广告类型（1、促销，2、分类，3、商品）注：橱窗与此字段无关
        /// </summary>
        public int AdvertisementType { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLocked { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>

        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>

        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用记名称
        /// </summary>
        public string ModityUserName { get; set; }

        /// <summary>
        /// 生效时间查询条件
        /// </summary>
        public string EffectiveTime { get; set; }

        #endregion


        ///// <summary>
        ///// 校验上送参数是否正确
        ///// </summary>
        ///// <returns></returns>
        //public override IEnumerable<RequestDtoValidatorResultError> Valid()
        //{
        //    if (AdvertisementID <= 0)
        //    {
        //        yield return new RequestDtoValidatorResultError("ID");
        //    }
        //}

    }

    /// <summary>
    /// WAdvertisement.ChangeStatus
    /// </summary>
    public class WAdvertisementChangeStatusActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// ID 批量
        /// </summary>
        [Required]
        public string IDs { get; set; }

        /// <summary>
        /// 状态(0:未发布;1:已发布;2:已停止/已删除)
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
    /// WAdvertisement.GetModel
    /// </summary>
    public class WAdvertisementGetModelActionRequestDto : RequestDtoBase
    {

        /// <summary>
        /// 消息ID
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
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
}

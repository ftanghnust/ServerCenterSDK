
/*****************************
* Author:TangFan
*
* Date:2016-04-27
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.ID.Model
{
    /// <summary>
    /// XSOperatorLog实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class XSOperatorLog
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [DataMember]
        [DisplayName("IP地址")]
        public string IPAddress { get; set; }

        /// <summary>
        /// 仓库ID(为0时，代表为总部)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(为0时，代表为总部)")]
        public int? WID { get; set; }

        /// <summary>
        /// 模块编号(找不到时; 填0:参见SysMenu.MenuID)
        /// </summary>
        [DataMember]
        [DisplayName("模块编号(找不到时; 填0:参见SysMenu.MenuID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int MenuID { get; set; }

        /// <summary>
        /// 模块名称(找不到时:填其他;参见SysMenu.MenuName
        /// </summary>
        [DataMember]
        [DisplayName("模块名称(找不到时:填其他;参见SysMenu.MenuName")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string MenuName { get; set; }

        /// <summary>
        /// 动作:即按下单据表头按钮的名称或基本资料的按钮名称(登录;退出;添加;编辑;删除;确认;反确认;过帐;结算;打印;停用;立即生效;....)
        /// </summary>
        [DataMember]
        [DisplayName("动作:即按下单据表头按钮的名称或基本资料的按钮名称(登录;退出;添加;编辑;删除;确认;反确认;过帐;结算;打印;停用;立即生效;....)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Action { get; set; }

        /// <summary>
        /// 对[1050001,10006]完成了过帐;对[00891]商品进行了删除;
        /// </summary>
        [DataMember]
        [DisplayName("对[1050001,10006]完成了过帐;对[00891]商品进行了删除;")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Remark { get; set; }

        /// <summary>
        /// 操作用户ID
        /// </summary>
        [DataMember]
        [DisplayName("操作用户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OperatorID { get; set; }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        [DataMember]
        [DisplayName("操作用户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        #endregion
    }

    public partial class XSOperatorLog
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public enum MenuIDEnum
        {
            /// <summary>
            /// 基本资料
            /// </summary>
            [Description("基本资料")]
            WMS_1 = 5201,

            /// <summary>
            /// 商品管理
            /// </summary>
            [Description("商品管理")]
            WMS_2 = 5202,

            /// <summary>
            /// 订单管理
            /// </summary>
            [Description("订单管理")]
            WMS_3 = 5203,

            /// <summary>
            /// 促销管理
            /// </summary>
            [Description("促销管理")]
            WMS_4 = 5204,

            /// <summary>
            /// 采购管理
            /// </summary>
            [Description("采购管理")]
            WMS_5 = 5205,

            /// <summary>
            /// 财务管理
            /// </summary>
            [Description("财务管理")]
            WMS_6 = 5206,

            /// <summary>
            /// 库存盘点
            /// </summary>
            [Description("库存盘点")]
            WMS_7 = 5207,

            /// <summary>
            /// 统计报表
            /// </summary>
            [Description("统计报表")]
            WMS_18 = 5218,

            /// <summary>
            /// 仓库基本资料
            /// </summary>
            [Description("仓库基本资料")]
            WMS_1A = 520110,

            /// <summary>
            /// 门店管理
            /// </summary>
            [Description("门店管理")]
            WMS_1B = 520112,

            /// <summary>
            /// 送货线路管理
            /// </summary>
            [Description("送货线路管理")]
            WMS_1C = 520113,

            /// <summary>
            /// 门店分组管理
            /// </summary>
            [Description("门店分组管理")]
            WMS_1D = 520114,

            /// <summary>
            /// 货区管理
            /// </summary>
            [Description("货区管理")]
            WMS_1E = 520115,

            /// <summary>
            /// 货位管理
            /// </summary>
            [Description("货位管理")]
            WMS_1F = 520116,

            /// <summary>
            /// 帐户管理
            /// </summary>
            [Description("帐户管理")]
            WMS_1G = 520117,

            /// <summary>
            /// 拣货员管理
            /// </summary>
            [Description("拣货员管理")]
            WMS_1H = 520118,

            /// <summary>
            /// 业务参数设定
            /// </summary>
            [Description("业务参数设定")]
            WMS_1Z = 520119,

            /// <summary>
            /// 商品加入
            /// </summary>
            [Description("商品加入")]
            WMS_2A = 520221,

            /// <summary>
            /// 供应商管理
            /// </summary>
            [Description("供应商管理")]
            WMS_2B = 520222,

            /// <summary>
            /// 商品管理
            /// </summary>
            [Description("商品管理")]
            WMS_2C = 520223,

            /// <summary>
            /// 配送价格调整单
            /// </summary>
            [Description("配送价格调整单")]
            WMS_2D = 520224,

            /// <summary>
            /// 进货价格调整单
            /// </summary>
            [Description("进货价格调整单")]
            WMS_2E = 520225,

            /// <summary>
            /// 费率积分调整单
            /// </summary>
            [Description("费率积分调整单")]
            WMS_2F = 520226,

            /// <summary>
            /// 门店平台费率调整单
            /// </summary>
            [Description("门店平台费率调整单")]
            WMS_2G = 520227,

            /// <summary>
            /// 门店商品限购单
            /// </summary>
            [Description("门店商品限购单")]
            WMS_2H = 520228,

            /// <summary>
            /// 商品货位调整单
            /// </summary>
            [Description("商品货位调整单")]
            WMS_2I = 520229,

            /// <summary>
            /// 商品采购员设置
            /// </summary>
            [Description("商品采购员设置")]
            WMS_2J = 520230,

            /// <summary>
            /// 订货平台预订单
            /// </summary>
            [Description("订货平台预订单")]
            WMS_3A = 520311,

            /// <summary>
            /// 销售订单
            /// </summary>
            [Description("销售订单")]
            WMS_3B = 520312,

            /// <summary>
            /// 商品批量推荐
            /// </summary>
            [Description("商品批量推荐")]
            WMS_3C = 520313,

            /// <summary>
            /// 待装区管理
            /// </summary>
            [Description("待装区管理")]
            WMS_3D = 520314,

            /// <summary>
            /// 门店排单
            /// </summary>
            [Description("门店排单")]
            WMS_3E = 520315,

            /// <summary>
            /// 发货顺序调整
            /// </summary>
            [Description("发货顺序调整")]
            WMS_3F = 520316,

            /// <summary>
            /// 销售退货单
            /// </summary>
            [Description("销售退货单")]
            WMS_3G = 520317,

            /// <summary>
            /// 商品加入
            /// </summary>
            [Description("橱窗推荐")]
            WMS_4A = 520411,

            /// <summary>
            /// 信息管理
            /// </summary>
            [Description("信息管理")]
            WMS_4B = 520412,

            /// <summary>
            /// 门店积分促销单
            /// </summary>
            [Description("门店积分促销单")]
            WMS_4C = 520413,

            /// <summary>
            /// 采购收货单
            /// </summary>
            [Description("采购收货单")]
            WMS_5B = 520511,

            /// <summary>
            /// 采购退货单
            /// </summary>
            [Description("采购退货单")]
            WMS_5C = 520512,

            /// <summary>
            /// 返配申请单
            /// </summary>
            [Description("返配申请单")]
            WMS_5D = 520513,

            /// <summary>
            /// 补货申请单
            /// </summary>
            [Description("补货申请单")]
            WMS_5E = 520514,

            /// <summary>
            /// 门店结算单
            /// </summary>
            [Description("门店结算单")]
            WMS_6A = 520611,

            /// <summary>
            /// 门店费用单
            /// </summary>
            [Description("门店费用单")]
            WMS_6B = 520612,

            /// <summary>
            /// 盘点计划
            /// </summary>
            [Description("盘点计划")]
            WMS_7A = 520711,

            /// <summary>
            /// 盘点单
            /// </summary>
            [Description("盘点单")]
            WMS_7B = 520712,

            /// <summary>
            /// 漏盘商品检查
            /// </summary>
            [Description("漏盘商品检查")]
            WMS_7C = 520713,

            /// <summary>
            /// 盘盈盘亏报表
            /// </summary>
            [Description("盘盈盘亏报表")]
            WMS_7H = 520714,

            /// <summary>
            /// 盘点单确认
            /// </summary>
            [Description("盘点单确认")]
            WMS_7D = 520715,

            /// <summary>
            /// 盘盈单
            /// </summary>
            [Description("盘盈单")]
            WMS_7E = 520716,

            /// <summary>
            /// 盘亏单
            /// </summary>
            [Description("盘亏单")]
            WMS_7F = 520717,

            /// <summary>
            /// 采购商品汇总
            /// </summary>
            [Description("采购商品汇总")]
            WMS_18A = 521811,

            /// <summary>
            /// 采购入库采购退货汇总
            /// </summary>
            [Description("采购入库采购退货汇总")]
            WMS_18B = 521812,

            /// <summary>
            /// 采购入库采购退货明细
            /// </summary>
            [Description("采购入库采购退货明细")]
            WMS_18C = 521813,

            /// <summary>
            /// 业务分析报表
            /// </summary>
            [Description("业务分析报表")]
            WMS_18D = 521814,

            /// <summary>
            /// 客户销售情况汇总表
            /// </summary>
            [Description("客户销售情况汇总表")]
            WMS_18E = 521815,

            /// <summary>
            /// 库存状态查询
            /// </summary>
            [Description("库存状态查询")]
            WMS_18F = 521816,

            /// <summary>
            /// 商品明细帐
            /// </summary>
            [Description("商品明细帐")]
            WMS_18G = 521817,

            /// <summary>
            /// 批发价调整金额差异
            /// </summary>
            [Description("批发价调整金额差异")]
            WMS_18H = 521818,

            /// <summary>
            /// 门店费用单
            /// </summary>
            [Description("门店费用单")]
            WMS_18I = 521819,

            /// <summary>
            /// 收款单汇总
            /// </summary>
            [Description("收款单汇总")]
            WMS_18J = 521820,

            /// <summary>
            /// 基本设定
            /// </summary>
            [Description("基本设定")]
            MS_1 = 5111,

            /// <summary>
            /// 商品资料
            /// </summary>
            [Description("商品资料")]
            MS_2 = 5112,

            //[Description("财务")]
            //MS_ = 5113,

            /// <summary>
            /// 仓库管理
            /// </summary>
            [Description("仓库管理")]
            MS_1A = 511101,

            /// <summary>
            /// 门店管理
            /// </summary>
            [Description("门店管理")]
            MS_1B = 511102,

            /// <summary>
            /// 供应商管理
            /// </summary>
            [Description("供应商管理")]
            MS_1C = 511103,

            /// <summary>
            /// 基本分类
            /// </summary>
            [Description("基本分类")]
            MS_2A = 511201,

            /// <summary>
            /// 运营分类
            /// </summary>
            [Description("运营分类")]
            MS_2B = 511202,

            /// <summary>
            /// 商品添加
            /// </summary>
            [Description("商品添加")]
            MS_2C = 511203,

            /// <summary>
            /// 品牌管理
            /// </summary>
            [Description("品牌管理")]
            MS_2E = 511204,

            /// <summary>
            /// 商品管理
            /// </summary>
            [Description("商品管理")]
            MS_2D = 511205,

            /// <summary>
            /// 商品规格
            /// </summary>
            [Description("商品规格")]
            MS_2F = 511206,

            /// <summary>
            /// 供应商类型
            /// </summary>
            [Description("供应商类型")]
            MS_2H = 511207,

            //[Description("门店结算单")]
            //MS_ = 511301
        }

    }

    public class XSOperatorLogMenu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
    }
}
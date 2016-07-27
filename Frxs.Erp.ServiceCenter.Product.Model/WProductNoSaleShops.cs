
/*****************************
* Author:CR
*
* Date:2016-03-31
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品限购门店明细表WProductNoSaleShops实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductNoSaleShops : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 限购ID(WProductNoSale.NoSaleID)
        /// </summary>
        [DataMember]
        [DisplayName("限购ID(WProductNoSale.NoSaleID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string NoSaleID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID 二级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店群组ID(ShopGroup.GroupID)
        /// </summary>
        [DataMember]
        [DisplayName("门店群组ID(ShopGroup.GroupID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GroupID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion
    }

    public partial class WProductNoSaleShops : BaseModel
    {
        /// <summary>
        /// 分组名称 取自门店分组表 仅用于前台显示关联的数据
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }
        
        /// <summary>
        /// 分组编号 取自门店分组表 仅用于前台显示关联的数据
        /// </summary>
        [DataMember]
        public string GroupCode { get; set; }

        /// <summary>
        /// 分组备注 取自门店分组表 仅用于前台显示关联的数据
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 门店分组下的门店个数 取自门店分组详情表 仅用于前台显示关联的数据
        /// </summary>
        [DataMember]
        public int ShopNum { get; set; }
    }
}

/*****************************
* Author:CR
*
* Date:2016-03-17
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库用户拣货区表WarehouseEmpShelf实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseEmpShelf : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        [DisplayName("主键")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        [DisplayName("用户编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int EmpID { get; set; }

        /// <summary>
        /// 货区编号(ShelfArea.ShelfAreaID)
        /// </summary>
        [DataMember]
        [DisplayName("货区编号(ShelfArea.ShelfAreaID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 货位编号(Shelf.ShelfID)
        /// </summary>
        [DataMember]
        [DisplayName("货位编号(Shelf.ShelfID)")]

        public int ShelfID { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]       
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>        
        [DataMember]
        [DisplayName("货位编号")]
        public string ShelfCode { get; set; }

        #endregion
    }
}
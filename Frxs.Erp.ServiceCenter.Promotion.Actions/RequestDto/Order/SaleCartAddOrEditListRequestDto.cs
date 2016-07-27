using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class SaleCartAddOrEditListRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 购物车列表
        /// </summary>
        public IList<SaleCartAddOrEditRequestDto> CartList { get; set; }

        /// <summary>
        /// 操作标志 0：新增 1:修改
        /// </summary>
        public int Flag { get; set; }
    }
    public class SaleCartAddOrEditRequestDto : RequestDtoParent
     {
         #region 模型
         /// <summary>
         /// 主键ID
         /// </summary>
         public long ID { get; set; }

         /// <summary>
         /// 仓库ID(Warehouse.WID)
         /// </summary>
         public int WID { get; set; }

         /// <summary>
         /// 下单门店ID
         /// </summary>
         public int ShopID { get; set; }

         /// <summary>
         /// 下单门店人员ID
         /// </summary>
         public int XSUserID { get; set; }

         /// <summary>
         /// 商品ID
         /// </summary>
         public int ProductID { get; set; }

         /// <summary>
         /// 预订数量
         /// </summary>
         public decimal PreQty { get; set; }

         /// <summary>
         /// 创建时间
         /// </summary>
         public DateTime CreateTime { get; set; }

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
         /// 备注信息
         /// </summary>
         public string Remark { get; set; }

         #endregion
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品单位集合
    /// </summary>
    public class ProductsUnitRequestDto : RequestDtoBase
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ProductsUnitID { get; set; }

        /// <summary>
        /// 即为：Product.ProductID
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// 单位(同一个商品单位不能重复)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 包装数
        /// </summary>
        public decimal PackingQty { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 是否为库存单位(0:不是;1:是;只有一条)
        /// </summary>
        public int IsUnit { get; set; }

        /// <summary>
        /// 是否为配送单位(0:不是;1:是)
        /// </summary>
        public int IsSaleUnit { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion


    }
}

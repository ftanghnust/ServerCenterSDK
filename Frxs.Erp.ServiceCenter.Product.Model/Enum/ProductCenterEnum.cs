using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 商品中心枚举类
    /// </summary>
    public class ProductCenterEnum
    {
        /// <summary>
        /// 返回结果信息
        /// </summary>
        public enum ReturnResultInfo
        {
            /// <summary>
            /// 数据库不存在记录 -1
            /// </summary>
            NoExist = -1,
            /// <summary>
            /// 存在其他数据引用 -2
            /// </summary>
            ExistReference = -2,

            /// <summary>
            /// 数据库中存在相同名称的记录 -100
            /// </summary>
            ExistSameName = -100
        }



        /// <summary>
        /// 母商品表是否为母商品(0:不是;1:是)，IsBaseProductId必填
        /// </summary>
        public enum BaseProductIsBaseProductId
        {
            /// <summary>
            /// 是否为母商品。(0:不是;1:是)
            /// </summary>
            不是 = 0,
            /// <summary>
            /// 是否为母商品。(0:不是;1:是)
            /// </summary>
            是 = 1
        }


        /// <summary>
        /// 母商品表 是否为多规格属性商品(0:不是;1:是)
        /// </summary>
        public enum BaseProductIsMutiAttribute
        {
            /// <summary>
            /// 是否为多规格属性商品(0:不是;1:是)
            /// </summary>
            不是 = 0,
            /// <summary>
            /// 是否为多规格属性商品(0:不是;1:是)
            /// </summary>
            是 = 1
        }





        /// <summary>
        /// 母商品表是否为第三方商品(0:不是;1:是 B2B固定为0)
        /// </summary>
        public enum BaseProductIsVendor
        {
            /// <summary>
            /// 是否为母商品。(0:不是;1:是)
            /// </summary>
            不是 = 0,
            /// <summary>
            /// 是否为母商品。(0:不是;1:是)
            /// </summary>
            是 = 1
        }


        /// <summary>
        /// 母商品表是否删除 删除状态(0:未删除;1:已删除;2:子商品另外挂到其它商品)
        /// </summary>
        public enum BaseProductIsDeleted
        {
            /// <summary>
            /// 0:未删除
            /// </summary>
            未删除 = 0,
            /// <summary>
            /// 1:已删除
            /// </summary>
            已删除 = 1,
            /// <summary>
            /// 子商品另外挂到其它商品
            /// </summary>
            子商品另外挂到其它商品 = 2
        }





        /// <summary>
        /// 删除状态(0:未删除;1:已删除)
        /// </summary>
        public enum ProductIsDeleted
        {
            /// <summary>
            /// 0:未删除
            /// </summary>
            未删除 = 0,
            /// <summary>
            /// 1:已删除
            /// </summary>
            已删除 = 1
        }

        /// <summary>
        /// 总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售])
        /// </summary>
        public enum ProductStatus
        {
            /// <summary>
            /// 0:正常
            /// </summary>
            正常 = 0,
            /// <summary>
            /// 1:冻结[冻结的商品不再采购,不能再销售])
            /// </summary>
            冻结 = 1,
            /// <summary>
            /// 淘汰[淘汰的商品不再采购,不能再销售]
            /// </summary>
            淘汰 = 2
        }

        /// <summary>
        /// 商品单位 是否为库存单位(0:不是;1:是;只有一条)
        /// </summary>
        public enum ProductsUnitIsUnit
        {
            /// <summary>
            /// 是否为库存单位(0:不是;1:是;只有一条)
            /// </summary>
            不是 = 0,
            /// <summary>
            /// 是否为库存单位(0:不是;1:是;只有一条)
            /// </summary>
            是 = 1
        }


        /// <summary>
        /// 商品单位 是否为配送单位(0:不是;1:是)
        /// </summary>
        public enum ProductsUnitIsSaleUnit
        {
            /// <summary>
            /// 是否为配送单位(0:不是;1:是)
            /// </summary>
            不是 = 0,
            /// <summary>
            /// 是否为配送单位(0:不是;1:是)
            /// </summary>
            是 = 1
        }



    }
}

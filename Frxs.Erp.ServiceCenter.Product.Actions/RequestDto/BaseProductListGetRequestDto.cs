using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 通过子商品编号查询 母商品信息 输入参数
    /// </summary>
    public class BaseProductListGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 母商品名称
        /// </summary>
        public string BaseProductName { get; set; }

        /// <summary>
        ///ERP编码
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 是否匹配运营分类
        /// </summary>
        public bool CheckShopCategory { get; set; }

        /// <summary>
        /// 是否匹配规格属性
        /// </summary>
        public bool CheckAttribute { get; set; }


        /// <summary>
        /// 当前页(默认1)
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 分页大小（默认10）
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 验证前赋值
        /// </summary>
        public override void BeforeValid()
        {
            
        }

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "没有指定子商品编号");
            }
        }
    }
}

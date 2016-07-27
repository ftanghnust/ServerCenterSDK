﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 产品关键字查询功能输入参数
    /// </summary>
    public class ProductsKeyWordGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "没有指定商品编号");
            }
        }
    }
}

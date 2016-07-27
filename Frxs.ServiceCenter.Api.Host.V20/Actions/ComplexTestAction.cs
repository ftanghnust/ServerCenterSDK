/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/2/26 14:42:41
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.ServiceCenter.Api.Host.Actions
{
    /// <summary>
    /// 演示接口拦截器
    /// </summary>
    public class A : ActionFilterBaseAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutingContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            // actionExecutingContext.RequestContext.HttpContext.Response.Write(actionExecutingContext.RequestDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //  actionExecutedContext.Result.Data
        }
    }

    /// <summary>
    /// 复杂类型参数测试请求接口，仅仅是测试
    /// </summary>
    [ActionName("Complex.Test")]
    //[ActionResultCache(1)]
    [A(Order = 1)]
    // [HttpMethod(Core.HttpMethod.POST)]
    public class ComplexTestAction : ActionBase<ComplexTestAction.TestRequestDto, ActionResultPagerData<ComplexTestAction.Order>> //分页ResponseDto类，可以直接使用：ActionResultPagerData<T> 预定义好的对象
    {
        /// <summary>
        /// 类说明与属性说明还是需要详细点滴，接口框架需要这些信息输出SDK开发文档
        /// </summary>
        public class Order
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 收货地址
            /// </summary>
            public Address Address { get; set; }

            /// <summary>
            /// 实际支付金额
            /// </summary>
            public decimal Payment { get; set; }

            /// <summary>
            /// 优惠总金额
            /// </summary>
            public decimal Discount { get; set; }

            /// <summary>
            /// 运费
            /// </summary>
            public decimal PostFee { get; set; }

            /// <summary>
            /// 总商品数
            /// </summary>
            public long TotalItems { get; set; }

            /// <summary>
            /// 下单时间
            /// </summary>
            public DateTime Created { get; set; }

            /// <summary>
            /// 订单商品明细
            /// </summary>
            public List<Item> Items { get; set; }

            /// <summary>
            /// 最后操作用户ID
            /// </summary>
            public int? ConfirmUserId { get; set; }
        }

        /// <summary>
        /// 收货地址
        /// </summary>
        public class Address
        {
            /// <summary>
            /// 省
            /// </summary>
            public string Provice { get; set; }

            /// <summary>
            /// 市
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// 区县
            /// </summary>
            public string Dist { get; set; }
        }

        /// <summary>
        /// 商品明细对象
        /// </summary>
        public class Item
        {
            /// <summary>
            /// 商品编号
            /// </summary>
            public long ProductId { get; set; }

            /// <summary>
            /// 价格
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            public int N { get; set; }
        }

        /// <summary>
        /// 测试请求接口
        /// </summary>
        [Serializable]
        public class TestRequestDto : PageListRequestDto, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            // [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 下单时间1
            /// </summary>
            public DateTime? Created1 { get; set; }

            /// <summary>
            /// 下单时间2
            /// </summary>
            public DateTime? Created2 { get; set; }

            /// <summary>
            /// 演示让在验证前还有一次机会修改上送参数值
            /// </summary>
            public override void BeforeValid()
            {
                if (this.OrderId.IsNullOrEmpty())
                {
                    this.OrderId = "system";
                }

                if (this.PageIndex <= 0)
                {
                    this.PageIndex = 1;
                }

                if (this.PageSize <= 0)
                {
                    this.PageSize = 20;
                }

                this.UserId = 12;
            }

            /// <summary>
            /// 演示自定义的业务逻辑参数判断
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IActionSelector _actionSelector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionSelector"></param>
        public ComplexTestAction(IActionSelector actionSelector)
        {
            this._actionSelector = actionSelector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Order>> Execute()
        {
            //上送参数对象
            var objAttributes = this.RequestDto.GetAttributes(appendEmptyValueToDictionary: false);

            //记录下日志
            this.Logger.Error(objAttributes.SerializeObjectToJosn());

            //接口层
            var action = new IdsGetAction();
            ((IAction)action).RequestDto = new IdsGetAction.IdsGetActionRequest()
            {
                N = 100,
                Type = IdsGetAction.IdType.ProductId,
                UserId = 0,
                UserName = "ss"
            };
            var x = action.Execute();

            //返回值
            return this.SuccessActionResult(new ActionResultPagerData<Order>()
            {
                TotalRecords = 100,
                ItemList = new List<Order>() { 
                    new Order() { OrderId = this.RequestDto.OrderId, Address = new Address() { Provice = "湖南省", City = "长沙市", Dist = "长沙县" } },
                    new Order() { OrderId = this.RequestDto.OrderId, Address = new Address() { Provice = "湖南省", City = "长沙市", Dist = "长沙县" } },
                    new Order() { OrderId = this.RequestDto.OrderId, Address = new Address() { Provice = "湖南省", City = "长沙市", Dist = "长沙县" } }
                }
            });
        }
    }
}
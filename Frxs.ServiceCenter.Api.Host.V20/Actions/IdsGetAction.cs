using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/10 9:22:42
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Frxs.ServiceCenter.Api.Host.Actions
{
    /// <summary>
    /// 获取ID流水码；设计思想，数据库只记录每次批量生成1万个ID号持久化最后的一个流水索引号；
    /// 等1万个ID号从缓冲池里取完后，在触发批量生成一万个流水码的方法，数据库只要更新一下流水码+1万
    /// 这样大大降低数据库并发；将数据库压力推给应用程序处理。为了防止缓冲池号段取完，可以做个预警机制
    /// 即：在取完一半号段的时候，触发重新输出下一批号段到缓冲池，这样就可以防止取完号段瞬间并发到数据库
    /// </summary>
    [ActionName("Ids.Get")]
    public class IdsGetAction : ActionBase<IdsGetAction.IdsGetActionRequest, string[]>
    {
        /// <summary>
        /// 当前索引号
        /// </summary>
        private static int _currentIndex = 0;
        /// <summary>
        /// 
        /// </summary>
        private static object _locker = new object();

        /// <summary>
        /// 获取主键类型枚举
        /// </summary>
        public enum IdType
        {
            /// <summary>
            /// 
            /// </summary>
            [Description("产品主键")]
            ProductId,

            /// <summary>
            /// 
            /// </summary>
            [Description("仓库主键")]
            WarehouseId

        }

        /// <summary>
        /// 上送参数
        /// </summary>
        [Serializable]
        public class IdsGetActionRequest : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 获取ID的数量
            /// </summary>
            [In(0, 1, 2, 3, 4)]
            public int N { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [NotEqual("N"), GreaterThan(0)]
            public int? X { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Required, In("z", "l")]
            public string Y { get; set; }

            /// <summary>
            /// 生成主键类型
            /// </summary>
            public IdType Type { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [GreaterThan("2015-1-1")]
            public DateTime Date { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [LessThanOrEqual(0)]
            public int Z { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Required][NotEmpty]
            public List<int> B { get; set; }

            /// <summary>
            /// 校验参数准确性
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.N <= 0)
                {
                    yield return new RequestDtoValidatorResultError("N");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string[]> Execute()
        {

            var s = ServicesContainer.Current.Resolver<ISdkCodeGeneratorFactory>().Create("CSharp");

            var x = s.GeneratorRequest(new ReflectedActionDescriptor(typeof(IdsGetAction)).GetActionDescriptor());

            //一次请求的数量
            int n = this.RequestDto.N;

            //加把锁
            lock (_locker)
            {
                //修改下流水索引
                _currentIndex = _currentIndex + n;

                //组装Id
                List<string> ids = new List<string>();
                for (int i = _currentIndex - n; i < _currentIndex; i++)
                {
                    ids.Add("{0}{1:00000000}".With(DateTime.Now.ToString("yyMMdd"), i));
                }

                //返回ID集合
                return this.SuccessActionResult(ids.ToArray());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutingContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            actionExecutingContext.RequestContext.AdditionDatas.Add("date0", DateTime.Now);
            base.OnActionExecuting(actionExecutingContext: actionExecutingContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.RequestContext.AdditionDatas.Add("date1", DateTime.Now);
            base.OnActionExecuted(actionExecutedContext: actionExecutedContext);
        }
    }
}
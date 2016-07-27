/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/9 20:00:35
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 请求参数传输对象抽象基类，当前操作接口的用户id和用户名称；是的实现类无需重复定义
    /// 在具体的请求实现类里，针对http请求特殊性（全部数据都是按照字符串提交的），因此定义
    /// 数据类型的时候，接口上送参数也尽量定义成简易的数据类型（含复杂对象的属性）
    /// （string,int,long,enum,decimal,list,数组）
    /// </summary>
    [Serializable]
    public abstract class RequestDtoBase : IRequestDto, IRequestDtoValidatable
    {
        /// <summary>
        /// 当前请求操作用户ID，此属性应该改成string类型，因为并不一定所有业务类型用户ID都是数值型
        /// (设计失误，下一版(V30)本里会改过来)
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 当前请求操作用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 此方法也许在执行Valid()方法前执行(即在此操作的时候，所有的验证特性还未曾生效)，让上送参数对象
        /// 有机会处理下自己的数据，比如设置默认值操作等 比如：当前属性UserName为空的时候，可以在重写方法
        /// 里设置：this.UserName = "system" 给予默认值(目的是为了在添加数据的时候，给予一个默认值等...)
        /// 当然，这里的作用远不止上面的，这里可以将上送参数，在创建接口实例前进行保存，然后保存到当前运行上下文
        /// 可以在注入的时候，使用上送的值
        /// </summary>
        public virtual void BeforeValid() { }

        /// <summary>
        /// 默认实现下自定义参数业务准确性校验，具体实现类里需要可以重写此方法
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            //直接返回一个空的验证集合（无错误信息）
            return new List<RequestDtoValidatorResultError>();
        }

        /// <summary>
        /// 语言包访问入口
        /// 调用如：this.L("Exist_S","删除 {0} 出错，当前状态为：{1}" , "001", "已确定")
        /// </summary>
        protected Localizer L
        {
            get
            {
                return (resourceKey, defaultValue, args) =>
                {
                    var languageResourceManager = LanguageResourceManager.Instance;
                    if (languageResourceManager.IsNull())
                    {
                        return defaultValue ?? string.Empty;
                    }
                    //key为空，直接返回默认的说明
                    if (resourceKey.IsNullOrEmpty())
                    {
                        return defaultValue ?? string.Empty;
                    }
                    //获取资源
                    string value = languageResourceManager.GetLanguageResourceValue(resourceKey, defaultValue);
                    //含有参数就进行格式化
                    return args.IsNull() || args.Length == 0 ? value : value.With(args);
                };
            }
        }
    }
}

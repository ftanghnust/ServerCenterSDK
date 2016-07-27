/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 默认的对象绑定器； 针对简易对象(属性不包含复杂对象)
    /// </summary>
    internal class DefaultModelBinder : IModelBinder
    {
        /// <summary>
        /// 根据值提供其，绑定对象，自动给参数赋值，使用反射方式
        /// </summary>
        /// <param name="valueProvidersManager">值提供器管理器</param>
        /// <typeparam name="T">待绑定的类型必须要有无参构造函数</typeparam>
        /// <returns></returns>
        public T Bind<T>(IValueProvidersManager valueProvidersManager)
        {
            //参数不能为null
            valueProvidersManager.CheckNullThrowArgumentNullException("valueProvidersManager");

            //创建对象，并且对属性赋值（如果属性值在值提供器里存在并且可以转型成功）
            T obj = Activator.CreateInstance<T>();

            //获取对象属性
            var propertys = obj.GetType().GetPropertiesInfo();

            //循环属性从值提供器里进行赋值
            foreach (var p in propertys)
            {
                //从对象里获取数据
                var value = valueProvidersManager.GetValue(p.Name);

                //属性是可写并且不是索引方法的并且数据不为null
                if (!p.CanWrite || p.GetIndexParameters().Length > 0 || value.IsNull())
                {
                    continue;
                }
                try
                {
                    p.SetValue(obj, Convert.ChangeType(value, p.PropertyType), null);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return obj;
        }
    }
}
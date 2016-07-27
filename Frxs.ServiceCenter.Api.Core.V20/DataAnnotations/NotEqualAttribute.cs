/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/29 11:26:15
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Api.Core.Resource;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// 比较指定属性值，检测是否与当前属性相等
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotEqualAttribute : ValidationAttribute
    {
        /// <summary>
        /// 待比对的属性名称
        /// </summary>
        public string MemberToCompare { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberToCompare">待比对的属性名称</param>
        public NotEqualAttribute(string memberToCompare)
        {
            this.MemberToCompare = memberToCompare;
            this.ErrorMessage = "值不能与属性{0}相等".With(memberToCompare);
        }

        /// <summary>
        /// 确定对象的指定值是否有效
        /// </summary>
        /// <param name="value">要验证的对象的值</param>
        /// <param name="validationContext">描述执行验证检查的上下文</param>
        /// <returns>如果指定的值有效，则为 true；否则，为 false。</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //为null，直接返回正确
            if (value.IsNull())
            {
                return ValidationResult.Success;
            }

            //当前对象
            var instance = validationContext.ObjectInstance;

            //获取属性属性信息
            var propertyInfo = instance.GetType().GetProperty(this.MemberToCompare, Reflection.BindingFlags.Public | Reflection.BindingFlags.Instance);
            if (propertyInfo.IsNull())
            {
                throw new ApiException("属性:{0}未找到".With(this.MemberToCompare));
            }

            //待比对的属性值
            var compareValue = propertyInfo.GetValue(validationContext.ObjectInstance);

            //相等，返回错误
            if (value.Equals(compareValue))
            {
                return new ValidationResult(this.ErrorMessage.With(validationContext.MemberName), new string[] { validationContext.MemberName });
            }

            //返回核对成功
            return ValidationResult.Success;
        }
    }
}

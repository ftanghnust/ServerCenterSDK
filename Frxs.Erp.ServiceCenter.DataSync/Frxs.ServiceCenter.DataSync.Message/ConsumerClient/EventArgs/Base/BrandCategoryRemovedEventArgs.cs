/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/27 10:41:11.939
 * **************************************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{
    /// <summary>
    /// 品牌移除(Remove)事件
    /// 备注：在 品牌（BrandCategory）中的使用
    /// 使用范围：品牌（BrandCategory）移除 操作中使用
    /// </summary>
    [Serializable]
    public class BrandCategoryRemovedEventAgrs : EventArgsBase
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        public int BrandId { get; set; }
    }
}
/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/27 10:41:11.949
 * **************************************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{
    /// <summary>
    /// 商品移除(Remove)事件
    /// 备注： 只同步商品（Product）中的数据（更改状态）过来
    /// 使用范围：商品移除 操作中使用
    /// </summary>
    [Serializable]
    public class ProductRemovedEventAgrs : EventArgsBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }
    }
}

/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/27 10:41:11.942
 * **************************************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{
    /// <summary>
    /// 基本分类创建(Created)事件
    /// 备注：当基本分类在创建的时候，需要发布此事件
    /// 使用范围：基本分类（Category）创建 操作中使用
    /// </summary>
    [Serializable]
    public class CategoryCreatedEventAgrs : EventArgsBase
    {
        /// <summary>
        /// 基本分类编号
        /// </summary>
        public int CategoryId { get; set; }
    }
}

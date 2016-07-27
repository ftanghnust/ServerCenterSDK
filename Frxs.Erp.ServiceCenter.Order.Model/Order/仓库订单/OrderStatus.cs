using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    //订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
    public enum OrderStatus:int
    {
        /// <summary>
        /// 草稿
        /// </summary>
        Draft=0,

        /// <summary>
        /// 等待确认
        /// </summary>
        WaitConfirm=1,

        /// <summary>
        /// 等待拣货
        /// </summary>
        WaitPick=2,

        /// <summary>
        /// 正在拣货
        /// </summary>
        Picking=3,

        /// <summary>
        /// 拣货完成
        /// </summary>
        PickFinished=4,

        /// <summary>
        /// 打印完成
        /// </summary>
        Printed=5,

        /// <summary>
        /// 正在配送中
        /// </summary>
        Delivering=6,

        /// <summary>
        /// 交易完成
        /// </summary>
        Finished=7,

        /// <summary>
        /// 客户交易取消
        /// </summary>
        CancelByCustomer=8,

        /// <summary>
        /// 客服交易关闭
        /// </summary>
        CancelByService=9,

        /// <summary>
        /// 交易关闭
        /// </summary>
        Cancel=100,

        /// <summary>
        /// 可编辑订单
        /// </summary>
        CanEdit=101
    }
}

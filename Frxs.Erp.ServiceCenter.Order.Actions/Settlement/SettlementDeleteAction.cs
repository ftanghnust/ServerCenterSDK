using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Settlement
{
    /// <summary>
    /// 结算单删除
    /// </summary>
    [ActionName("Settlement.Del")]
    public class SettlementDeleteAction : ActionBase<RequestDto.SettlementDelRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string warehouseId = requestDto.Wid.ToString();
            int rows = 0;//计数

            string message = string.Empty;
            var connection = DALFactory.GetLazyInstance<ISettlementDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {


                SettlementQuery query = new SettlementQuery
                                            {
                                                Wid = requestDto.Wid,
                                                SubWid = requestDto.SubWid,
                                                SettleDate = requestDto.SettleDate
                                            };
                //先按照条件来读取要改变的数据对象
                IList<Model.Settlement> settlementList = DALFactory.GetLazyInstance<ISettlementDAO>(warehouseId).GetList(query);
                foreach (var item in settlementList)
                {
                    Model.Settlement settlement = new Model.Settlement { ID = item.ID };
                    Model.SettlementDetail settlementDetail = new SettlementDetail { RefSet_ID = item.ID };

                    //先删除明细
                    rows += DALFactory.GetLazyInstance<ISettlementDetailDAO>(warehouseId).DeleteSettlementDetail(connection, trans, settlementDetail);

                    //后删除主表
                    DALFactory.GetLazyInstance<ISettlementDAO>(warehouseId).Delete(connection, trans, settlement);
                }

                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

            if (string.IsNullOrEmpty(message))
            {
                return this.SuccessActionResult(string.Format("操作完成，批量删除了{0}条日结明细数据。", rows), rows);
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = message
                };
            }
        }

    }
}

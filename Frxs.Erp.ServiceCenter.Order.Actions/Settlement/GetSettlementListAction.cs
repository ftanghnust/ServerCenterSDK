/*********************************************************
 * FRXS 小马哥 2016/6/24 14:42:23
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Settlement
{
    /// <summary>
    /// 获取日结列表
    /// </summary>
    [ActionName("GetSettlementList")]
    public class GetSettlementListAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.Settlement.GetSettlementListAction.GetSettlementListActionRequestDto, Frxs.Erp.ServiceCenter.Order.Actions.Settlement.GetSettlementListAction.GetSettlementListActionResponseDto>
    {
        /// <summary>
        /// 接口传入参数
        /// </summary>
        public class GetSettlementListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 页索引
            /// </summary>
            public int? PageIndex { get; set; }

            /// <summary>
            /// 页大小
            /// </summary>
            public int? PageSize { get; set; }

            /// <summary>
            /// 查询时间
            /// </summary>
            public DateTime SerchTime { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public int? WID { get; set; }

            /// <summary>
            /// 子机构仓库编号
            /// </summary>
            [Required]
            public int? SubWID { get; set; }

            /// <summary>
            /// 仓库名称
            /// </summary>
            [Required]
            public string StockName { get; set; }
        }
        /// <summary>
        /// 接收输出参数
        /// </summary>
        public class GetSettlementListActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 总条数
            /// </summary>
            public int PageCount { get; set; }

            /// <summary>
            /// 总页数
            /// </summary>
            public int PageTotal { get; set; }

            /// <summary>
            /// 日结数据
            /// </summary>
            public IList<Model.Settlement> SettlementList { get; set; }
        }

        /// <summary>
        /// 执行逻辑业务
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetSettlementListActionResponseDto> Execute()
        {
            int pIndex = RequestDto.PageIndex == null ? 1 : Utils.StrToInt(RequestDto.PageIndex, 0);
            int pSize = RequestDto.PageSize == null ? 10 : Utils.StrToInt(RequestDto.PageSize, 0);
            PageListBySql<Model.Settlement> page = new PageListBySql<Model.Settlement>(pIndex, pSize);
            page.OrderFields = "SettleDate desc";
            PageListBySql<Model.Settlement> page1 = new PageListBySql<Model.Settlement>(pIndex, pSize);
            page1.OrderFields = "SettleDate desc";
            PageListBySql<Model.Settlement> models = SettlementBLO.GetSettlementList(page,
                                                                                     RequestDto.GetAttributes(false),
                                                                                     RequestDto.WID.ToString());
            Dictionary<string, object> dicParams = new Dictionary<string, object>();
            dicParams.Add("SubWID", RequestDto.SubWID);
            PageListBySql<Model.Settlement> modelsGetMaxDate = SettlementBLO.GetSettlementList(page1,
                                                                                     dicParams,
                                                                                     RequestDto.WID.ToString());

            #region 拼凑数据

            models.ItemList.ToList().ForEach(x =>
                                                 {
                                                     x.WorkStockName = x.WName + "-" + x.SubWName;
                                                     x.IsWork = string.IsNullOrWhiteSpace(x.ID) ? "否" : "是";
                                                     x.StatusName = x.Status == 0 ? "手动" : "自动";
                                                 });

            #endregion

            //获取当前系统时间
            DateTime dtNow = DateTime.Now;
            //获取最大日结算时间
            DateTime? sDate = null;
            /*
             * 1、当返回数据源有数据，则判断数据源中的最大日结算时间和当前系统时间，如果最大日结算时间小于（不等于）系统时间，则构造一条最大日结算时间多一天的伪数据并返回，否则跳过
             * 2、当返回数据没有数据源，则调用接口获取一个起始时间，根据起始时间构造一条伪数据并返回（第三方接口由罗靖提供）
             */
            if (modelsGetMaxDate.ItemList.Count > 0)
            {
                sDate = modelsGetMaxDate.ItemList.ToList().Max(x => x.SettleDate);

                if (models.ItemList.Count > 0)
                {
                    // sDate = models.ItemList.ToList().Max(x => x.ModifyTime);

                    if (dtNow.Date > sDate.Value.Date)
                    //if (dtNow.Year > sDate.Value.Year 
                    //    || (dtNow.Year == sDate.Value.Year && dtNow.Month > sDate.Value.Month) 
                    //    || (dtNow.Year == sDate.Value.Year && dtNow.Month == sDate.Value.Month && dtNow.Day > sDate.Value.Day))
                    {
                        #region 最大日结算时间小于（不等于）系统时间,构造数据，其他实体属性为默认值
                        Model.Settlement setModel = new Model.Settlement();
                        setModel.SettleDate = sDate.Value.AddDays(1);//流水时间
                        setModel.WorkStockName = RequestDto.StockName;//执行仓库
                        setModel.IsWork = "否";
                        setModel.StatusName = "";
                        models.ItemList.Add(setModel);
                        #endregion
                    }
                }
                else
                {
                    if (dtNow.Date > sDate.Value.Date)
                    {
                        #region 调用第三方接口获取日结开始时间并构造数据

                        //sDate = StockQueryBLO.GetStockQtyCreateMinDate(Utils.StrToInt(RequestDto.WID, 0), Utils.StrToInt(RequestDto.SubWID, 0));
                        Model.Settlement setModel = new Model.Settlement();
                        setModel.SettleDate = sDate.Value.AddDays(1);
                        setModel.WorkStockName = RequestDto.StockName; //执行仓库
                        setModel.IsWork = "否";
                        setModel.StatusName = "";
                        models.ItemList.Add(setModel);

                        #endregion
                    }
                }
            }
            else
            {
                #region 调用第三方接口获取日结开始时间并构造数据
                sDate = StockQueryBLO.GetStockQtyCreateMinDate(Utils.StrToInt(RequestDto.WID, 0), Utils.StrToInt(RequestDto.SubWID, 0));
                Model.Settlement setModel = new Model.Settlement();
                setModel.SettleDate = sDate.Value.Date;
                setModel.WorkStockName = RequestDto.StockName;//执行仓库
                setModel.IsWork = "否";
                setModel.StatusName = "";
                models.ItemList.Add(setModel);
                #endregion
            }
            GetSettlementListActionResponseDto respDto = new GetSettlementListActionResponseDto();
            respDto.PageCount = models.TotalRecords == 0 ? 1 : models.TotalRecords;
            respDto.PageTotal = models.TotalPages;
            respDto.SettlementList = models.ItemList;
            return SuccessActionResult(respDto);
        }
    }
}

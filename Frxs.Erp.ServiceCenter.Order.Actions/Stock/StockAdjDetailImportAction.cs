using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Log;
using Frxs.ServiceCenter.Api.Core;
//using Frxs.ServiceCenter.Api.Core.Redis;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 17:12:16
 * *******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 盘点调整明细表 导入接口
    /// </summary>
    [ActionName("StockAdjDetail.Import")]
    public class StockAdjDetailImportAction : ActionBase<StockAdjDetailImportAction.StockAdjDetailImportActionRequestDto, int>
    {
        private string cacheKey = "StockAdjDetailImport";
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjDetailImportActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 批次 第一批是1，最后一批-1
            /// </summary>
            public int BatchIndex { get; set; }
            /// <summary>
            /// 仓库ID(Warehouse.WID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int WID { get; set; }

            /// <summary>
            /// 仓库子机构ID
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int SubWID { get; set; }

            /// <summary>
            /// 盘亏盘赢调整编号(StockAdj.AdjID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string AdjID { get; set; }

            /// <summary>
            /// 导入的盘点调整数据集合
            /// </summary>
            public IList<StockAdjDetailImportModel> ImportList { get; set; }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class StockAdjDetailSaveActionResponseDto
        {

        }

        #region 当需要采用2种以上不同的缓存机制的时候，可以使用如下方式
        ///// <summary>
        ///// 缓存
        ///// </summary>
        //private ICacheManager _cacheManager;

        ///// <summary>
        ///// 缓存
        ///// </summary>
        ///// <param name="cacheManager"></param>
        //public StockAdjDetailImportAction(ICacheManager cacheManager)
        //{
        //    this._cacheManager = cacheManager;
        //} 
        #endregion

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //分库连接 先确定仓库ID
            string warehouseId = RequestDto.WID.ToString();

            #region 处理业务逻辑之前 对数据进行校验判断

            #region 判断仓库ID必须正确，列表记录不能为空

            if (this.RequestDto == null || RequestDto.WID <= 0)
            {
                return ErrorActionResult("上传的参数不正确!请确保仓库ID正确!");
            }
            if (RequestDto.ImportList == null || RequestDto.ImportList.Count <= 0)
            {
                return ErrorActionResult("没有上传列表记录!");
            }
            #endregion

            #region 新增 明细之前，要确认表头记录存在且是处于录单状态，否则不能修改
            var currentModel = StockAdjBLO.GetModel(RequestDto.AdjID, warehouseId);
            if (currentModel == null)
            {
                return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不存在!", RequestDto.AdjID));
            }
            else if (currentModel.Status != 0)
            {
                return ErrorActionResult(string.Format("操作失败,单号[{0}]的盘点调整主表记录不是“录单”状态!", RequestDto.AdjID));
            }
            #endregion

            #region 盘点详情表和扩展表 主键ID不能重复 防止前端程序传来的数据异常导致在后期写数据库失败
            bool repeatID = RequestDto.ImportList.GroupBy(o => o.ID).Where(g => g.Count() > 1).Count() > 0;
            if (repeatID == true)
            {
                var existIdList = RequestDto.ImportList.GroupBy(o => o.ID).Where(g => g.Count() > 1).Select(o => o.Key).ToList();
                string existIds = string.Empty;
                foreach (var item in existIdList)
                {
                    existIds += " " + item + "  ";
                }
                return ErrorActionResult(string.Format("存在重复的主键ID [{0}] !", existIds));
            }
            #endregion

            #region 列表内的商品编码不能重复
            bool repeatSKU = RequestDto.ImportList.GroupBy(o => o.SKU).Where(g => g.Count() > 1).Count() > 0;
            if (repeatSKU == true)
            {
                var existSkuList = RequestDto.ImportList.GroupBy(o => o.SKU).Where(g => g.Count() > 1).Select(o => o.Key).ToList();
                string existSkus = string.Empty;
                foreach (var item in existSkuList)
                {
                    existSkus += " " + item + "  ";
                }
                return ErrorActionResult(string.Format("表格中存在重复的商品编码 [{0}] !", existSkus));
            }
            #endregion

            #region 为防止数据库中已经有明细记录或者后期需求改变为允许追加Excel数据导入,应该先判断SKU是否已经在现有的数据库明细中,若已经有SKU,弹出信息提示并终止操作
            //已在数据库中的SKU列表
            var skusInDB = StockAdjDetailBLO.GetSkuList(RequestDto.AdjID, warehouseId).ToList();
            if (skusInDB != null && skusInDB.Count > 0)
            {
                //将要添加的SKU列表
                var skusToDB = RequestDto.ImportList.Select(o => o.SKU).ToList();
                //筛选出已经存在数据库中又出现在Excel表格的SKU
                List<string> existSkuInDB = skusInDB.FindAll(x => skusToDB.Contains(x));
                string existSkuInDBStr = string.Empty;
                if (existSkuInDB.Count > 0)
                {
                    foreach (var sku in existSkuInDB)
                    {
                        existSkuInDBStr += " " + sku + " ";
                    }
                    return ErrorActionResult(string.Format("单据[{0}]中已存在下列商品编码 [{1}]!", RequestDto.AdjID, existSkuInDBStr));
                }
            }
            #endregion

            #endregion

            #region 定义一些基准变量：计数、错误信息、缓存Key、基本资料中心客户端SDK访问对象、SDK超时时间
            //返回的成功记录的计数
            int rows = 0;
            //当前批次内遍历的行号
            int index = 0;
            //事务执行返回的错误信息
            string msg = string.Empty;
            //商品相关的详细错误信息,当有多个商品信息错误的时候，由单次提示改成一次性返回
            string prdErrDetail = string.Empty;

            //数据库中的基准计数 用来确定 明细表的 SerialNumber
            //现有数据库中的明细最大序号 预留的 //虽然现有的需求是要求先清空记录再导入，但为了防止以后需求转变为允许追加导入的情况，先定义该变量
            int maxSerialInDB = StockAdjBLO.GetDetailMaxSerialNumber(RequestDto.AdjID, warehouseId);
            //缓存的Key
            string currentKey = cacheKey + RequestDto.AdjID;
            //缓存的错误信息
            string currentErrKey = string.Format("{0}-ErrMsg", currentKey);
            //上一批记录为止产生的错误信息
            string lastErrMsg = string.Empty;
            //准备写入缓存的集合
            IList<StockAdjDetailWithExt> detailWithExtList = new List<StockAdjDetailWithExt>();

            //现有的缓存中的基准计数 用来确定 明细表的 SerialNumber
            int rowsInCache = 0;
            //从缓存中读取上一次加入的集合
            List<StockAdjDetailWithExt> listFromCache = CacheManager.Get<List<StockAdjDetailWithExt>>(currentKey);//ReadFormCahce(currentKey);

            //只要不是第一批次，就会有个缓存基准计数
            if (RequestDto.BatchIndex != 1 && listFromCache != null && listFromCache.Count >= 0)
            {
                rowsInCache = listFromCache.Count;
            }

            //取出导入列表的SKU列 作为入参 批量查询商品详情和库存信息
            var skuQueryList = RequestDto.ImportList.ToList().Select(o => { return o.SKU; }).ToList();

            //准备调用 产品SDK,获取到 基本资料中心客户端SDK访问对象 （根据2016-3-22 胡勇提供的 “5个服务中心的依赖关系”，订单SDK可以调用基本资料SDK，但不可反向调用）
            var productWorkContext = WorkContext.CreateProductSdkClient();
            //设置基础库接口调用的超时时间 
            productWorkContext.SetTimeout(100000);

            #endregion

            #region 调用接口批量获取商品详情和库存信息

            #region 开始调用接口批量获取商品详情 日志
            WriteDebugLog(string.Format(" 1. ==========开始处理单号{0}的记录==========批次{1}====={2}=====SDK开始获取{3}条详情记录=========={2}", RequestDto.AdjID, RequestDto.BatchIndex, Environment.NewLine, skuQueryList.Count));
            #endregion

            #region 根据批量的SKU批量获取商品详情
            var prdResp = productWorkContext.Execute(new Product.SDK.Request.FrxsErpProductWProductsAddedListForStockImportGetRequest()
            {
                WID = RequestDto.WID,
                SKUs = skuQueryList,
                UserId = RequestDto.UserId,
                UserName = RequestDto.UserName,
                PageIndex = 1,
                PageSize = int.MaxValue
            });
            #endregion

            #region 完成调用接口批量获取商品详情 日志
            WriteDebugLog(string.Format(" 2. ========== SDK完成获取{0}条商品详情 ==========", skuQueryList.Count));
            #endregion

            if (prdResp == null || prdResp.Data == null || prdResp.Flag != 0)
            {
                return ErrorActionResult(string.Format("操作失败,获取“商品信息”失败!", RequestDto.AdjID));
            }

            #region 开始读取库存 日志
            WriteDebugLog(string.Format(" 3. ========== 开始读取{0}条库存 ==========", skuQueryList.Count));
            #endregion

            #region 批量获取库存数量
            StockNQtyQuery stockQuery = new StockNQtyQuery() { WIDList = new List<int>() { RequestDto.WID }, SKUList = skuQueryList };
            var stockList = StockQueryBLO.QueryOStockQty(stockQuery).Where(o => o.SubWID == RequestDto.SubWID).ToList();//根据仓库子机构过滤的库存信息

            #endregion

            #region 库存耗时记录 日志
            WriteDebugLog(string.Format(" 4. ========== 读取完成{0}库存记录 ==========", stockList.Count));
            #endregion

            #endregion

            #region 调试时记录遍历集合开始 日志记录
            WriteDebugLog(string.Format(" 5. ========== 开始遍历{0}条集合 ==========", RequestDto.ImportList.Count));
            #endregion

            #region 遍历集合 调用接口获取 商品信息 给明细表对象赋值
            foreach (var ImportModel in RequestDto.ImportList)
            {
                index++;
                StockAdjDetailWithExt detailWithExt = new StockAdjDetailWithExt();//准备加入集合的元素

                #region 创建StockAdjDetail、StockAdjDetailsExt对象并初始化，准备添加到集合
                StockAdjDetail detailModel = new StockAdjDetail();

                detailModel.WID = RequestDto.WID;
                detailModel.AdjID = RequestDto.AdjID;
                detailModel.ModifyTime = DateTime.Now;
                detailModel.ModifyUserID = RequestDto.UserId;
                detailModel.ModifyUserName = RequestDto.UserName;

                //来自导入的表格的数据
                detailModel.SKU = ImportModel.SKU;          //商品编码
                detailModel.ID = ImportModel.ID;            //由调用放生成ID
                detailModel.AdjQty = ImportModel.AdjQty;    //调整数量
                detailModel.Remark = ImportModel.Remark;    //备注信息

                StockAdjDetailsExt extModel = new StockAdjDetailsExt();
                extModel.ID = ImportModel.ID;
                extModel.AdjID = RequestDto.AdjID;
                extModel.ModifyTime = DateTime.Now;
                extModel.ModifyUserID = RequestDto.UserId;
                extModel.ModifyUserName = RequestDto.UserName;
                #endregion

                #region try catch 匹配接口结果 给明细表和扩展表对象赋值
                try
                {
                    int excelRow = index + rowsInCache + 1;
                    //序列号，不要求连贯 但是不能重复！！ maxSerialInDB是数据库的明细基数，rowsInCache是缓存中已有的明细基数
                    detailModel.SerialNumber = index + maxSerialInDB + rowsInCache + 1;//按数据库字段说明的要求，基数SerialNumber从1开始,不是从0开始

                    #region 判断库存  判断调用库存的访问对象是否可用
                    if (stockList != null || stockList.Count > 0)
                    {
                        //根据仓库子机构过滤的库存信息
                        var currentStock = stockList.FirstOrDefault(o => (o.SKU == ImportModel.SKU && o.SubWID == RequestDto.SubWID));
                        if (currentStock == null)
                        {
                            detailModel.StockQty = 0;//经过需求确认，匹配不到库存数量表示库存为0
                        }
                        else
                        {
                            detailModel.StockQty = currentStock.StockQty;//匹配到的库存信息
                        }
                    }
                    else
                    {//若调用库存的返回对象不可用，认为没有初始的库存信息，则所有的库存数量为0
                        detailModel.StockQty = 0;//经过需求确认，查询不到库存数量表示库存为0
                    }
                    #endregion

                    var currentDetail = prdResp.Data.ItemList.FirstOrDefault(o => o.SKU == ImportModel.SKU);
                    if (currentDetail == null)
                    {
                        prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“商品信息”失败!<br />", excelRow, ImportModel.SKU);
                    }
                    else
                    {
                        #region 为确保必填属性字段不为NULL 判断商品信息接口返回的内部属性值是否存在
                        if (!currentDetail.BigPackingQty.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“包装数”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.BrandId1.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“品牌ID1”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.CategoryId1.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“基本分类1”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.CategoryId2.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“基本分类2”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.CategoryId3.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“基本分类3”失败!<br />", excelRow, ImportModel.SKU);
                        }

                        if (!currentDetail.ShopCategoryId1.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“运营分类1”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.ShopCategoryId2.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“运营分类2”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (!currentDetail.ShopCategoryId3.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“运营分类3”失败!<br />", excelRow, ImportModel.SKU);
                        }

                        if (!currentDetail.VendorID.HasValue)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“供应商ID”失败!<br />", excelRow, ImportModel.SKU);
                        }

                        if (currentDetail.BuyPrice == null)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“采购价格”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        if (currentDetail.SalePrice == null)
                        {
                            prdErrDetail += string.Format("第[{0}]行:获取商品[{1}]的“销售价”失败!<br />", excelRow, ImportModel.SKU);
                        }
                        #endregion

                        #region 盘点调整明细表信息赋值
                        int productId = currentDetail.ProductId;
                        detailModel.ProductId = productId;
                        detailModel.ProductName = currentDetail.ProductName;

                        //商品条码
                        detailModel.BarCode = currentDetail.BarCode;

                        //获取图片信息 与需求方确认 允许为空
                        if (!currentDetail.ProductImageUrl200.IsNullOrEmpty())
                        {
                            detailModel.ProductImageUrl200 = currentDetail.ProductImageUrl200;
                        }
                        else
                        {
                            detailModel.ProductImageUrl200 = string.Empty;
                        }

                        if (!currentDetail.ProductImageUrl400.IsNullOrEmpty())
                        {
                            detailModel.ProductImageUrl400 = currentDetail.ProductImageUrl400;
                        }
                        else
                        {
                            detailModel.ProductImageUrl400 = string.Empty;
                        }

                        //调整单位包装数 2016-6-8 进一步需求确认，该值固定为1
                        detailModel.AdjPackingQty = 1;//(currentDetail.BigPackingQty.HasValue) ? currentDetail.BigPackingQty.Value : 0;
                                                      //调整单位(j库存单位,预留，先阶段 取“库存单位”)
                        detailModel.AdjUnit = currentDetail.Unit;
                        //库存单位
                        detailModel.Unit = currentDetail.Unit;
                        //库存单位采购价
                        detailModel.BuyPrice = (currentDetail.BuyPrice.HasValue) ? currentDetail.BuyPrice.Value : 0;
                        //库存单位销售价
                        detailModel.SalePrice = (currentDetail.SalePrice.HasValue) ? currentDetail.SalePrice.Value : 0;

                        //2016-6-8 胡总与现场核实后要求，不要乘以包装数,所以调整单位包装数值固定为1 //需要计算的字段  总数量 = 调整数量*包装数 //其中的调整数量来自表格 
                        detailModel.UnitQty = detailModel.AdjQty * detailModel.AdjPackingQty;
                        //调整金额 =总数量 * 采购单价
                        detailModel.AdjAmt = detailModel.UnitQty * detailModel.BuyPrice;

                        #region 供应商信息
                        detailModel.VendorID = (currentDetail.VendorID.HasValue) ? currentDetail.VendorID.Value : 0;
                        detailModel.VendorName = currentDetail.VendorName;
                        detailModel.VendorCode = currentDetail.VendorCode;
                        #endregion

                        #endregion

                        #region 库存明细表_待处理单据扩展： 商品品牌、基本分类、运营分类信息

                        //品牌信息ID
                        extModel.BrandId1 = currentDetail.BrandId1;
                        extModel.BrandId2 = currentDetail.BrandId2;
                        //品牌名称
                        extModel.BrandId1Name = (!string.IsNullOrWhiteSpace(currentDetail.BrandId1Name)) ? currentDetail.BrandId1Name : "";
                        extModel.BrandId2Name = (!string.IsNullOrWhiteSpace(currentDetail.BrandId2Name)) ? currentDetail.BrandId2Name : "";

                        //基本分类ID
                        extModel.CategoryId1 = (currentDetail.CategoryId1.HasValue) ? currentDetail.CategoryId1.Value : 0;
                        extModel.CategoryId2 = (currentDetail.CategoryId2.HasValue) ? currentDetail.CategoryId2.Value : 0;
                        extModel.CategoryId3 = (currentDetail.CategoryId3.HasValue) ? currentDetail.CategoryId3.Value : 0;
                        //基本分类名称
                        extModel.CategoryId1Name = (!string.IsNullOrWhiteSpace(currentDetail.CategoryId1Name)) ? currentDetail.CategoryId1Name : "";
                        extModel.CategoryId2Name = (!string.IsNullOrWhiteSpace(currentDetail.CategoryId2Name)) ? currentDetail.CategoryId2Name : "";
                        extModel.CategoryId3Name = (!string.IsNullOrWhiteSpace(currentDetail.CategoryId3Name)) ? currentDetail.CategoryId3Name : "";
                        //运营分类ID
                        extModel.ShopCategoryId1 = (currentDetail.ShopCategoryId1.HasValue) ? currentDetail.ShopCategoryId1.Value : 0;
                        extModel.ShopCategoryId2 = (currentDetail.ShopCategoryId2.HasValue) ? currentDetail.ShopCategoryId2.Value : 0;
                        extModel.ShopCategoryId3 = (currentDetail.ShopCategoryId3.HasValue) ? currentDetail.ShopCategoryId3.Value : 0;
                        //运营分类名称
                        extModel.ShopCategoryId1Name = (!string.IsNullOrWhiteSpace(currentDetail.ShopCategoryId1Name)) ? currentDetail.ShopCategoryId1Name : "";
                        extModel.ShopCategoryId2Name = (!string.IsNullOrWhiteSpace(currentDetail.ShopCategoryId2Name)) ? currentDetail.ShopCategoryId2Name : "";
                        extModel.ShopCategoryId3Name = (!string.IsNullOrWhiteSpace(currentDetail.ShopCategoryId3Name)) ? currentDetail.ShopCategoryId3Name : "";

                        #endregion
                    }
                    //赋值后包装数据
                    detailWithExt.detail = detailModel;
                    detailWithExt.ext = extModel;
                    detailWithExtList.Add(detailWithExt);
                }
                catch (Exception ex)
                {
                    return ErrorActionResult(string.Format("操作失败!：{0} {1}", ex.Message, ex.StackTrace), 0);
                }
                #endregion

            }
            #endregion

            #region 遍历集合赋值完成 日志记录
            WriteDebugLog(string.Format(" 6. ========== 完成{0}条记录对象的赋值 ==========", skuQueryList.Count));
            #endregion

            #region 记录错误信息到缓存
            if (RequestDto.BatchIndex == 1)
            {
                CacheManager.Remove(currentErrKey);
            }
            else
            {
                lastErrMsg = CacheManager.Get<string>(currentErrKey);
            }

            if (!string.IsNullOrEmpty(prdErrDetail))
            {
                //当前批次内商品信息获取失败则先记录错误信息到缓存中
                lastErrMsg += prdErrDetail;//追加错误信息
                CacheManager.Set(currentErrKey, lastErrMsg, 20);
            }
            #endregion

            #region 写缓存和数据库

            //准备写入缓存的集合
            var listToSave = detailWithExtList.ToList();

            if (RequestDto.BatchIndex != -1)
            {
                //非最后批次 只写缓存
                //int cacheSavedNum = SaveToCache(listToCache, currentKey, RequestDto.BatchIndex);
                if (RequestDto.BatchIndex != 1 && listFromCache != null && listFromCache.Count > 0)
                {
                    listToSave.AddRange(listFromCache);
                }
                CacheManager.Set(currentKey, listToSave, 20);//盘点明细缓存时间 20分钟

                //遇到错误先不急于返回错误标志，让前端先把所有的数据送过来统一分析错误。(除非捕获到了异常才会中断返回)
                if (!string.IsNullOrEmpty(prdErrDetail))
                {
                    return SuccessActionResult(string.Format("成功读取了{0}条数据!但有如下错误信息<br />{1}", listToSave.Count, prdErrDetail), listToSave.Count);
                }
                return this.SuccessActionResult(string.Format("成功读取了{0}条数据!", listToSave.Count), listToSave.Count);
            }
            else
            {
                //最后一批次 写入数据库
                //准备写入数据库的集合
                List<StockAdjDetailWithExt> listToDB = new List<StockAdjDetailWithExt>();

                //先将现有缓存中的数据加入准备写数据库的集合 这个集合在定义基准变量的环节已经读取出来了
                if (listFromCache != null && listFromCache.Count > 0)
                {
                    listToDB.AddRange(listFromCache);
                }

                //再将最后一组来自请求的数据追加到写数据库的集合
                if (listToSave != null && listToSave.Count > 0)
                {
                    listToDB.AddRange(listToSave);
                }

                //最后一次应该清除本次导入过程使用的缓存
                CacheManager.Remove(currentKey);

                //验证是否有错误数据并给出汇总的提示
                string totalErrMsg = CacheManager.Get<string>(currentErrKey);
                if (!string.IsNullOrEmpty(totalErrMsg))
                {
                    CacheManager.Remove(currentErrKey);
                    return ErrorActionResult(string.Format("导入失败！<br />{0}", totalErrMsg), listToDB.Count);
                }

                //再次校验商品编码是否重复,然后用事务批量保存
                if (listToDB != null && listToDB.Count > 0)
                {
                    #region 列表内的商品编码不能重复,单批次的校验以后,应该再汇总校验一次
                    var skuList = listToDB.Select(o => o.detail.SKU).ToList();
                    bool repeatSKUtotal = skuList.GroupBy(o => o).Where(g => g.Count() > 1).Count() > 0;
                    if (repeatSKUtotal)
                    {
                        var existSkuList = skuList.GroupBy(o => o).Where(g => g.Count() > 1).Select(o => o.Key).ToList();
                        string existSkus = string.Empty;
                        foreach (var item in existSkuList)
                        {
                            existSkus += " " + item + "  ";
                        }
                        return ErrorActionResult(string.Format("表格中存在重复的商品编码 [{0}] !", existSkus));
                    }
                    #endregion

                    rows = SaveListToDB(warehouseId, listToDB, ref msg);
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    return this.SuccessActionResult(string.Format("操作完成，导入了{0}条数据。<br />{1}", rows, msg), rows);
                }
                else
                {
                    return SuccessActionResult(string.Format("操作完成，导入了{0}条数据。", rows), rows);
                }
            }
            #endregion
        }

        /// <summary>
        /// 根据传入的集合，采用事务保存到数据库
        /// </summary>
        /// <param name="warehouseId">仓库ID，决定了连接哪个数据库</param>
        /// <param name="detailWithExtList">包含明细表和扩展表的对象列表，用于盘点调整Excel数据批量导入</param>
        /// <param name="message">执行中的异常信息</param>
        /// <returns>影响的行数</returns>
        private int SaveListToDB(string warehouseId, IList<StockAdjDetailWithExt> detailWithExtList, ref string message)
        {
            int rows = 0;//计数

            #region 盘点明细导入 事务开始写入 日志记录
            WriteDebugLog(string.Format(" 7. ===== 盘点明细导入 事务开始写入{0}条记录 =====", detailWithExtList.Count));
            #endregion

            //事务操作
            var connection = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                foreach (var detailWithExt in detailWithExtList)
                {
                    rows += DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Save(connection, trans, detailWithExt.detail);
                    DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Save(connection, trans, detailWithExt.ext);
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                message += ex.Message;
                trans.Rollback();
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

            #region 盘点明细导入 事务写入完成 日志记录
            WriteDebugLog(string.Format(" 8. =====盘点明细导入 事务写入完成{0}条记录 {1} ==========本次导入结束 ==========", rows, Environment.NewLine));
            #endregion

            return rows;
        }

        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="logContent"></param>
        private void WriteDebugLog(string logContent)
        {
            //使用服务中心框架自带的记录方法
            Logger.Information(logContent);
        }
    }
}

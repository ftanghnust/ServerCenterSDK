using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 门店排单列表查询 
    /// </summary>
    public class ShopGetListAndOrderRequestDto : PageListRequestDto
    {
        #region 模型
        /// <summary>
        /// 配送日期
        /// </summary>
        [Required]
        public string SearchDate { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// 
        public int? ShopType { get; set; }

        /// <summary>
        /// 是否下单（1为下单，0为否）
        /// </summary>

        public string IsOrder { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        [Required]
        public string WID { get; set; }

        /// <summary>
        /// 线路ID WarehouseLineShop.LineID
        /// </summary>
        public string LineId { get; set; }

        #endregion
    }


    /// <summary>
    /// 仓库后台 门店列表查询 请求对象
    /// </summary>
    public class ShopWhTableListRequestDto : PageListRequestDto
    {
        #region 模型
        /// <summary>
        /// 门店编号
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
       
        public string ShopName { get; set; }

        /// <summary>
        /// 门店帐号
        /// </summary>
        public string ShopAccount { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 门店联系人姓名
        /// </summary>
       
        public string LinkMan { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        
        public string WID { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        
        public string SettleTimeType { get; set; }

        /// <summary>
        /// 线路ID WarehouseLineShop.LineID
        /// </summary>
        public string LineID { get; set; }
                
        #endregion
    }

    /// <summary>
    /// 仓库后台 获取门店详情 请求对象
    /// </summary>
    public class ShopWhGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID { get; set; }
    }
        
    /// <summary>
    /// 仓库后台 保存门店对象 请求对象
    /// </summary>
    public class ShopWhSaveRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 门店ID
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店帐号(XSUser.Account)
        /// </summary>
        
        public string ShopAccount { get; set; }
        /// <summary>
        /// 结帐方式(0:现金 + 数据字典: ShopSettleType)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleType { get; set; }

        /// <summary>
        /// 配送仓库ID(WarehouseInfo.WID)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店联系人姓名
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 门店联系电话
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string Telephone { get; set; }

        /// <summary>
        /// 状态(1:正常;0:冻结)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 法人
        /// </summary>


        public string LegalPerson { get; set; }

        /// <summary>
        /// 结算方式( 数据字典: ShopSettleTimeType)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleTimeType { get; set; }

        /// <summary>
        /// 门店级别(数据字典: ShopLevel; A:A级;B:B级;C:C级)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string CreditLevel { get; set; }

        /// <summary>
        /// 信用额度
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public double CreditAmt { get; set; }

        /// <summary>
        /// 区域负责人
        /// </summary>

        public string AreaPrincipal { get; set; }

        /// <summary>
        /// 省
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int ProvinceID { get; set; }

        /// <summary>
        /// 市
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int CityID { get; set; }

        /// <summary>
        /// 区
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int RegionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public string Address { get; set; }

        /// <summary>
        /// 地址全称
        /// </summary>

        public string FullAddress { get; set; }

        /// <summary>
        /// 门店面积(平方米)
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public decimal ShopArea { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>

        public int IsDeleted { get; set; }

        /// <summary>
        /// 纬度（百度座标)
        /// </summary>

        public string Latitude { get; set; }

        /// <summary>
        /// 经度（百度座标)
        /// </summary>


        public string Longitude { get; set; }

        /// <summary>
        /// 门店累计积分
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public double TotalPoint { get; set; }

        /// <summary>
        /// 银行帐号
        /// </summary>        

        public string BankAccount { get; set; }

        /// <summary>
        /// 银行开户名称
        /// </summary>

        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary>    

        public string BankType { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>


        public string CardID { get; set; }

        /// <summary>
        /// 区域负责人
        /// </summary>       

        public string RegionMaster { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>

        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>

        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>

        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>

        public string ModityUserName { get; set; }


        /// <summary>
        /// 线路ID WarehouseLineShop.LineID
        /// </summary>
        public int LineID { get; set; }

        /// <summary>
        /// 发货排序 WarehouseLineShop.SerialNumber 
        /// </summary>
        public int SerialNumber { get; set; }

        #endregion
    }

   

    /// <summary>
    /// 仓库后台 冻结或解冻门店
    /// </summary>
    public class ShopWhFreezeRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 门店ID 批量操作时用,号分隔
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopID { get; set; }

        /// <summary>
        ///  状态(1:正常;0:冻结)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

    }
}

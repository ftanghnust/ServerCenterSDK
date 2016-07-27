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
    /// 仓库列表查询 请求对象
    /// </summary>
    public class WarehouseTableListRequestDto : PageListRequestDto
    {
        #region 模型

        /// <summary>
        /// 仓库编号(唯一)
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 父级ID 0表示仓库，非0表仓库子机构
        /// </summary>
        public int? ParentWID { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string WContact { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1、已冻结)
        /// </summary>
        public int? IsFreeze { get; set; }

        #endregion
    }

    /// <summary>
    /// 获取仓库详情 请求对象
    /// </summary>
    public class WarehouseGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// WID(主键)
        /// </summary>            
        public int WID { get; set; }

    }

    /// <summary>
    /// 修改仓库信息 请求对象
    /// </summary>
    public class WarehouseEditRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 仓库ID(从1000开始编号)
        /// </summary>        
        public int WID { get; set; }

        /// <summary>
        /// 仓库编号(唯一)
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空"),StringLength(100)]
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public string WName { get; set; }

        /// <summary>
        /// 仓库级别(0:总部[预留];1:仓库;2:仓库子机构物流/退货])
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public int WLevel { get; set; }

        /// <summary>
        /// 子机构类型(0:退货;1:物流库;)
        /// </summary>


        public int WSubType { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>       

        public int ParentWID { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>   
        public string WTel { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string WContact { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public int? RegionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string WAddress { get; set; }

        /// <summary>
        /// 全称地址
        /// </summary>
        public string WFullAddress { get; set; }

        /// <summary>
        /// 400客服电话
        /// </summary>
        public string WCustomerServiceTel { get; set; }

        /// <summary>
        /// 退货部电话
        /// </summary>
        public string THBTel { get; set; }

        /// <summary>
        /// 财务室电话
        /// </summary>
        public string CWTel { get; set; }

        /// <summary>
        /// 业务咨询电话1
        /// </summary>
        public string YW1Tel { get; set; }

        /// <summary>
        /// 业务咨询电话2
        /// </summary>
        public string YW2Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否已被冻结(0:未冻结;1、已冻结)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsFreeze { get; set; }

        /// <summary>
        /// 是否已被删除(0:未删除;1、已删除)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModityUserName { get; set; }

        #endregion
    }

    /// <summary>
    /// 新增仓库对象 请求对象
    /// </summary>
    public class WarehouseSaveRequestDto : RequestDtoBase
    {
        #region 模型

        /// <summary>
        /// 仓库编号(唯一)
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public string WName { get; set; }

        /// <summary>
        /// 仓库级别(0:总部[预留];1:仓库;2:仓库子机构物流/退货])
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public int WLevel { get; set; }

        /// <summary>
        /// 子机构类型(0:退货;1:物流库;)
        /// </summary>


        public int WSubType { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>       

        public int ParentWID { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>   
        public string WTel { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string WContact { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public int? RegionID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string WAddress { get; set; }

        /// <summary>
        /// 全称地址
        /// </summary>
        public string WFullAddress { get; set; }

        /// <summary>
        /// 400客服电话
        /// </summary>
        public string WCustomerServiceTel { get; set; }

        /// <summary>
        /// 退货部电话
        /// </summary>
        public string THBTel { get; set; }

        /// <summary>
        /// 财务室电话
        /// </summary>
        public string CWTel { get; set; }

        /// <summary>
        /// 业务咨询电话1
        /// </summary>
        public string YW1Tel { get; set; }

        /// <summary>
        /// 业务咨询电话2
        /// </summary>
        public string YW2Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否已被冻结(0:未冻结;1、已冻结)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsFreeze { get; set; }

        /// <summary>
        /// 是否已被删除(0:未删除;1、已删除)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

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
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreateUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModityUserName { get; set; }

        #endregion
    }

    /// <summary>
    /// 删除仓库对象 请求对象
    /// </summary>
    public class WarehouseDelRequestDto : RequestDtoBase
    {
        /// <summary>
        /// WID(主键)
        /// </summary>            
        [Required(ErrorMessage = "{0}不能为空")]
        public List<int> WID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModityUserName { get; set; }
    }

    /// <summary>
    /// 冻结或解冻仓库对象 请求对象
    /// </summary>
    public class WarehouseFreezeRequestDto : RequestDtoBase
    {
        /// <summary>
        /// WID(主键)
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public List<int> WID { get; set; }
                
        /// <summary>
        /// 是否冻结 0:未冻结; 1:已冻结
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsFreeze { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModityTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModityUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModityUserName { get; set; }
    }


    /// <summary>
    /// 仓库子机构信息查询
    /// </summary>
    public class WarehouseGetSubWNameRequestDto : RequestDtoBase
    {
        #region 模型

        /// <summary>
        /// 父级ID 0表示仓库，非0表仓库子机构
        /// </summary>
        public int? ParentWID { get; set; }

        /// <summary>
        /// 仓库ID (子机构ID)
        /// </summary>
        public int? WID { get; set; }

        #endregion
    }

    /// <summary>
    /// 验证仓库是否合法
    /// </summary>
    public class WarehouseSubWarehouseValidateRequestDto : RequestDtoBase
    {
        /// <summary>
        /// WID(主键)
        /// </summary>            
        public int WID { get; set; }

        /// <summary>
        /// 子仓库ID
        /// </summary>
        public int SubWID { get; set; }

    }

}

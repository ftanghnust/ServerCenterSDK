using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class WAdvertisementProductRequestDto
    {
        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>

        public int WID { get; set; }

        /// <summary>
        /// 广告ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdvertisementID { get; set; }

        /// <summary>
        /// 促销ID、分类ID、商品ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

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

        #endregion
    }

    /// <summary>
    /// WAdvertisement.GetList
    /// </summary>
    public class WAdvertisementProductGetListActionRequestDto : PageListRequestDto
    {

        #region 模型
       
        /// <summary>
        /// 仓库编号(Warehouse.WID)
        /// </summary>

        public int WID { get; set; }

        /// <summary>
        /// 广告ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdvertisementID { get; set; }

       

        #endregion


        ///// <summary>
        ///// 校验上送参数是否正确
        ///// </summary>
        ///// <returns></returns>
        //public override IEnumerable<RequestDtoValidatorResultError> Valid()
        //{
        //    if (AdvertisementID <= 0)
        //    {
        //        yield return new RequestDtoValidatorResultError("ID");
        //    }
        //}

    }
}

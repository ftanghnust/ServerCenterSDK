
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/5 9:57:29
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductVendorModel
    {
        /// <summary>
        /// 仓库供应商ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorID { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 供应商联系人
        /// </summary>
        public string LinkMan { get; set; }

        /// <summary>
        /// 供应商联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 供应商状态; 状态(1:正常;0:冻结)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 供应商类型名称
        /// </summary>
        public string VendorTypeName { get; set; }

        /// <summary>
        /// 是否主供应商;1是，0不是
        /// </summary>
        public int IsMaster { get; set; }

    }
}

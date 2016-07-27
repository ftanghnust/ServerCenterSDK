using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    [Serializable]
    public class WarehouseSelectModel
    {
        public int? ID{get;set;}
        public int? VendorID{get;set;}
        public int WID{get;set;}
        public string WCode{get;set;}
        public string WName{get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    public class WAdvertisementGetModelActionResponseDto : ResponseDtoBase
    {
        public Frxs.Erp.ServiceCenter.Promotion.Model.WAdvertisement order { get; set; }
        public IList<Frxs.Erp.ServiceCenter.Promotion.Model.WAdvertisementProduct> products { get; set; }
    }
}

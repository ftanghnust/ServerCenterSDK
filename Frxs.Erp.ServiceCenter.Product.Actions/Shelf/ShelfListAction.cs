using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Json;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shelf
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("Shelf.List")]
    public class ShelfListAction : ActionBase<RequestDto.ShelfListRequest, IList<Model.Shelf>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.Shelf>> Execute()
        {
            var requestDto = this.RequestDto;            
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            IList<Model.Shelf> models = ShelfBLO.GetList(requestDtoDict);

            return this.SuccessActionResult(models);
        }

    }
}

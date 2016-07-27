using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.WarehouseEmp
{
    /// <summary>
    /// 获取单个属性详细信息
    /// </summary>
    public class WarehouseEmpResetAction : ActionBase<WarehouseEmpResetAction.WarehouseEmpResetRequestDto, int>
    {

        /// <summary>
        /// 获取IDDTO
        /// </summary>
        public class WarehouseEmpResetRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public int EmpID { get; set; }            
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;
            Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp model = new Model.WarehouseEmp();
            model.EmpID = dto.EmpID;
            model.ModifyTime = DateTime.Now;
            model.ModifyUserID = dto.UserId;
            model.ModifyUserName = dto.UserName;
            model.PasswordSalt = Frxs.Platform.Utility.DEncrypt.DEncrypt.GetSalt();
            model.Password = Frxs.Platform.Utility.DEncrypt.CryptHelper.MD5(Frxs.Platform.Utility.ConstDefinition.PRODUCT_INITIAL_PASSWORD + model.PasswordSalt);

            int row=WarehouseEmpBLO.EditResetPassWord(model);
            WarehouseEmpBLO.DeleteCache(model.EmpID);
            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = row
            };
        }
    }
}

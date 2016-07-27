/*********************************************************
 * FRXS chujl 2016/4/16 10:04:14
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 配送接口-登录
    /// </summary>
    [ActionName("DeliverLogin")]
    public class DeliverLoginAction : ActionBase<DeliverLoginAction.DeliverLoginActionRequestDto, DeliverLoginAction.DeliverLoginActionResponseDto>
    {
        /// <summary>
        /// 接口调用上传参数
        /// </summary>
        public class DeliverLoginActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 登录名
            /// </summary>
            [Required]
            public string UserAccount { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            [Required]
            public string UserPwd { get; set; }

            /// <summary>
            /// 用户类型(1:拣货员;2:配送员;3:装箱员;4:采购员)
            /// </summary>
            [Required]
            public string UserType { get; set; }
        }

        /// <summary>
        /// 接口调用返回参数
        /// </summary>
        public class DeliverLoginActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 员工编号
            /// </summary>
            public int EmpID { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>
            public string EmpName { get; set; }

            /// <summary>
            /// 网仓编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 用户联络手机号码
            /// </summary>
            public string UserMobile { get; set; }

            /// <summary>
            /// 是否是组长
            /// </summary>
            public int IsMaster { get; set; }

            /// <summary>
            /// 是否冻结
            /// </summary>
            public int IsFrozen { get; set; }

            /// <summary>
            /// 是否锁定
            /// </summary>
            public int IsLocked { get; set; }

            /// <summary>
            /// 是否删除
            /// </summary>
            public int IsDeleted { get; set; }

            /// <summary>
            /// 配送线路集合
            /// </summary>
            public string LineIDs { get; set; }

            /// <summary>
            /// 是否删除
            /// </summary>
            public string PasswordSalt { get; set; }

            /// <summary>
            /// 是否删除
            /// </summary>
            public string UserGuid { get; set; }

            /// <summary>
            /// 用户账号
            /// </summary>
            public string UserAccount { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            public string UserPwd { get; set; }

            /// <summary>
            /// 所属仓库ID
            /// </summary>
            public int WareHouseWID { get; set; }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<DeliverLoginActionResponseDto> Execute()
        {
            string strMsg;
            //获取账户
            string strUserAccount = this.RequestDto.UserAccount;
            //获取密码
            string strUserPwd = this.RequestDto.UserPwd;
            string strUserType = this.RequestDto.UserType;
            WarehouseEmpInfo modelWarehouseEmp = WarehouseEmpBLO.DeliverLogin(strUserAccount, Utils.StrToInt(strUserType, 0));

            if (modelWarehouseEmp == null)
            {
                strMsg = "没有此用户信息";
                return base.ErrorActionResult(strMsg);
            }

            if (modelWarehouseEmp.IsDeleted == 1)
            {
                strMsg = "此帐号已删除";
                return base.ErrorActionResult(strMsg);
            }
            if (modelWarehouseEmp.IsFrozen == 1)
            {
                strMsg = "此帐号已冻结";
                return base.ErrorActionResult(strMsg);
            }
            if (modelWarehouseEmp.IsLocked == 1)
            {
                strMsg = "此帐号已锁定";
                return base.ErrorActionResult(strMsg);
            }
            #region 参数

            var searchCondition = new Dictionary<string, object>()
               .Append("EmpID", modelWarehouseEmp.EmpID);

            IList<Model.WarehouseLine> linelist = WarehouseLineBLO.GetList(searchCondition);
            string idstr = "";
            IList<int> idlist = linelist.Select(obj => obj.LineID).ToList();
            if (idlist.Any())
            {
                idstr = string.Join(",", idlist);
            }
            #endregion

            string strToPwd = strUserPwd + modelWarehouseEmp.PasswordSalt;
            string strMd5ToPwd = Utils.MD5(strToPwd);//MD5加密后密码
            if (!strMd5ToPwd.ToUpper().Equals(modelWarehouseEmp.Password.ToUpper()))
            {
                strMsg = "密码输入错误";
                return base.ErrorActionResult(strMsg);
            }
            strMsg = "登录成功";
            DeliverLoginActionResponseDto modelDeliverLoginResponse = new DeliverLoginActionResponseDto();
            modelDeliverLoginResponse.EmpID = modelWarehouseEmp.EmpID;
            modelDeliverLoginResponse.EmpName = modelWarehouseEmp.EmpName;
            modelDeliverLoginResponse.WID = modelWarehouseEmp.WID;
            modelDeliverLoginResponse.IsMaster = modelWarehouseEmp.IsMaster;
            modelDeliverLoginResponse.UserMobile = modelWarehouseEmp.UserMobile;
            modelDeliverLoginResponse.IsDeleted = modelWarehouseEmp.IsDeleted;
            modelDeliverLoginResponse.IsFrozen = modelWarehouseEmp.IsFrozen;
            modelDeliverLoginResponse.IsLocked = modelWarehouseEmp.IsLocked;
            modelDeliverLoginResponse.LineIDs = idstr;
            modelDeliverLoginResponse.PasswordSalt = modelWarehouseEmp.PasswordSalt;
            modelDeliverLoginResponse.UserGuid = Guid.NewGuid().ToString();
            modelDeliverLoginResponse.UserAccount = this.RequestDto.UserAccount;
            modelDeliverLoginResponse.UserPwd = this.RequestDto.UserPwd;
            modelDeliverLoginResponse.WareHouseWID = modelWarehouseEmp.WareHouseWID;
            return base.SuccessActionResult(strMsg, modelDeliverLoginResponse);
        }
    }
}

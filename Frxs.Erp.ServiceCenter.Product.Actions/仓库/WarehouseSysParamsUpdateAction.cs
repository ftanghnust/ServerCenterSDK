using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/23 14:50:31
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 更新仓库业务参数设置；前端调用直接根据返回的flag=0来判断是否成功
    /// </summary>
    [ActionName("Warehouse.SysParams.Update"), UnloadCachekeys("Frxs.SysParams")]
    public class WarehouseSysParamsUpdateAction : ActionBase<WarehouseSysParamsUpdateAction.WarehouseSysParamsUpdateActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WarehouseSysParamsUpdateActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号，必须传入
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 参数编码，必须传入
            /// </summary>
            [Required, StringLength(32)]
            public string ParamCode { get; set; }

            /// <summary>
            /// 参数业务配置值，必须传入
            /// </summary>
            [Required, StringLength(32)]
            public string ParamValue { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                double d = 0;
                double.TryParse(this.ParamValue, out d);

                //日结的业务参数是字符串型，这里不能这样验证
                if (this.ParamCode != "008"&&!double.TryParse(this.ParamValue, out d))
                {
                    yield return new RequestDtoValidatorResultError("参数值应为数字");
                }

                //自动收货时间（小时）
                if (this.ParamCode == "001" && (d < 0 || d > 1))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-1之间");
                }

                //默认物流费率
                if (this.ParamCode == "002" && (d < 0 || d > 1))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-1之间");
                }

                //默认仓储费率
                if (this.ParamCode == "003" && (d < 0 || d > 1))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue","数据必须在0-1之间");
                }

                //默认平台费率
                if (this.ParamCode == "004" && (d < 0 || d > 1))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-1之间");
                }

                //默认门店积分
                if (this.ParamCode == "005" && (d < 0 || d > 10000))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-10000之间");
                }

                //默认绩效分率
                if (this.ParamCode == "006" && (d < 0 || d > 100))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-100之间");
                }

                //系统最新消息默认值
                if (this.ParamCode == "007" && (d < 0 || d > 1000))
                {
                    yield return new RequestDtoValidatorResultError("ParamValue", "数据必须在0-1000之间");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取指定参数配置
            ISysParamsWHDAO iSysParamsWh = DALFactory.GetLazyInstance<ISysParamsWHDAO>();
            var @params = iSysParamsWh.GetWHSysParams(this.RequestDto.WID, this.RequestDto.ParamCode).ToList();

            //参数不存在
            if (@params.IsNull() || @params.IsEmpty())
            {
                return this.ErrorActionResult("参数{0}不存在".With(this.RequestDto.ParamCode));
            }

            //判断仓库是否已经设置了参数配置
            var sysParamsWh = iSysParamsWh.GetModel(new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ParamCode", this.RequestDto.ParamCode));

            //未配置就添加
            if (sysParamsWh.IsNull())
            {
                iSysParamsWh.Save(new SysParamsWH()
                {
                    ModifyTime = DateTime.Now,
                    ModifyUserID = this.RequestDto.UserId,
                    ModifyUserName = this.RequestDto.UserName,
                    WID = this.RequestDto.WID,
                    ParamCode = this.RequestDto.ParamCode,
                    ParamValue = this.RequestDto.ParamValue
                });
            }
            //添加了修改配置
            else
            {
                sysParamsWh.ParamValue = this.RequestDto.ParamValue;
                sysParamsWh.ModifyTime = DateTime.Now;
                sysParamsWh.ModifyUserID = this.RequestDto.UserId;
                sysParamsWh.ModifyUserName = this.RequestDto.UserName;
                iSysParamsWh.Edit(sysParamsWh);
            }

            //配置成功
            return this.SuccessActionResult();
        }

    }
}

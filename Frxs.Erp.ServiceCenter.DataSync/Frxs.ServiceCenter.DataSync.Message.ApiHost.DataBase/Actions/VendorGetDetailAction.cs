using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 同步接口
    /// </summary>
    [ActionName("Vendor.Get.Detail")]
    public class VendorGetDetailAction : ActionBase<VendorGetDetailAction.VendorGetActionDetailRequestDto, VendorGetDetailAction.VendorGetActionDetailActionResponseDto>
    {


        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class VendorGetActionDetailRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.int
            /// </summary>
            public Int32 VendorID { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class VendorGetActionDetailActionResponseDto
        {
            /// <summary>
            /// 商品信息
            /// </summary>
            public Models.Vendor Vendor { get; set; }


            /// <summary>
            /// 商品规格属性
            /// </summary>
            public List<Models.VendorWarehouse> VendorWarehouses { get; set; }


        }


        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.Vendor> _vendorRepository;

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Models.VendorWarehouse> _vendorWarehouseRepository;

        private readonly IDbContext _dbContext;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="vendorRepository">数据访问仓储</param>
        /// <param name="vendorWarehouseRepository"> </param>
        /// <param name="dbContext">数据操作上下文</param>
        public VendorGetDetailAction(IRepository<Models.Vendor> vendorRepository,
            IRepository<Models.VendorWarehouse> vendorWarehouseRepository,
            IDbContext dbContext)
        {
            this._vendorRepository = vendorRepository;
            this._vendorWarehouseRepository = vendorWarehouseRepository;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<VendorGetActionDetailActionResponseDto> Execute()
        {
            var vendor = this._vendorRepository.TableNoTracking.FirstOrDefault(o => o.VendorID == this.RequestDto.VendorID);
            var vendorWarehouses = this._vendorWarehouseRepository.TableNoTracking.Where(o => o.VendorID == this.RequestDto.VendorID).ToList();
            //输出对象
            var responseDto = new VendorGetActionDetailActionResponseDto()
            {
                Vendor = vendor,
                VendorWarehouses = vendorWarehouses
            };
            //返回消息
            return this.SuccessActionResult(responseDto);
        }
    }
}
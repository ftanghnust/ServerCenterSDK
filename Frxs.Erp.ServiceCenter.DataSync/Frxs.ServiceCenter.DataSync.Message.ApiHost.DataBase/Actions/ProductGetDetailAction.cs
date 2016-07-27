using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Actions
{
    /// <summary>
    /// 商品获取功能(所有相关联的数据读取) 领域模型
    /// </summary>
    [ActionName("Product.Get.Detail")]
    public class ProductGetDetailAction : ActionBase<ProductGetDetailAction.ProductGetDetailActionRequestDto, ProductGetDetailAction.ProductGetDetailActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ProductGetDetailActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// SqlServer.int
            /// </summary>
            public Int32 ProductId { get; set; }
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
        public class ProductGetDetailActionResponseDto
        {
            /// <summary>
            /// 商品信息
            /// </summary>
            public Product Product { get; set; }
            /// <summary>
            /// 母商品
            /// </summary>
            public BaseProduct BaseProduct { get; set; }

            /// <summary>
            /// 商品规格属性
            /// </summary>
            public List<ProductsAttribute> ProductsAttributes { get; set; }

            /// <summary>
            /// 商品规格图片
            /// </summary>
            public ProductsAttributesPicture ProductsAttributesPicture { get; set; }

            /// <summary>
            /// 商品国际条码
            /// </summary>
            public List<ProductsBarCode> ProductsBarCodes { get; set; }

            /// <summary>
            /// 商品描述
            /// </summary>
            public ProductsDescription ProductsDescription { get; set; }

            /// <summary>
            /// 商品描述图片
            /// </summary>
            public List<ProductsDescriptionPicture> ProductsDescriptionPictures { get; set; }

            /// <summary>
            /// 商品详情图片
            /// </summary>
            public List<ProductsPictureDetail> ProductsPictureDetails { get; set; }

            /// <summary>
            /// 商品单位
            /// </summary>
            public List<ProductsUnit> ProductsUnits { get; set; }

            /// <summary>
            /// 商品供应商
            /// </summary>
            public List<ProductsVendor> ProductsVendors { get; set; }

        }

        /// <summary>
        /// 商品 数据访问仓储
        /// </summary>
        private readonly IRepository<Models.Product> _productRepository;
        private readonly IRepository<Models.BaseProduct> _baseProductRepository;
        private readonly IRepository<Models.ProductsAttribute> _productsAttributeRepository;
        private readonly IRepository<Models.ProductsAttributesPicture> _productAttributesPictureRepository;
        private readonly IRepository<Models.ProductsBarCode> _productBarCodeRepository;
        private readonly IRepository<Models.ProductsPictureDetail> _productsPictureDetailRepository;
        private readonly IRepository<Models.ProductsDescription> _productDescriptionRepository;
        private readonly IRepository<Models.ProductsDescriptionPicture> _productDescriptionPictureRepository;
        private readonly IRepository<Models.ProductsUnit> _productUnitRepository;
        private readonly IRepository<Models.ProductsVendor> _productVendorRepository;
        private readonly IDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="productRepository">商品 数据访问仓储</param>
        /// <param name="baseProductRepository"> 母商品 数据访问仓储</param>
        /// <param name="productsAttributeRepository">商品规格属性 数据访问仓储</param>
        /// <param name="productAttributesPictureRepository">商品规格属性图片 数据访问仓储</param>
        /// <param name="productBarCodeRepository">商品条码 数据访问仓储</param>
        /// <param name="productsPictureDetailRepository">商品主图  数据访问仓储</param>
        /// <param name="productDescriptionRepository">母商品文字详情  数据访问仓储</param>
        /// <param name="productDescriptionPictureRepository">母商品图片详情 数据访问仓储</param>
        /// <param name="productUnitRepository">商品单位 数据访问仓储 </param>
        /// <param name="productVendorRepository">商品供应商  数据访问仓储</param>
        /// <param name="dbContext">数据操作上下文</param>
        /// <param name="unitOfWork">工作单元</param>
        public ProductGetDetailAction(
            IRepository<Models.Product> productRepository,
            IRepository<Models.BaseProduct> baseProductRepository,
            IRepository<Models.ProductsAttribute> productsAttributeRepository,
            IRepository<Models.ProductsAttributesPicture> productAttributesPictureRepository,
            IRepository<Models.ProductsBarCode> productBarCodeRepository,
            IRepository<Models.ProductsPictureDetail> productsPictureDetailRepository,
            IRepository<Models.ProductsDescription> productDescriptionRepository,
            IRepository<Models.ProductsDescriptionPicture> productDescriptionPictureRepository,
            IRepository<Models.ProductsUnit> productUnitRepository,
            IRepository<Models.ProductsVendor> productVendorRepository,
            IDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._baseProductRepository = baseProductRepository;
            this._productsAttributeRepository = productsAttributeRepository;
            this._productAttributesPictureRepository = productAttributesPictureRepository;
            this._productBarCodeRepository = productBarCodeRepository;
            this._productsPictureDetailRepository = productsPictureDetailRepository;
            this._productDescriptionRepository = productDescriptionRepository;
            this._productDescriptionPictureRepository = productDescriptionPictureRepository;
            this._productUnitRepository = productUnitRepository;
            this._productVendorRepository = productVendorRepository;
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 执行业务逻辑方法
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductGetDetailActionResponseDto> Execute()
        {
            var product = this._productRepository.TableNoTracking.FirstOrDefault(o => o.ProductId == this.RequestDto.ProductId);
            var baseProduct = this._baseProductRepository.TableNoTracking.FirstOrDefault(o => o.BaseProductId == product.BaseProductId);
            var productsAttributes = this._productsAttributeRepository.TableNoTracking.Where(o => o.ProductId == product.ProductId).ToList();
            var productsAttributesPicture =
                this._productAttributesPictureRepository.TableNoTracking.FirstOrDefault(
                    o => o.ProductId == product.ProductId);

            var productsBarCodes = this._productBarCodeRepository.TableNoTracking.Where(o => o.ProductId == product.ProductId).ToList();
            var productsDescription =
                this._productDescriptionRepository.TableNoTracking.FirstOrDefault(
                    o => o.BaseProductId == product.BaseProductId);

            var productsDescriptionPictures =
                this._productDescriptionPictureRepository.TableNoTracking.Where(
                    o => o.BaseProductId == product.BaseProductId).ToList();
            var productsPictureDetails =
                this._productsPictureDetailRepository.TableNoTracking.Where(o => o.ImageProductId == product.ProductId).
                    ToList();

            var productsUnits =
                this._productUnitRepository.TableNoTracking.Where(o => o.ProductID == product.ProductId).ToList();

            var productsVendors =
                this._productVendorRepository.TableNoTracking.Where(o => o.ProductId == product.ProductId).ToList();

            //输出对象
            var responseDto = new ProductGetDetailActionResponseDto()
            {
                Product = product,
                BaseProduct = baseProduct,
                ProductsAttributes = productsAttributes,
                ProductsAttributesPicture = productsAttributesPicture,
                ProductsBarCodes = productsBarCodes,
                ProductsDescription = productsDescription,
                ProductsDescriptionPictures = productsDescriptionPictures,
                ProductsPictureDetails = productsPictureDetails,
                ProductsUnits = productsUnits,
                ProductsVendors = productsVendors
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
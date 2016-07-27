/********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 4:04:21 PM
 * *****************************************************/
using System;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 核心类，接口action抽象类；所有外部实现的接口都需要继承此类
    /// 注意：上送参数和下送数据不支持字典对象数据类型，能够用简易数据类型表达的，尽量用简易数据类型
    /// </summary>
    /// <typeparam name="TRequestDto">
    /// 客户端上传Data参数JSON反序列化后对应的对象，此对象必须是继承于RequestDtoBase类的一个实体类
    /// 命名约定规则为：接口类名+RequestDto。如果需要校验客户端UserId和UserName是
    /// 否提交，实现类里请继承接口：IRequiredUserIdAndUserName，这样系统框架会在执行前先校验参数的
    /// 准确性，数据约束规则完全兼容命名空间System.ComponentModel.DataAnnotations下是所有特性。可
    /// 以方便的在上送参数对象属性上定义特性的方式来进行数据验证
    /// </typeparam>
    /// <typeparam name="TResponseDto">
    /// 输出ActionResult.Data对象，就可以是任意的输出DTO类型，没有对此类型进行泛型约束
    /// 如果此泛型类型指定为：NullResponseDto，系统自动生成SDK开发包的时候，将不会生成返回输出类
    /// 注意:尽量不要将此类型定义成object类型，要不框架无法自动生成SDK开发包（客户端需要手工进行处理）
    /// 集合类型请尽量使用List数据类型方便系统框架自动完成SDK输出（注意：不支持字典，字典可以使用集合来替代）
    /// </typeparam>
    public abstract class ActionBase<TRequestDto, TResponseDto> : IAction, IActionFilter, IDisposable
        where TRequestDto : RequestDtoBase, new()
    {
        /// <summary>
        /// 默认构造一个空的记录器，并且初始化一个空的日志记录器和一个空的缓存器
        /// </summary>
        protected ActionBase()
        {
            this.Logger = NullLogger.Instance;
            this.CacheManager = NullCacheManager.Instance;
        }

        /// <summary>
        /// 用于记录日志，系统默认使用了空记录日志，如果需要使用其他日志记录器，比如将日志记录到数据库或者其他存储介质
        /// 请在外部实现ILogger接口，然后注入覆盖系统默认的记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// API框架提供的缓存接口，具体实现请在外部实现具体的缓存实现(这里系统框架未实现任何缓存);
        /// 在进行具体的使用过程中，由于有可能会缓存键会引起冲突，建议缓存键使用this.GetType().FullName加具体缓存键来实现键的冲突或者在外部定义好预定义的键，供具体实现类里调用
        /// 由于接口层并不知道数据库的实体对象变化，因此建议在接口层使用缓存一般是在预知变化不会太频繁的情况下使用，其他情况下慎用；或者在实体增加，修改，删除的时候，全部做缓存设置，删除操作
        /// </summary>
        public ICacheManager CacheManager { get; set; }

        /// <summary>
        /// 当前action请求上下文信息(系统框架会自动赋值)
        /// </summary>
        public RequestContext RequestContext { get; set; }

        /// <summary>
        /// 当前action请求描述信息(系统框架会自动赋值)
        /// </summary>
        public ActionDescriptor ActionDescriptor { get; set; }

        /// <summary>
        /// 获取接口描述管理器
        /// </summary>
        protected ActionDocResourceManager ActionDocResourceManager
        {
            get
            {
                return ActionDocResourceManager.Instance;
            }
        }

        /// <summary>
        /// 上送的参数（此参数系统在参加action实例的时候，会自动根据上送的参数进行绑定赋值）
        /// 此属性与强类型的RequestDto属性数据保持一致
        /// </summary>
        object IAction.RequestDto { get; set; }

        /// <summary>
        /// 上送的参数（此参数系统在参加action实例的时候，会自动根据上送的参数进行绑定赋值）
        /// 注意：当上送的JSON格式不正确的时候，系统框架会自动抛出异常，无需处理；因此此属性一定有返回值
        /// </summary>
        protected TRequestDto RequestDto
        {
            get
            {
                //获取接口请求参数对象
                var requestDto = (this as IAction).RequestDto;

                //为空直接返回默认值
                if (requestDto.IsNull())
                {
                    return default(TRequestDto);
                }

                //转型成功，直接返回泛型模板对象
                if (requestDto is TRequestDto)
                {
                    return (TRequestDto)requestDto;
                }

                //返回泛型模板类型默认值
                return default(TRequestDto);
            }
        }

        /// <summary>
        /// 校验上送的参数是否正确（默认会校验是否为null）；失败会直接抛出异常，系统框架会自动捕捉到此异常
        /// 此方法在框架执行action.Executing()方法里会自动进行调用，如果需要改变上送参数对象数据校验，请在重写类里重写此方法即可，但是一般情况下无需重写
        /// </summary>
        protected virtual void ValidRequestDto()
        {
            //0.上送的参数对象不能为空
            if (this.RequestDto.IsNull())
            {
                throw new ApiException(Resource.CoreResource.ActionBase_RequestDto_Null);
            }

            //1.如果RequestDto继承了IRequestDtoValidatable或者添加了特性校验
            //var requestDtoValidatorResult = new RequestDtoValidator().Valid(this.RequestDto, this.ActionDescriptor);

            var requestDtoValidatorResult = ServicesContainer.Current.Resolver<IRequestDtoValidatorManager>()
                .Valid(this.RequestDto, this.ActionDescriptor);

            //校验失败，直接抛出异常
            if (!requestDtoValidatorResult.IsValid)
            {
                throw new ApiException(string.Join(" | ", requestDtoValidatorResult.Errors.Select(item => "{0}:{1}".With(item.MemberName, item.ErrorMessage))));
            }
        }

        /// <summary>
        /// 获取当前请求获取缓存键信息，方便重写实现类里直接使用
        /// 只要接口名称和提交的数据包不变，生成的那么缓存键就不会变化，因此实现针对不同接口和不同请求数据包进行缓存
        /// 具体计算方式为：ActionName + "." + subCacheKey + "." + Units.MD5(Data + Format).ToUpper();
        /// </summary>
        /// <param name="subCacheKey">同一操作上下文，有可能需要不同的子缓存键；可以增加子缓存键，防止冲突</param>
        /// <returns>返回本次请求缓存键</returns>
        protected string GetRequestCacheKey(string subCacheKey = "")
        {
            return this.RequestContext.GetRequestCacheKey(subCacheKey);
        }

        /// <summary>
        /// 语言资源文件的读取；内部使用XML资源文件；
        /// 参数1为资源文件的键，自定义的语言资源包请使用接口的ActionName来作为节点名称，此委托会自动使用接口名称来构造键；KEY只要输入对应接口语言文件key节点名称即可
        /// 参数2为在资源文件找不到的情况下，默认显示的信息；
        /// 返回值为读取到的键值信息；
        /// 资源文件的格式为：请参见：Host/Config/LanguageResource.xml
        /// 调用如：this.L("Exist_S","删除 {0} 出错，当前状态为：{1}" , "001", "已确定")
        /// </summary>
        protected Localizer L
        {
            get
            {
                return (resourceKey, defaultValue, args) =>
                {
                    //获取语言包
                    var languageResourceManager = LanguageResourceManager.Instance;

                    //语言包不存在
                    if (languageResourceManager.IsNull())
                    {
                        return defaultValue ?? string.Empty;
                    }

                    //key为空，直接返回默认的说明
                    if (resourceKey.IsNullOrEmpty())
                    {
                        return defaultValue ?? string.Empty;
                    }

                    //构造资源的key值;（忽略大小写）
                    string key = "{0}".With(resourceKey);

                    //如果没有以接口名称开头，就自动将接口名称附加到前缀
                    if (!resourceKey.StartsWith(this.ActionDescriptor.ActionName, StringComparison.OrdinalIgnoreCase))
                    {
                        key = "{0}.{1}".With(this.ActionDescriptor.ActionName, resourceKey);
                    }

                    //获取资源
                    string value = languageResourceManager.GetLanguageResourceValue(key, defaultValue);

                    //含有参数就进行格式化
                    return args.IsNull() || args.Length == 0 ? value : value.With(args);
                };
            }
        }

        /// <summary>
        /// 框架异常错误的ActionResult对象
        /// 对象默认的参数为： Flag = ActionResultFlag.EXCEPTION
        /// </summary>
        /// <param name="info">异常消息</param>
        /// <returns></returns>
        protected ActionResult<TResponseDto> ExceptionActionResult(string info)
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.EXCEPTION, Info = info };
        }

        /// <summary>
        /// 直接返回错误的ActionResult对象（此方法仅仅是为了实现类里方便调用返回）
        /// 对象默认参数为：Flag = ActionResultFlag.FAIL
        /// </summary>
        /// <param name="info">输出的错误消息</param>
        /// <returns>直接返回一个Flag = ActionResultFlag.FAIL的接口返回值对象</returns>
        protected ActionResult<TResponseDto> ErrorActionResult(string info)
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.FAIL, Info = info };
        }

        /// <summary>
        /// 直接返回错误的ActionResult对象（此方法仅仅是为了实现类里方便调用返回）
        /// </summary>
        /// <param name="info">输出的错误消息</param>
        /// <param name="data">返回的一些数据(会被序列化成JSON或者XML格式输出给客户端)</param>
        /// <returns>直接返回一个Flag = ActionResultFlag.FAIL的接口返回值对象</returns>
        protected ActionResult<TResponseDto> ErrorActionResult(string info, TResponseDto data)
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.FAIL, Info = info, Data = data };
        }

        /// <summary>
        /// 请求参数未提交错误ActionResult对象（此方法仅仅是为了方便实现类里方便调用返回）
        /// </summary>
        /// <param name="argumentName">参数名称</param>
        /// <returns>返回一个现实错误的ActionResult对象</returns>
        protected ActionResult<TResponseDto> ArgumentNullErrorActionResult(string argumentName)
        {
            return new ActionResult<TResponseDto>()
            {
                Flag = ActionResultFlag.FAIL,
                Info = Resource.CoreResource.ActionBase_ArgumentNullErrorActionResult_Info.With(argumentName)
            };
        }

        /// <summary>
        /// 此方法仅仅用于返回一个不带任何返回值的ActionResult对象
        /// 对象默认参数为：Flag = ActionResultFlag.SUCCESS, Info = "OK"
        /// </summary>
        /// <returns></returns>
        protected ActionResult<TResponseDto> SuccessActionResult()
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.SUCCESS, Info = "OK" };
        }

        /// <summary>
        /// 此方法用于返回一个成功的消息ActionResult对象
        /// 对象默认参数为：Flag = ActionResultFlag.SUCCESS, Info = "OK"
        /// </summary>
        /// <param name="data">需要返回给客户端的对象，会格式化成XML或者JSON</param>
        /// <returns></returns>
        protected ActionResult<TResponseDto> SuccessActionResult(TResponseDto data)
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.SUCCESS, Info = "OK", Data = data };
        }

        /// <summary>
        /// 此方法用于返回一个成功的消息ActionResult对象
        /// 对象默认参数为：Flag = ActionResultFlag.SUCCESS
        /// </summary>
        /// <param name="info">成功消息说明</param>
        /// <param name="data">需要返回给客户端的对象，会格式化成XML或者JSON</param>
        /// <returns></returns>
        protected ActionResult<TResponseDto> SuccessActionResult(string info, TResponseDto data)
        {
            return new ActionResult<TResponseDto>() { Flag = ActionResultFlag.SUCCESS, Info = info, Data = data };
        }

        /// <summary>
        /// 显式实现下接口，防止子类里出现，调用的时候出现意外
        /// 开始执行接口自定义的业务逻辑前，先执行下框架内部定义的一些判断
        /// 此方法在内部调用过来受保护的ValidRequestDto()方法，用于校验上送参数对象的正确性；
        /// </summary>
        void IAction.Executing()
        {
            this.ValidRequestDto();
        }

        /// <summary>
        /// 显式实现接口，此接口仅仅只调用泛型版本的方法
        /// </summary>
        /// <returns></returns>
        ActionResult<object> IAction.Execute()
        {
            //执行外部定义的主方法
            var actionResult = this.Execute();

            //返回执行对象，转型成object类型
            return new ActionResult<object>()
            {
                Data = actionResult.Data,
                Flag = actionResult.Flag,
                Info = actionResult.Info
            };
        }

        /// <summary>
        ///  泛型执行接口，系统框架执行的时候会自动调用此方法
        ///  此方法必须在具体接口实现类里重写
        /// </summary>
        /// <returns></returns>
        public abstract ActionResult<TResponseDto> Execute();

        /// <summary>
        /// 执行：Execute() 方法前执行
        /// </summary>
        /// <param name="actionExecutingContext">
        /// 拦截器执行上下文，接口执行前拦截器，如果ActionExecutingContext.Result属性不为null，
        /// 则代表拦截成功(如要需要进行拦截，请在方法体内将ActionExecutingContext.Result属性赋值即可)，不会继续执行Execute()方法
        /// 保存默认值null，则代表不拦截，继续后续的流程执行
        /// </param>
        protected virtual void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
        }

        /// <summary>
        /// 显式实现下执行前触发的事件，方便以后扩展（系统框架里做一些事情）
        /// </summary>
        /// <param name="actionExecutingContext">拦截器执行上下文</param>
        void IActionFilter.OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            this.OnActionExecuting(actionExecutingContext);
        }

        /// <summary>
        /// 执行：Execute() 方法后执行
        /// </summary>
        /// <param name="actionExecutedContext">拦截器执行上下文</param>
        protected virtual void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
        }

        /// <summary>
        /// 显式实现下执行后触发的事件，方便以后扩展（系统框架里做一些事情）
        /// </summary>
        /// <param name="actionExecutedContext">拦截器执行上下文</param>
        void IActionFilter.OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            #region 先处理下需要清理的缓存键

            if (!this.ActionDescriptor.UnloadCacheKeys.IsNull() && this.ActionDescriptor.UnloadCacheKeys.Length > 0)
            {
                //启动匹配缓存键的方式，删除相关缓存键
                foreach (var unloadCacheKey in this.ActionDescriptor.UnloadCacheKeys)
                {
                    try
                    {
                        this.CacheManager.RemoveByPattern(unloadCacheKey);
                        this.Logger.Debug("清理缓存匹配键：{0} 成功".With(unloadCacheKey));
                    }
                    catch (Exception ex)
                    {
                        this.Logger.Error(ex);
                    }
                }
            }

            #endregion

            //执行完所有的事件之后
            this.OnActionExecuted(actionExecutedContext);
        }

        /// <summary>
        /// 基类默认实现下IDispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 具体接口实现类可以重写此方法，系统框架在执行完接口后，会自动调用此方法
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) { }
    }
}
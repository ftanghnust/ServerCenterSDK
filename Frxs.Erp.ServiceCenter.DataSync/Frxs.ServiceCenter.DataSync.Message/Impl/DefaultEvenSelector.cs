/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 4:19:56 PM
 * *******************************************************/
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 事件名称和事件消息体映射关系管理器
    /// </summary>
    internal class DefaultEvenSelector : IEvenSelector, IStartUp
    {
        /// <summary>
        /// 缓存映射信息
        /// </summary>
        private static readonly IList<EventDescriptor> CachedMapping = new List<EventDescriptor>();
        private static bool _initializationed = false;
        private static readonly object Locker = new object();

        /// <summary>
        /// 
        /// </summary>
        private ITypeFinder _typeFinder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeFinder">类型查找器</param>
        public DefaultEvenSelector(ITypeFinder typeFinder)
        {
            typeFinder.CheckNullThrowArgumentNullException("typeFinder");
            this._typeFinder = typeFinder;
        }

        /// <summary>
        /// 获取所有的事件名称和body类型集合
        /// </summary>
        /// <returns>找不到返回空集合</returns>
        public IEnumerable<EventDescriptor> GetEventDescriptors()
        {
            //还未初始化
            if (_initializationed)
            {
                return CachedMapping;
            }

            lock (Locker)
            {
                if (_initializationed)
                {
                    return CachedMapping;
                }

                //已经初始化了标志
                _initializationed = true;

                //筛选所有事件定义
                this._typeFinder.FindClassesOfType(typeof(IEvent))
                    .Where(type => !type.IsAbstract
                                    && type.IsDefined(typeof(SerializableAttribute), false)
                                    && type.IsDefined(typeof(EventGroupAttribute), false)
                                    && !type.Name.Contains("__"))
                    .OrderBy(o => o.Name).ToList().ForEach(type =>
                    {
                        //获取事件和摘要映射信息
                        var eventMessageBodyMapAttributes =
                                type.GetCustomAttributes(typeof(EventNameAttribute), false)
                                .Cast<EventNameAttribute>();

                        //事件名称
                        string eventName = string.Empty;

                        //不存在映射关系，直接使用类名称
                        if (!eventMessageBodyMapAttributes.Any())
                        {
                            eventName = type.Name.EndsWith("MessageBody", StringComparison.OrdinalIgnoreCase)
                                    ? type.Name.Substring(0, type.Name.Length - "MessageBody".Length) : type.Name;
                        }
                        //存在映射关系
                        else
                        {
                            eventName = eventMessageBodyMapAttributes.First().EventName;
                        }

                        //获取事件描述信息
                        var messageBodyDescriptor = CachedMapping.FirstOrDefault(o => o.EventName == eventName);

                        //不存在就添加到缓存
                        if (messageBodyDescriptor.IsNull())
                        {
                            //默认分组名称为事件名称
                            string groupName = string.Empty;
                            string subGroupName = eventName;

                            //获取分组信息
                            if (type.IsDefined(typeof(EventGroupAttribute), false))
                            {
                                var eventGroupAttribute = (EventGroupAttribute)type.GetCustomAttributes(
                                    typeof(EventGroupAttribute), false)[0];
                                groupName = eventGroupAttribute.GroupName;
                                subGroupName = eventGroupAttribute.SubGroupName;
                            }

                            //重要度(默认正常)
                            var eventDegree = Degree.Normal;
                            //如果定义了重要度，就使用自定义的
                            if (type.IsDefined(typeof(EventDegreeAttribute), false))
                            {
                                eventDegree = type.GetCustomAttributes(typeof(EventDegreeAttribute), false)
                                                           .Cast<EventDegreeAttribute>().First().Degree;
                            }

                            //事件参数默认为当前定义的类型
                            var messageBodyType = type;
                            if (type.IsDefined(typeof(EventArgsTypeAttribute), false))
                            {
                                messageBodyType = type.GetCustomAttributes(typeof(EventArgsTypeAttribute), false)
                                                      .Cast<EventArgsTypeAttribute>().First().Type;
                            }

                            //添加到缓存
                            CachedMapping.Add(new EventDescriptor()
                            {
                                EventName = eventName,
                                MessageBodyType = messageBodyType,
                                IsGloablEventMessage = type.IsDefined(typeof(GlobalEventAttribute), false),
                                GroupName = groupName,
                                SubGroupName = subGroupName,
                                EventDegree = eventDegree
                            });
                        }
                        else
                        {
                            //还原下操作
                            _initializationed = false;
                            CachedMapping.Clear();
                            throw new ApiException(Resource.Resource.DefaultEvenSelector_Topic_Existsed);
                        }
                    });
            }

            //返回接口集合
            return CachedMapping;
        }

        /// <summary>
        /// 根据事件名称获取事件的body类型
        /// </summary>
        /// <param name="eventName">事件名称（忽略大小写）</param>
        /// <returns>找不到会返回null</returns>
        public EventDescriptor GetEventDescriptor(string eventName)
        {
            return CachedMapping.FirstOrDefault(o => o.EventName.Equals(eventName,
                    StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 初始化一下，系统启动的时候
        /// </summary>
        public void Init()
        {
            this.GetEventDescriptors();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.WcfRegistration
{
    //<!--服务配置-->
    //    <add key="BookShop.Contract.IBook" value="http://127.0.0.1:3722/BookShopService;WSHttp;1"/>

    class ServiceFactory
    {
        public static T CreateService<T>() where T : class
        {
            try
            {
                ServiceInfo info = null;
                Type contract = typeof(T);
                if (ServiceInfoPool.HasInfo(contract))
                {
                    // 先从缓存里取服务信息
                    info = ServiceInfoPool.GetInfo(contract);
                }
                else
                {
                    // 如果缓存没有从配置文件里取
                    string infoStr = System.Configuration.ConfigurationManager.AppSettings[contract.FullName];
                    if (!string.IsNullOrEmpty(infoStr))
                    {
                        string[] infos = infoStr.Split(';');
                        EndpointAddress address = new EndpointAddress(infos[0]);
                        Binding binding = CreateBinding(infos[1]);
                        bool isRemote = infos[2] == "1";

                        info = new ServiceInfo(address, binding, contract, isRemote);
                        ServiceInfoPool.AddInfo(info);
                    }
                }

                T service = null;
                if (info != null && info.IsRemote)
                {
                    service = ChannelFactory<T>.CreateChannel(info.Bingding, info.Address);
                }
                else if (info == null || !info.IsRemote)
                {
                    // 如果缓存和配置都没有,或者是本地服务，则尝试从本地反射对象
                    string objName = contract.FullName.Substring(contract.FullName.LastIndexOf('.') + 2);

                    string fullName = "Justin.BookShop.Services." + objName;
                    Assembly ass = Assembly.Load("Justin.BookShop.Services");
                    service = (T)ass.CreateInstance(fullName);
                }
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("创建服务失败，详细信息:\r\n" + ex.Message);
            }
        }

        internal static Binding CreateBinding(string flag)
        {
            Binding binding = null;

            switch (flag)
            {
                case "NetTcp":
                    binding = new NetTcpBinding();
                    break;

                case "BasicHttp":
                    binding = new BasicHttpBinding();
                    break;

                case "WSHttp":
                    binding = new WSHttpBinding();
                    break;

                case "WSDualHttp":
                    binding = new WSDualHttpBinding();
                    break;

                case "WSFederationHttp":
                    binding = new WSFederationHttpBinding();
                    break;

                case "NetNamedPipe":
                    binding = new NetNamedPipeBinding();
                    break;

                case "NetMsmq":
                    binding = new NetMsmqBinding();
                    break;

                case "NetPeerTcp":
                    binding = new NetPeerTcpBinding();
                    break;

                case "MsmqIntegration":
                    binding = new System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding();
                    break;

                default:
                    binding = new NetTcpBinding();
                    break;
            }

            return binding;
        }
    }

    /// <summary>
    /// 缓存服务信息
    /// </summary>
    internal static class ServiceInfoPool
    {
        static Dictionary<Type, ServiceInfo> m_InnerPool = new Dictionary<Type, ServiceInfo>();

        internal static bool HasInfo(Type contract)
        {
            return m_InnerPool.ContainsKey(contract);
        }

        internal static void SetInfo(ServiceInfo info)
        {
            m_InnerPool[info.Contract] = info;
        }

        internal static ServiceInfo GetInfo(Type contract)
        {
            ServiceInfo info = null;
            if (m_InnerPool.ContainsKey(contract))
            {
                info = m_InnerPool[contract];
            }
            return info;
        }

        internal static ServiceInfo AddInfo(ServiceInfo info)
        {
            if (m_InnerPool.ContainsKey(info.Contract))
            {
                return m_InnerPool[info.Contract];
            }
            m_InnerPool.Add(info.Contract, info);
            return info;
        }
    }

    /// <summary>
    /// 服务终结点信息
    /// </summary>
    internal class ServiceInfo
    {
        internal ServiceInfo(EndpointAddress address, Binding binding, Type contract, bool isRemote)
        {
            this.Address = address;
            this.Bingding = binding;
            this.Contract = contract;
            this.IsRemote = isRemote;
        }

        /// <summary>
        /// 服务地址
        /// </summary>
        internal EndpointAddress Address
        {
            get;
            private set;
        }

        /// <summary>
        /// 绑定
        /// </summary>
        internal Binding Bingding
        {
            get;
            private set;
        }

        /// <summary>
        /// 协定
        /// </summary>
        internal Type Contract
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否远程调用服务
        /// </summary>
        internal bool IsRemote
        {
            get;
            private set;
        }
    }
}

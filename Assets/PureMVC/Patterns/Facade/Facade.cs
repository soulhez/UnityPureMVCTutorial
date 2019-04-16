
using System;
using PureMVC.Interfaces;
using PureMVC.Core;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Facade
{
    public class Facade : IFacade
    {
        public Facade()
        {
            if (instance != null) throw new Exception(Singleton_MSG);
            instance = this;
            InitializeFacade();
        }
        /// <summary>
        /// 初始化Facade类
        /// </summary>
        protected virtual void InitializeFacade()
        {
            InitializeModel();
            InitializeController();
            InitializeView();
        }

        public static IFacade GetInstance(Func<IFacade> facadeFunc)
        {
            if (instance == null)
            {
                instance = facadeFunc();
            }
            return instance;
        }
        /// <summary>
        /// 初始化Controller类
        /// </summary>
        protected virtual void InitializeController()
        {
            controller = Controller.GetInstance(() => new Controller());
        }
        /// <summary>
        /// 初始化Model类
        /// </summary>
        protected virtual void InitializeModel()
        {
            model = Model.GetInstance(() => new Model());
        }
        /// <summary>
        /// 初始化View类
        /// </summary>
        protected virtual void InitializeView()
        {
            view = View.GetInstance(() => new View());
        }
        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <param name="commandFunc">此委托返回需要执行的命令类</param>
        public virtual void RegisterCommand(string notificationName, Func<ICommand> commandFunc)
        {
            controller.RegisterCommand(notificationName, commandFunc);
        }
        /// <summary>
        /// 注册命令类
        /// </summary>
        /// <param name="notificationName"></param>
        public virtual void RemoveCommand(string notificationName)
        {
            controller.RemoveCommand(notificationName);
        }
        /// <summary>
        /// 时候含有命令
        /// </summary>
        /// <param name="notificationName">执行此命令消息的名称</param>
        /// <returns></returns>
        public virtual bool HasCommand(string notificationName)
        {
            return controller.HasCommand(notificationName);
        }
        /// <summary>
        /// 注册数据代理类
        /// </summary>
        /// <param name="proxy">对应代理类</param>
        public virtual void RegisterProxy(IProxy proxy)
        {
            model.RegisterProxy(proxy);
        }

        /// <summary>
        /// 检索数据代理类
        /// </summary>
        /// <param name="proxyName">数据代理类的名称</param>
        /// <returns></returns>
        public virtual IProxy RetrieveProxy(string proxyName)
        {
            return model.RetrieveProxy(proxyName);
        }
        /// <summary>
        /// 注销数据代理类
        /// </summary>
        /// <param name="proxyName">对应数据代理类的名称</param>
        /// <returns></returns>
        public virtual IProxy RemoveProxy(string proxyName)
        {
            return model.RemoveProxy(proxyName);
        }
        /// <summary>
        /// 判断是否含有数据代理类
        /// </summary>
        /// <param name="proxyName">数据代理类的名称</param>
        /// <returns></returns>
        public virtual bool HasProxy(string proxyName)
        {
            return model.HasProxy(proxyName);
        }
        /// <summary>
        /// 注册视图中介类
        /// </summary>
        /// <param name="mediator">中介类名称</param>
        public virtual void RegisterMediator(IMediator mediator)
        {
            view.RegisterMediator(mediator);
        }
        /// <summary>
        /// 检索视图中介类
        /// </summary>
        /// <param name="mediatorName">中介类名称</param>
        /// <returns></returns>
        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            return view.RetrieveMediator(mediatorName);
        }
        /// <summary>
        /// 注销视图中介类
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        public virtual IMediator RemoveMediator(string mediatorName)
        {
            return view.RemoveMediator(mediatorName);
        }
        /// <summary>
        /// 判断是否含有视图中介类
        /// </summary>
        /// <param name="mediatorName">视图中介类mingcheng</param>
        /// <returns></returns>
        public virtual bool HasMediator(string mediatorName)
        {
            return view.HasMediator(mediatorName);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="notificationName">消息名称</param>
        /// <param name="body">消息所带的数据</param>
        /// <param name="type">消息的类别</param>
        public virtual void SendNotification(string notificationName, object body = null, string type = null)
        {
            NotifyObservers(new Notification(notificationName, body, type));
        }
        /// <summary>
        /// 执行对应消息
        /// </summary>
        /// <param name="notification">消息体</param>
        public virtual void NotifyObservers(INotification notification)
        {
            view.NotifyObservers(notification);
        }

        /// <summary>
        /// Controller 核心
        /// </summary>
        protected IController controller;
        /// <summary>
        /// Model 核心
        /// </summary>
        protected IModel model;
        /// <summary>
        /// View 核心
        /// </summary>
        protected IView view;


        protected static IFacade instance;


        protected const string Singleton_MSG = "Facade Singleton already constructed!";
    }
}

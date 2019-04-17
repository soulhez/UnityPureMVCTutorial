using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator
{
    /// <summary>
    /// 视图对应的中介层
    /// </summary>
    public class Mediator : Notifier, IMediator, INotifier
    {
        /// <summary>
        /// 中介层名称
        /// </summary>
        public static string NAME = "Mediator";

        public Mediator(string mediatorName, object viewComponent = null)
        {
            MediatorName = mediatorName ?? Mediator.NAME;
            ViewComponent = viewComponent;
        }
        /// <summary>
        /// 此视图层需要关注的消息列表
        /// </summary>
        /// <returns></returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }
        /// <summary>
        /// 执行关注的消息列表触发时的回调
        /// </summary>
        /// <param name="notification"></param>
        public virtual void HandleNotification(INotification notification)
        {
        }
        /// <summary>
        /// 当此视图中介注册后立即触发
        /// </summary>
        public virtual void OnRegister()
        {
        }
        /// <summary>
        /// 当此视图中介注销后立即触发
        /// </summary>
        public virtual void OnRemove()
        {
        }
        /// <summary>
        /// 中介层名称
        /// </summary>
        public string MediatorName { get; protected set; }
        /// <summary>
        /// 对应的视图UI  也就是MonoBehaviour
        /// </summary>
        public object ViewComponent { get; set; }
    }
}

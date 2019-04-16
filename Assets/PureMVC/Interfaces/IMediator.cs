
namespace PureMVC.Interfaces
{
    /// <summary>
    /// 视图对应的中介类接口
    /// </summary>
    public interface IMediator: INotifier
    {
/// <summary>
/// 对应视图中介类的名称
/// </summary>
        string MediatorName { get; }
        /// <summary>
        /// 对应的视图UI  也就是MonoBehaviour
        /// </summary>
        object ViewComponent { get; set; }
        /// <summary>
        /// 此视图层中需要关注的消息列表
        /// </summary>
        /// <returns></returns>
        string[] ListNotificationInterests();
        /// <summary>
        /// 对此视图中关注消息相应的处理
        /// </summary>
        /// <param name="notification"></param>
        void HandleNotification(INotification notification);
        /// <summary>
        /// 当此视图层中介注册时触发
        /// </summary>
        void OnRegister();
        /// <summary>
        /// 当此视图层中介移除时触发
        /// </summary>
        void OnRemove();
    }
}

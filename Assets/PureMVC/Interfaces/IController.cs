//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;

namespace PureMVC.Interfaces
{
    /// <summary>
    /// The interface definition for a PureMVC Controller.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         In PureMVC, an <c>IController</c> implementor 
    ///         follows the 'Command and Controller' strategy, and 
    ///         assumes these responsibilities:
    ///         <list type="bullet">
    ///             <item>Remembering which <c>ICommand</c>s 
    ///             are intended to handle which <c>INotifications</c>.
    ///             </item>
    ///             <item>Registering itself as an <c>IObserver</c> with
    ///             the <c>View</c> for each <c>INotification</c> 
    ///             that it has an <c>ICommand</c> mapping for.
    ///             </item>
    ///             <item>Creating a new instance of the proper <c>ICommand</c> 
    ///             to handle a given <c>INotification</c> when notified by the <c>View</c>.
    ///             </item>
    ///             <item>Calling the <c>ICommand</c>'s <c>execute</c> 
    ///             method, passing in the <c>INotification</c>.
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso cref="INotification"/>
    /// <seealso cref="ICommand"/>
    public interface IController
    {
        void RegisterCommand(string notificationName, Func<ICommand> commandClassRef);

        void ExecuteCommand(INotification notification);

        void RemoveCommand(string notificationName);

        bool HasCommand(string notificationName);
    }
}

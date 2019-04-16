using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{
    /// <summary>
    /// 多命令类 持有多个SimpleCommand
    /// </summary>
    public class MacroCommand : Notifier, ICommand, INotifier
    {

        public MacroCommand()
        {
            subcommands = new List<Func<ICommand>>();
            InitializeMacroCommand();
        }

        protected virtual void InitializeMacroCommand()
        {
        }
        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="commandFunc">此委托返回需要执行的命令</param>
        protected void AddSubCommand(Func<ICommand> commandFunc)
        {
            subcommands.Add(commandFunc);
        }
        /// <summary>
        /// 执行持有的所有命令
        /// </summary>
        /// <param name="notification"></param>
        public virtual void Execute(INotification notification)
        {
            while(subcommands.Count > 0)
            {
                Func<ICommand> commandFunc = subcommands[0];
                ICommand commandInstance = commandFunc();
                commandInstance.Execute(notification);
                subcommands.RemoveAt(0);
            }
        }

        /// <summary>
        /// 持有命令列表
        /// </summary>
        public IList<Func<ICommand>> subcommands;
    }
}

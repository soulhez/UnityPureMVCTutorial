//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command
{

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

        protected void AddSubCommand(Func<ICommand> commandFunc)
        {
            subcommands.Add(commandFunc);
        }

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

        public IList<Func<ICommand>> subcommands;
    }
}

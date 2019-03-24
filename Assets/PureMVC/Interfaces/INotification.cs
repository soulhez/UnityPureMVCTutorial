//
//  PureMVC C# Standard
//
//  Copyright(c) 2017 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace PureMVC.Interfaces
{

    public interface INotification
    {

        string Name { get; }

        object Body { get; set; }

        string Type { get; set; }

        string ToString();
    }
}

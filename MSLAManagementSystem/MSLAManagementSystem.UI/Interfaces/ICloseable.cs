using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.Interfaces
{
    internal interface ICloseable
    {
        Action CloseWindow { get; set; }
        bool CanClose();
    }
}

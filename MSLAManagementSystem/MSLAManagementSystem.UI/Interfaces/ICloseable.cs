using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.Interfaces
{
    public interface ICloseable
    {
        Action CloseWindow { get; set; }
        bool CanClose();
    }
}

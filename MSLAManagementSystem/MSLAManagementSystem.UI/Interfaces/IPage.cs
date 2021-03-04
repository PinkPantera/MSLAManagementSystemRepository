using MSLAManagementSystem.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.Interfaces
{
    public interface IPage : ICloseable
    {
        PageKind PageKind { get; }
        string Caption { get; }
        void Refreshe();
    }
}

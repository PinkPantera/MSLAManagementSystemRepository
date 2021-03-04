using MSLAManagementSystem.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.Interfaces
{
    public interface IPageProvider
    {
        IPage GetPage(PageKind pageKind);
        IList<IPage> GetAllOpenedPages();
    }
}

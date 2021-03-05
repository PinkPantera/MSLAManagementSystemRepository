using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Interfaces
{
    public interface ISettings
    {
        string Url { get; }
        string UrlPerson { get; }
        string UrlAdress { get; }
    }
}

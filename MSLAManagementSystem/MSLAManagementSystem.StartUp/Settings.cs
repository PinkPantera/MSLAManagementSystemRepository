using MSLAManagementSystem.ClientDataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.StartUp
{
    public class Settings : ISettings
    {
        public string Url => "https://localhost:44376/api/";

        public string UrlPerson => string.Concat(Url, "Person");

        public string UrlAddress => string.Concat(Url, "Address");
    }
}

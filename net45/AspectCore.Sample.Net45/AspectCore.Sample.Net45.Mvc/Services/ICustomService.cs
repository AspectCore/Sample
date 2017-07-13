using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspectCore.Sample.Net45.Mvc.Services
{
    public interface ICustomService
    {
        string GetAboutMessage();

        string GetContactMessage();
    }

    public class CustomeService : ICustomService
    {
        public string GetAboutMessage()
        {
            return $"Your application description page . Current time is {DateTime.Now}";
        }

        public string GetContactMessage()
        {
            return $"Your contact page . Current time is {DateTime.Now}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNullOrEmptySample.Services
{
    public static class AppServiceExtensions
    {
        public static string CheckString(this IAppService appService, string str)
        {
            try
            {
                appService.ValidateNotNullOrEmpty(str);
                return $"CheckStringEmpty:Success";
            }
            catch (Exception ex)
            {
                return $"CheckStringEmpty:{ex.Message}";
            }
        }

        public static string CheckObject(this IAppService appService, object obj)
        {
            try
            {
                appService.ValidateNotNullOrEmpty(obj);
                return $"CheckObject:Success";
            }
            catch (Exception ex)
            {
                return $"CheckObject:{ex.Message}";
            }
        }

        public static string CheckNullalble<TStruct>(this IAppService appService, TStruct? source)
            where TStruct : struct
        {
            try
            {
                appService.ValidateNotNullOrEmpty(source);
                return $"CheckNullalble:Success";
            }
            catch (Exception ex)
            {
                return $"CheckNullalble:{ex.Message}";
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMarketAPI.ExtensionMethod
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key,object value)
        {
            string objectstring = JsonConvert.SerializeObject(value);
            session.SetString(key, objectstring);
        }

        public static T GetObject<T>(this ISession session,string key) where T:class
        {
            string objectstring = session.GetString(key);
            if (string.IsNullOrEmpty(objectstring))
            {
                return null;
            }
            T value = JsonConvert.DeserializeObject<T>(objectstring);
            return value;
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace PlakDukkani.UI.MVC.Helpers
{
    public static class SessionExtensions   //Session içerisinde nesne saklamamızı sağlar.
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}

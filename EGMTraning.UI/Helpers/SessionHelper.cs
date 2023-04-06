using System.Text.Json;

namespace EGMTraning.UI
{
    public static class SessionHelper
    {
        public static void SetObjectInSession(this ISession session, string key , object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetCustomObjectFromSession<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            return value ==null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}

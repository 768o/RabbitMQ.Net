using Newtonsoft.Json;

namespace Rabbit.Net.Helper
{
    public static class JsonStringExpand
    {
        static public T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        static public string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}

using UnityEngine;

namespace BootStrap.Data
{
    public static class DataExtentions
    {
        public static T ToDesserializeble<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);
    }
}
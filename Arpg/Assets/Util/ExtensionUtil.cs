using UnityEngine;

namespace Util
{
    public static class ExtensionUtil
    {
        public static T AutoComponent<T>(this GameObject obj)where T:Component
        {
           return obj.GetComponent<T>()==null?obj.AddComponent<T>():obj.GetComponent<T>();
        }
    }
}
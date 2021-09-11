using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A helper class that allows serialzing/deserializing arrays with JsonUtility
 * by wrapping them with class. By default arrays are not supported in JsonUtility.
 * Credits https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
 */
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.items;
    }
    
    public static string ToJson<T>(T[] array, bool prettyPrint = false)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }
    
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}

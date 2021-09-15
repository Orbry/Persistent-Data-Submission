using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Due to the fact that MonoBehaviour prohibites using "new()" there seems to be no way
 * to create proper Singleton abstract class that derives from MonoBehaviour. So what's
 * left is to use *soft* Singleton that saves reference to first instance and warns about
 * additional instances in console.
 */
abstract public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get => instance;
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            // TODO: delete log
            Debug.LogWarning($"An additional instance of \"{typeof(T).Name}\" was destroyed!");
        } else
            instance = (T)this;
    }
}

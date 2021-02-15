using UnityEngine;

using NullReferenceException = System.NullReferenceException;

namespace Butt
{
   
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance
        {
            get
            {
                // The internal instance isn't set, so attempt to find from the scene
                if(instance == null)
                {
                    instance = FindObjectOfType<T>();

                    //No instance was found so throw a NullReferenceException detailing what singleton caused the error.
                    if(instance == null)
                    {
                        throw new NullReferenceException(string.Format("No object of type: {0} was found.", typeof(T).Name));
                    }
                }
                return instance;
            }
        }

        // The property wraps this variable
        private static T instance = null;

        /// <summary>
        /// Has the singleton been generated?
        /// </summary>
        /// <returns></returns>
        public static bool IsSingletonValid() => instance != null;


        /// <summary>
        /// Finds the instance within the scene
        /// </summary>
        /// <returns></returns>
        protected T CreateInstance() => Instance;

        /// <summary>
        /// Force the singlton instance to not be destroyed on scene load.
        /// </summary>
        public static void FlagAsPersistant() => DontDestroyOnLoad(Instance.gameObject);
  
    }
}


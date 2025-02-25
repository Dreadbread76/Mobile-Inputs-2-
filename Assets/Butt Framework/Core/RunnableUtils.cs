using UnityEngine;

namespace Butt
{
    public class RunnableUtils : MonoBehaviour
    {
        /// <summary>
        /// Attempts to retrieve the runnable behaviour fromt the passed gameObject or it's children
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_runnable"> The reference the runnable will be set to.</param>
        /// <param name="_from"> The gameObject we are attempting to get a runnable from.</param>
        /// <returns></returns>
        public static bool Validate<T>(ref T _runnable, GameObject _from) where T : IRunnable
        {
            // If the passed runnable is already set, return true
            if(_runnable == null)
            {
                return true;
            }

            //If the passed runnable isn't set , attempt to get it from the passed gameObject 
            if(_runnable == null)
            {
                _runnable = _from.GetComponent<T>();

                // We successfully retrived the component , so return true
                if(_runnable != null)
                {
                    return true;
                }

               
            }
            //If the runnable still isn't set , attempt to get it from the passed gameObject's children
            if (_runnable == null)
            {
                _runnable = _from.GetComponentInChildren<T>();

                // We successfully retrived the component , so return true
                if (_runnable != null)
                {
                    return true;
                }

                
            }
            //We failed to get any instance of the runnable, so return false 
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_runnable">the runnable being setup.</param>
        /// <param name="_from">The gameObject the runnable is attached to.</param>
        /// <param name="_params">Any additional information the Runnable's setup function needs. </param>
        /// <returns></returns>
        public static bool Setup<T>(ref T _runnable, GameObject _from, params object[] _params) where T: IRunnable
        {
            //Validate the component, if we can, set it up and return true
            if (Validate(ref _runnable, _from))
            {
                _runnable.Setup(_params);
                return true;
            }

            //We failed to validate the component so return false
            return false;
        }

        /// <summary>
        /// Attempts to validate the runnable and if successful run it using the information provided
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_runnable">the runnable being run.</param>
        /// <param name="_from">The gameObject the runnable is attached to.</param>
        /// <param name="_params">Any additional information the Runnable's run function needs.</param>
        public static void Run<T>(ref T _runnable, GameObject _from, params object[] _params) where T : IRunnable
        {
            if(Validate(ref _runnable, _from))
            {
                _runnable.Run(_params);
            }
        }
    }
}


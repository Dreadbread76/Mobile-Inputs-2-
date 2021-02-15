using UnityEngine;

using InvalidOperationException = System.InvalidOperationException;
using NullReferenceException = System.InvalidOperationException;

namespace Butt.Mobile
{
    public class MobileInput : MonoBehaviour
    {
        //Has the mobile input system been initialised
        public static bool Initialised => instance != null;

        //Singleton reference instance
        private static MobileInput instance = null;

        /// <summary>
        /// If the system isn't already setup, this will instantiate the mobile input prefab and assign the static reference.
        /// </summary>
        public static void Initialise()
        {
            //If the mobile input is already initialised, throw an exception to tell the user they dun goofed.
            if (Initialised)
            {
                throw new InvalidOperationException("Mobile Input is already initialised!");
            }

            //Load the Mobile Input prefab and instantiate it, setting the instance
            MobileInput prefabInstance = Resources.Load<MobileInput>("Mobile Input Prefab");
            instance = Instantiate(prefabInstance);

            // Changed the instantiated objects name and mark it to not be destroyed 
            instance.gameObject.name = "Mobile Input";
            DontDestroyOnLoad(instance.gameObject);
            
        }
        [SerializeField]
        private JoystickInput joystickInput;

        /// <summary>
        /// Return the value of the joystick from the joystick module if it is valid
        /// </summary>
        /// <param name="_axis">The axis to get the input from, Horizontal = x; Vertical = y</param>
        /// <returns></returns>
        public static float GetJoystickAxis(JoystickAxis _axis)
        {

            //if the mobile input isn't initialised thrown an invalidOperationException
            if (!Initialised)
            {
                throw new InvalidOperationException("Mobile Input not initialised.");
            }

            if (instance.joystickInput == null)
            {
                throw new NullReferenceException("Joystick input reference not set.");
            }
            switch (_axis)
            {
             
                case JoystickAxis.Horizontal:
                    return instance.joystickInput.Axis.x;
                   
                case JoystickAxis.Vertical:
                    return instance.joystickInput.Axis.y;
                default:
                    return 0;

            }
        }
    }
}


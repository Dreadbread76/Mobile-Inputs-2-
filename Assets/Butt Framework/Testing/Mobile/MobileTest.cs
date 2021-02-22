using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Butt.Mobile;



public class MobileTest : MonoBehaviour
{

    [SerializeField]
    private bool testJoystick = false;
    [SerializeField]
    private bool testSwipe = false;
    // Start is called before the first frame update
    void Start()
    {
        MobileInput.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        if (testJoystick)
        {
            transform.position += transform.forward * MobileInput.GetJoystickAxis(JoystickAxis.Vertical) * Time.deltaTime;
            transform.position += transform.right * MobileInput.GetJoystickAxis(JoystickAxis.Horizontal) * Time.deltaTime;
        }
        if (testSwipe)
        {
#if (UNITY_ANDROID || UNITY_IOS) && UUNITY_EDITOR
//IOS AND ANDROID HERE
            
#else
            // Touch start emulation
            if (Input.GetMouseButtonDown(0))
            {

            }
            //Touch update simulation
            if (Input.GetMouseButton(0))
            {

            }
            // Touch end simulation
            if (Input.GetMouseButtonUp(0))
            {

            }
            // Touch position emulation
            Vector2 touchPos = Input.mousePosition;
#endif
        }

    }
}


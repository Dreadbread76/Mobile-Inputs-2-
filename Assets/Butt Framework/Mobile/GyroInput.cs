using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Butt.Mobile
{
    public class GyroInput : MonoBehaviour
    {

       
        public GameObject changable;

        // Start is called before the first frame update
        private void Start()
        {
            changable = this.gameObject;
            
        }
        public void Update()
        {
            GyroRotatesGameObject();

            
        }

        // Update is called once per frame
        void GyroRotatesGameObject()
        {
            changable.transform.rotation = UnityGyro(Input.gyro.attitude);
            
        }
        public static Quaternion UnityGyro(Quaternion q)
        {
            
            return new Quaternion(q.x, q.y, -q.z, -q.w);
            
        }

        
        
    }
}


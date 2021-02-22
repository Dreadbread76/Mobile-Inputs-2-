using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Butt
{
    public abstract class Trigger : MonoBehaviour
    {
        public UnityEvent OnTriggered
        {
            get => onTriggered;
            set => onTriggered = value;
           
        }

        [SerializeField, Min(0)]
        protected float delay = 0;
        [SerializeField]
        protected bool oneTimeUse = false; 
        [SerializeField]
        protected UnityEvent onTriggered = new UnityEvent();

        private bool triggered = false;
        public void Fire()
        {
            if (triggered && oneTimeUse)
                return;

            triggered = true;
            StartCoroutine(Trigger_CR());
        }
        private IEnumerator Trigger_CR()
        {
            yield return new WaitForSeconds(delay);
            onTriggered.Invoke();
        }

    }
}


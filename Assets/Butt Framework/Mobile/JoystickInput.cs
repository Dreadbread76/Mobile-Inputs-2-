using UnityEngine;
using UnityEngine.EventSystems;

namespace Butt.Mobile
{

    public enum JoystickAxis
    {
        None,
        Horizontal,
        Vertical,
    }

    public class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        
        /// <summary>
        /// The axis the value that the joystick represents. Both the direction and amount on each axis.
        /// </summary>
        public Vector2 Axis { get; private set; } = Vector2.zero;

        [SerializeField]
        private RectTransform handle;
        [SerializeField]
        private RectTransform background;
        [SerializeField, Range(0, 1)]
        private float deadzone = 0.25f;

        private Vector3 initialPosition = Vector3.zero;

        // Start is called before the first frame update
        void Start() => initialPosition = handle.transform.position;

        public void OnDrag(PointerEventData _eventData)
        {
            float xDifference = (background.rect.size.x - handle.rect.size.x) * 0.5f;
            float yDifference = (background.rect.size.y - handle.rect.size.y) * 0.5f;


            // Calculate the axis of the input based on the event data and the relative position to the background's centre
            Axis = new Vector2(
                (_eventData.position.x - background.position.x) / xDifference,
                (_eventData.position.y - background.position.y) / yDifference);
            Axis = (Axis.magnitude > 1.0f) ? Axis.normalized : Axis;

            //Apply the axis position to handle
            handle.transform.position = new Vector3(
                (Axis.x * xDifference) + background.position.x,
                (Axis.y * yDifference) + background.position.y);

            // Apply the deadzone effect after the handle has been placed into it's correct position
            Axis = (Axis.magnitude < deadzone) ? Vector2.zero : Axis;
            // Ternary operator -> Condition ? True : False -> ? = if : else
        }

        public void OnEndDrag(PointerEventData _eventData)
        {
            //We have let go so reset the axis and set the initial position 
            Axis = Vector2.zero;
            handle.transform.position = initialPosition;
        }
        public void OnPointerDown(PointerEventData _eventData) => OnDrag(_eventData);
        public void OnPointerUp(PointerEventData _eventData) => OnEndDrag(_eventData);

     
        


    }

}


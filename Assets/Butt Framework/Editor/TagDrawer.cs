using UnityEngine;
using UnityEditor;


namespace Butt
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagDrawer : PropertyDrawer
    {
        /// <summary>
        /// The function that renders the property into the inspector
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_property"></param>
        /// <param name="_label"></param>
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            EditorGUI.BeginProperty(_position, _label, _property);

            //Determine if the property was set to nothing by default
            bool isNotSet = string.IsNullOrEmpty(_property.stringValue);

            //Draw the string as a tag instead of a normal string box
            _property.stringValue = EditorGUI.TagField(_position, _label, isNotSet ? (_property.serializedObject.targetObject as Component).gameObject.tag : _property.stringValue);

            EditorGUI.EndProperty();
        }

        /// <summary>
        /// Gets the vertical space a single property will take in the inspector
        /// </summary>
        /// <param name="_property"></param>
        /// <param name="_label"></param>
        /// <returns></returns>
        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }

}

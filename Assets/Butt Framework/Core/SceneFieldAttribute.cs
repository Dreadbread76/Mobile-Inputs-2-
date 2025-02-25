using UnityEngine;

namespace Butt
{
    public class SceneFieldAttribute : PropertyAttribute
    {
        /// <summary>
        /// Converts a full path to a SceneManager friendly 
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static string LoadableName(string _path)
        {
            // The pieces of the path we are looking to ignore
            string start = "Assets/";
            string end = ".unity";

            //Test if the path contains 'start' data, if so, remove it
            if (_path.StartsWith(start))
            {
                _path = _path.Substring(start.Length);
            }

            // Test if the path contains 'end' data. if so,remove it
            if (_path.EndsWith(end))
            {
                _path = _path.Substring(0, _path.LastIndexOf(end));

            }

            // Return the newly edited path
            return _path;
        }
    }

}


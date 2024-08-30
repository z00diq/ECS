using UnityEngine;

namespace Assets._Project.Scripts.Extentions
{
    public static class Vector3Extensions
    {
        public static Vector3 Multiplay(this Vector3 first, Vector3 second)
        {
            Vector3 newVector = new();
            
            newVector.x = first.x * second.x;
            newVector.y = first.y * second.y;
            newVector.z = first.z * second.z;

            return newVector;
        }
    }
}

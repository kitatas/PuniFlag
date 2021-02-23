using UnityEngine;

namespace Common.Extension
{
    public static class TransformExtension
    {
        public static Vector3 RoundPosition(this Transform transform)
        {
            var p = transform.position;
            var x = GetCorrectValue(Mathf.RoundToInt(p.x));
            var y = GetCorrectValue(Mathf.RoundToInt(p.y));
            var z = p.z;
            return new Vector3(x, y, z);
        }

        private static float GetCorrectValue(int value)
        {
            if (value == -2)
            {
                return -1.5f;
            }

            if (value == 2)
            {
                return 1.5f;
            }

            return value;
        }
    }
}
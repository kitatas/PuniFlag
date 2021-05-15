using UnityEngine;

namespace Kai.Common.Extension
{
    public static class TransformExtension
    {
        public static Vector3 RoundPosition(this Transform transform)
        {
            var p = transform.position;
            var x = Mathf.RoundToInt(p.x);
            var y = Mathf.RoundToInt(p.y);
            var z = p.z;
            return new Vector3(x, y, z);
        }
    }
}
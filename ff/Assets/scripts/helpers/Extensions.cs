using UnityEngine;

namespace Assets.scripts.Helpers
{
    public static class Extensions
    {
        public static Vector3 ChangeX(this Vector3 input, float newX)
        {
            return new Vector3(newX, input.y, input.z);
        }

        public static Vector3 AddValue(this Vector3 input, float dx, float dy, float dz)
        {
            return new Vector3(input.x + dx, input.y + dy, input.z + dz);
        }

        public static Vector3 AddValueX(this Vector3 input, float dx)
        {
            return ChangeX(input, input.x + dx);
        }

        public static Vector3 AddValueXY(this Vector3 input, float dx, float dy)
        {
            return new Vector3(input.x + dx, input.y + dy, input.z);
        }

        public static Vector3 AddValueXYClamped(this Vector3 input, float dx, float dy, Vector2 maxValue,
            Vector2 minValue)
        {
            return new Vector3(
                Mathf.Clamp(input.x + dx, minValue.x, maxValue.x),
                Mathf.Clamp(input.y + dy, minValue.y, maxValue.y),
                input.z);
        }
    }
}
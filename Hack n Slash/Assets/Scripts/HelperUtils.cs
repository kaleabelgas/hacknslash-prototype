using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utils
{
    public static class HelperUtils
    {
        public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
        {
            var fromAbs = from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + toMin;

            return to;
        }

        public static float SnapToNumber(float toSnap, float factor)
        {
            return Mathf.Round(toSnap / factor) * factor; 
        }


        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }

        public static bool RandomFromPercent(float percentChance)
        {
            return Random.Range(0f, 1f) <= percentChance;
        }
    }
}

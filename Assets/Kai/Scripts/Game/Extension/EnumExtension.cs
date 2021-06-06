using System;
using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Extension
{
    public static class EnumExtension
    {
        private static readonly float _gravityRate = 49.0f;

        public static Vector3 GetGravity(this ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Red:
                    return Vector3.right * _gravityRate;
                case ColorType.Green:
                    return Vector3.left * _gravityRate;
                case ColorType.Blue:
                    return Vector3.down * _gravityRate;
                case ColorType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null);
            }
        }
    }
}
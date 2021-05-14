using UnityEngine;

namespace Game.Application
{
    public sealed class InGameConfig
    {
        public const GameState INIT_STATE = GameState.Input;
    }

    public sealed class StageObjectConfig
    {
        public static readonly Quaternion rotateDefault = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
        public static readonly Quaternion rotateRed = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
        public static readonly Quaternion rotateGreen = Quaternion.Euler(new Vector3(0.0f, 0.0f, -90.0f));
        public static readonly Quaternion rotateBlue = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        public static readonly Vector3 rotateAddVector = new Vector3(0.0f, 0.0f, 90.0f);
        public const float ROTATE_SPEED = 0.25f;
        public const float MOVE_SPEED = 0.25f;
        public const float CORRECT_TIME = 0.1f;
    }
}
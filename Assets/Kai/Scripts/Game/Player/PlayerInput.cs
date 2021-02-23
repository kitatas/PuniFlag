using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerInput
    {
        public bool isMoveLeft => Input.GetKeyDown(KeyCode.A);
        public bool isMoveRight => Input.GetKeyDown(KeyCode.D);

        public bool isRotateLeft => Input.GetKeyDown(KeyCode.Q);
        public bool isRotateRight => Input.GetKeyDown(KeyCode.E);
    }
}
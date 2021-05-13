using Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Game.Domain.UseCase
{
    public sealed class InputUseCase : IInputUseCase
    {
        public bool isMoveLeft => Input.GetKeyDown(KeyCode.A);
        public bool isMoveRight => Input.GetKeyDown(KeyCode.D);

        public bool isRotateLeft => Input.GetKeyDown(KeyCode.Q);
        public bool isRotateRight => Input.GetKeyDown(KeyCode.E);

        public bool isReset => Input.GetKeyDown(KeyCode.Space);
        public bool isBack => Input.GetKeyDown(KeyCode.Backspace);
    }
}
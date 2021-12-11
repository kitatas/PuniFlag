using System;
using DG.Tweening;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class PlayerMoveUseCase : IPlayerMoveUseCase
    {
        private readonly ColorType _colorType;
        private readonly Transform _transform;

        public PlayerMoveUseCase(ColorType colorType, Transform transform)
        {
            _colorType = colorType;
            _transform = transform;
        }

        public Tween Move(InputType inputType)
        {
            switch (_colorType)
            {
                case ColorType.Red:
                {
                    var value = GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(value, StageObjectConfig.MOVE_SPEED);
                }
                case ColorType.Green:
                {
                    var value = -GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(value, StageObjectConfig.MOVE_SPEED);   
                }
                case ColorType.Blue:
                {
                    var value = GetMoveValue(inputType) + _transform.position.x;
                    return _transform.DOMoveX(value, StageObjectConfig.MOVE_SPEED);
                }
                case ColorType.Purple:
                {
                    var value = -GetMoveValue(inputType) + _transform.position.x;
                    return _transform.DOMoveX(value, StageObjectConfig.MOVE_SPEED);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static float GetMoveValue(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.MoveLeft:
                    return -1.0f;
                case InputType.MoveRight:
                    return 1.0f;
                case InputType.None:
                case InputType.RotateLeft:
                case InputType.RotateRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}
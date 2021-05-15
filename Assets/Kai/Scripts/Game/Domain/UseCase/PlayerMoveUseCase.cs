using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class PlayerMoveUseCase : IPlayerMoveUseCase
    {
        private readonly ColorType _colorType;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _transform;
        private readonly Vector3 _gravity;
        private readonly float _rate = 49.0f;

        public PlayerMoveUseCase(ColorType colorType, Rigidbody2D rigidbody2D, Transform transform)
        {
            _colorType = colorType;
            _rigidbody2D = rigidbody2D;
            _transform = transform;
            _gravity = GetGravity(_colorType) * _rate;
        }

        public void UpdateGravity()
        {
            _rigidbody2D.AddForce(_gravity, ForceMode2D.Force);
        }

        public void ResetVelocity()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> Move(InputType inputType)
        {
            switch (_colorType)
            {
                case ColorType.Red:
                    var redValue = GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(redValue, StageObjectConfig.MOVE_SPEED);
                case ColorType.Green:
                    var greenValue = -GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(greenValue, StageObjectConfig.MOVE_SPEED);
                case ColorType.Blue:
                    var blueValue = GetMoveValue(inputType) + _transform.position.x;
                    return _transform.DOMoveX(blueValue, StageObjectConfig.MOVE_SPEED);
                case ColorType.None:
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

        private static Vector3 GetGravity(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Red:
                    return Vector3.right;
                case ColorType.Green:
                    return Vector3.left;
                case ColorType.Blue:
                    return Vector3.down;
                case ColorType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null);
            }
        }
    }
}
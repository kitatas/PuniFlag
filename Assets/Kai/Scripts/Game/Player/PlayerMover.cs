using System;
using Common;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Application;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerMover
    {
        private readonly PlayerType _playerType;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _transform;
        private readonly Vector3 _gravity;
        private readonly float _rate = 49.0f;

        public PlayerMover(PlayerType playerType, Rigidbody2D rigidbody2D, Transform transform)
        {
            _playerType = playerType;
            _rigidbody2D = rigidbody2D;
            _transform = transform;
            _gravity = GetGravity(_playerType) * _rate;
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
            switch (_playerType)
            {
                case PlayerType.Red:
                    var redValue = GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(redValue, Const.MOVE_SPEED);
                case PlayerType.Blue:
                    var blueValue = GetMoveValue(inputType) + _transform.position.x;
                    return _transform.DOMoveX(blueValue, Const.MOVE_SPEED);
                case PlayerType.Green:
                    var greenValue = -GetMoveValue(inputType) + _transform.position.y;
                    return _transform.DOMoveY(greenValue, Const.MOVE_SPEED);
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

        private static Vector3 GetGravity(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.Red:
                    return Vector3.right;
                case PlayerType.Blue:
                    return Vector3.down;
                case PlayerType.Green:
                    return Vector3.left;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null);
            }
        }
    }
}
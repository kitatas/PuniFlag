using System;
using Common;
using DG.Tweening;
using Game.Stage;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerRotator
    {
        private readonly Transform _transform;
        private readonly Vector3 _addVector = new Vector3(0.0f, 0.0f, 90.0f);
        private Vector3 _currentVector;

        public PlayerRotator(Transform transform)
        {
            _transform = transform;
            _currentVector = transform.eulerAngles;
        }

        public void Rotate(RotateDirection rotateDirection)
        {
            _currentVector = GetRotateVector(rotateDirection);
            _transform
                .DOLocalRotate(_currentVector, Const.ROTATE_SPEED);
        }

        private Vector3 GetRotateVector(RotateDirection rotateDirection)
        {
            switch (rotateDirection)
            {
                case RotateDirection.Left:
                    return _currentVector - _addVector;
                case RotateDirection.Right:
                    return _currentVector + _addVector;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rotateDirection), rotateDirection, null);
            }
        }
    }
}
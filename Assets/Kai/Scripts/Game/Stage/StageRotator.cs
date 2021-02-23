using System;
using Common;
using DG.Tweening;
using UnityEngine;

namespace Game.Stage
{
    public sealed class StageRotator : MonoBehaviour
    {
        private Vector3 _currentRotateVector;

        private static readonly Vector3 _rotateLeft = new Vector3(0.0f, 0.0f, 90.0f);
        private static readonly Vector3 _rotateRight = new Vector3(0.0f, 0.0f, -90.0f);

        private void Start()
        {
            _currentRotateVector = Vector3.zero;
        }

        public void Rotate(RotateDirection rotateDirection)
        {
            _currentRotateVector += GetRotateVector(rotateDirection);
            transform
                .DOLocalRotate(_currentRotateVector, Const.ROTATE_SPEED);
        }

        private static Vector3 GetRotateVector(RotateDirection rotateDirection)
        {
            switch (rotateDirection)
            {
                case RotateDirection.Left:
                    return _rotateLeft;
                case RotateDirection.Right:
                    return _rotateRight;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rotateDirection), rotateDirection, null);
            }
        }
    }
}
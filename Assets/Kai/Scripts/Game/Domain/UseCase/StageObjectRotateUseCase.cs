using System;
using DG.Tweening;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectRotateUseCase : IStageObjectRotateUseCase
    {
        private readonly Transform _transform;
        private readonly Vector3 _addVector = new Vector3(0.0f, 0.0f, 90.0f);
        private Vector3 _currentVector;

        public StageObjectRotateUseCase(Transform transform)
        {
            _transform = transform;
            _currentVector = transform.eulerAngles;
        }

        public void Rotate(InputType inputType)
        {
            _currentVector = GetRotateVector(inputType);
            _transform
                .DOLocalRotate(_currentVector, StageObjectConfig.ROTATE_SPEED);
        }

        private Vector3 GetRotateVector(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.RotateLeft:
                    return _currentVector - _addVector;
                case InputType.RotateRight:
                    return _currentVector + _addVector;
                case InputType.None:
                case InputType.MoveLeft:
                case InputType.MoveRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}
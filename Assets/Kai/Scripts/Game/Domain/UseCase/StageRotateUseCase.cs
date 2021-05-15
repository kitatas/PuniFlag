using System;
using DG.Tweening;
using Game.Application;
using Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Game.Domain.UseCase
{
    public sealed class StageRotateUseCase : IStageRotateUseCase
    {
        private int _index;
        private readonly Vector3[] _rotateVector;
        private readonly Transform _transform;

        public StageRotateUseCase(Transform transform)
        {
            _transform = transform;
            
            _index = 0;
            _rotateVector = new Vector3[4]
            {
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.0f, 0.0f, 90.0f),
                new Vector3(0.0f, 0.0f, 180.0f),
                new Vector3(0.0f, 0.0f, 270.0f),
            };
        }

        public void Rotate(InputType inputType)
        {
            _index += GetRotateVectorIndex(inputType);
            _index = ClampRotateVectorIndex();

            _transform
                .DOLocalRotate(_rotateVector[_index], StageObjectConfig.ROTATE_SPEED);
        }

        private static int GetRotateVectorIndex(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.RotateLeft:
                    return 1;
                case InputType.RotateRight:
                    return -1;
                case InputType.None:
                case InputType.MoveLeft:
                case InputType.MoveRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }

        private int ClampRotateVectorIndex()
        {
            if (_index > _rotateVector.Length - 1)
            {
                return 0;
            }

            if (_index < 0)
            {
                return _rotateVector.Length - 1;
            }

            return _index;
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Extension;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageRotateUseCase : IStageRotateUseCase
    {
        private int _index;
        private readonly Transform _transform;

        public StageRotateUseCase(Transform transform)
        {
            _transform = transform;
            _index = 0;
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            _index = GetRotateVectorIndex(inputType);
            await _transform
                .DOLocalRotate(StageObjectConfig.rotateVector[_index], StageObjectConfig.ROTATE_SPEED)
                .WithCancellation(token);
        }

        private int GetRotateVectorIndex(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.RotateLeft:
                    return _index.RepeatIncrement(0, StageObjectConfig.rotateVector.Length - 1);
                case InputType.RotateRight:
                    return _index.RepeatDecrement(0, StageObjectConfig.rotateVector.Length - 1);
                case InputType.None:
                case InputType.MoveLeft:
                case InputType.MoveRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Extension;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectRotateUseCase : IStageObjectRotateUseCase
    {
        private readonly Transform _transform;
        private int _index;

        public StageObjectRotateUseCase(Transform transform)
        {
            _transform = transform;
            _index = StageObjectConfig.rotateVector
                .ToList()
                .FindIndex(x => x == _transform.eulerAngles);
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
                    return _index.RepeatDecrement(0, StageObjectConfig.rotateVector.Length - 1);
                case InputType.RotateRight:
                    return _index.RepeatIncrement(0, StageObjectConfig.rotateVector.Length - 1);
                case InputType.None:
                case InputType.MoveLeft:
                case InputType.MoveRight:
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}
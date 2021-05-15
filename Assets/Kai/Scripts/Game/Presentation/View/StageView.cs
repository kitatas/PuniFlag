using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public sealed class StageView : MonoBehaviour
    {
        private IStageRotateUseCase _stageRotateUseCase;

        private void Awake()
        {
            _stageRotateUseCase = new StageRotateUseCase(transform);
        }

        public async UniTask RotateAsync(InputType inputType, CancellationToken token)
        {
            await _stageRotateUseCase.RotateAsync(inputType, token);
        }
    }
}
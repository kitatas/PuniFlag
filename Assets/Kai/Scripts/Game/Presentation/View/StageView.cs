using Game.Application;
using Game.Domain.UseCase;
using Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Game.Presentation.View
{
    public sealed class StageView : MonoBehaviour
    {
        private IStageRotateUseCase _stageRotateUseCase;

        private void Awake()
        {
            _stageRotateUseCase = new StageRotateUseCase(transform);
        }

        public void Rotate(InputType inputType)
        {
            _stageRotateUseCase.Rotate(inputType);
        }
    }
}
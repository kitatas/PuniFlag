using Kai.Common.Extension;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public sealed class FlagView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;

        private IStageObjectRotateUseCase _stageObjectRotateUseCase;

        public void Init()
        {
            _stageObjectRotateUseCase = new StageObjectRotateUseCase(transform);
        }

        public void Rotate(InputType inputType)
        {
            _stageObjectRotateUseCase.Rotate(inputType);
        }

        public bool EqualPosition(Vector3 playerPosition) => transform.RoundPosition() == playerPosition;

        public override StageObjectType type => StageObjectType.Flag;
        public override ColorType color => colorType;
    }
}
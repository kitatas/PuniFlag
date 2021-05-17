using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Domain.UseCase.Interface;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Presentation.Controller;
using Zenject;

namespace Kai.Game.Presentation.View.State
{
    public sealed class InputState : BaseState
    {
        private ButtonController _buttonController;
        private IStageObjectContainerUseCase _stageObjectContainerUseCase;
        private IButtonContainerUseCase _buttonContainerUseCase;
        private StageView _stageView;

        [Inject]
        private void Construct(ButtonController buttonController, IButtonContainerUseCase buttonContainerUseCase,
            IStageObjectContainerUseCase stageObjectContainerUseCase, StageView stageView)
        {
            _buttonController = buttonController;
            _stageObjectContainerUseCase = stageObjectContainerUseCase;
            _buttonContainerUseCase = buttonContainerUseCase;
            _stageView = stageView;
        }

        public override GameState GetState() => GameState.Input;

        public override UniTask InitAsync(CancellationToken token)
        {
            _buttonController.InitInput();
            return base.InitAsync(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _buttonContainerUseCase.ActivateButton(true);

            // ボタン入力待ち
            var input = await _buttonController.PushButton().ToUniTask(true, token);

            _buttonContainerUseCase.ActivateButton(false);

            switch (input)
            {
                case InputType.None:
                    return GameState.None;
                case InputType.MoveLeft:
                case InputType.MoveRight:
                    await _stageObjectContainerUseCase.MoveAsync(input, token);
                    break;
                case InputType.RotateLeft:
                case InputType.RotateRight:
                    await (
                        _stageObjectContainerUseCase.RotateAsync(input, token),
                        _stageView.RotateAsync(input, token)
                    );
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return GameState.Move;
        }
    }
}
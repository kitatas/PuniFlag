using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Common.Domain.UseCase.Interface;
using Kai.Common.Presentation.View;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Presentation.Controller;
using Zenject;

namespace Kai.Game.Presentation.View.State
{
    public sealed class InputState : BaseState
    {
        private ButtonActivator[] _buttonActivators;

        private ButtonActivator[] buttonActivators
        {
            get
            {
                if (_buttonActivators == null)
                {
                    _buttonActivators = FindObjectsOfType<ButtonActivator>();
                }

                return _buttonActivators;
            }
        }

        private ButtonController _buttonController;
        private IStepCountUseCase _stepCountUseCase;
        private IStageObjectContainerUseCase _stageObjectContainerUseCase;
        private StageView _stageView;

        [Inject]
        private void Construct(ButtonController buttonController, IStepCountUseCase stepCountUseCase,
            IStageObjectContainerUseCase stageObjectContainerUseCase, StageView stageView)
        {
            _buttonController = buttonController;
            _stepCountUseCase = stepCountUseCase;
            _stageObjectContainerUseCase = stageObjectContainerUseCase;
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
            ActivateButton(true);

            // ボタン入力待ち
            var input = await _buttonController.PushButton().ToUniTask(true, token);

            ActivateButton(false);
            _stepCountUseCase.CountUp();

            switch (input)
            {
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
                case InputType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return GameState.Move;
        }

        private void ActivateButton(bool value)
        {
            foreach (var buttonActivator in buttonActivators)
            {
                buttonActivator.Activate(value);
            }
        }
    }
}
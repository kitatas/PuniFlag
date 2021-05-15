using System;
using System.Threading;
using Common.Domain.UseCase.Interface;
using Common.Presentation.View;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Domain.UseCase.Interface;
using Game.Presentation.Controller;
using Zenject;

namespace Game.Presentation.View.State
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

            switch (input)
            {
                case InputType.MoveLeft:
                case InputType.MoveRight:
                    _stageObjectContainerUseCase.Move(input);
                    break;
                case InputType.RotateLeft:
                case InputType.RotateRight:
                    _stageObjectContainerUseCase.Rotate(input);
                    _stageView.Rotate(input);
                    break;
                case InputType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _stepCountUseCase.CountUp();

            ActivateButton(false);

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
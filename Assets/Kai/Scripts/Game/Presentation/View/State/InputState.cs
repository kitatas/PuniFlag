using System;
using System.Threading;
using Common;
using Common.Presentation.View;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Presentation.Controller;
using Game.StepCount;
using UniRx;
using Zenject;

namespace Game.Presentation.View.State
{
    public sealed class InputState : BaseState
    {
        private ButtonController _buttonController;
        private StepCountModel _stepCountModel;

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

        private PlayerView[] _players;
        private StageView _stageView;

        [Inject]
        private void Construct(ButtonController buttonController, StepCountModel stepCountModel)
        {
            _buttonController = buttonController;
            _stepCountModel = stepCountModel;
        }

        private void Awake()
        {
            _players = FindObjectsOfType<PlayerView>();
            _stageView = FindObjectOfType<StageView>();
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
                    MovePlayer(input);
                    break;
                case InputType.RotateLeft:
                case InputType.RotateRight:
                    ActivatePlayerCollider();
                    RotatePlayer(input);
                    _stageView.Rotate(input);
                    break;
                case InputType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _stepCountModel.CountUp();

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

        private void MovePlayer(InputType inputType)
        {
            foreach (var player in _players)
            {
                player.Move(inputType);
            }
        }

        private void ActivatePlayerCollider()
        {
            ActivatePlayerCollider(false);
            Observable
                .Timer(TimeSpan.FromSeconds(Const.ROTATE_SPEED + 0.01f))
                .Subscribe(_ => ActivatePlayerCollider(true))
                .AddTo(this);
        }

        private void ActivatePlayerCollider(bool value)
        {
            foreach (var player in _players)
            {
                player.ActivateCollider(value);
            }
        }

        private void RotatePlayer(InputType inputType)
        {
            foreach (var player in _players)
            {
                player.Rotate(inputType);
            }
        }
    }
}
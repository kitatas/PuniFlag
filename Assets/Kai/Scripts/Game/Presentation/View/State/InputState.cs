using System;
using System.Threading;
using Common;
using Common.Presentation.View;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Player;
using Game.Stage;
using Game.StepCount;
using UniRx;
using UnityEngine;
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

        private PlayerCore[] _players;
        private StageRotator _stageRotator;

        [Inject]
        private void Construct(ButtonController buttonController, StepCountModel stepCountModel)
        {
            _buttonController = buttonController;
            _stepCountModel = stepCountModel;
        }

        private void Awake()
        {
            _players = FindObjectsOfType<PlayerCore>();
            _stageRotator = FindObjectOfType<StageRotator>();
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
            Debug.Log($"{input}");
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
            _stageRotator.Rotate(inputType);
            foreach (var player in _players)
            {
                player.Rotate(inputType);
            }
        }
    }
}
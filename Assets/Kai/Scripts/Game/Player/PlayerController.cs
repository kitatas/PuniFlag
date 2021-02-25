using System;
using System.Linq;
using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using Game.Stage;
using Game.StepCount;
using Game.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private MoveButton moveLeft = default;
        [SerializeField] private MoveButton moveRight = default;
        [SerializeField] private RotateButton rotateLeft = default;
        [SerializeField] private RotateButton rotateRight = default;
        [SerializeField] private ClearView clearView = default;
        private ReactiveProperty<bool> _isInput;
        private CancellationToken _token;

        private PlayerInput _playerInput;
        private PlayerCore[] _players;
        private StepCountModel _stepCountModel;

        [Inject]
        private void Construct(PlayerInput playerInput, StepCountModel stepCountModel)
        {
            _isInput = new ReactiveProperty<bool>(false);
            _token = this.GetCancellationTokenOnDestroy();
            _playerInput = playerInput;
            _stepCountModel = stepCountModel;
        }

        private void Awake()
        {
            _players = FindObjectsOfType<PlayerCore>();
        }

        private void Start()
        {
            InitButton();
            InitMove();
            InitRotate();
        }

        private void InitButton()
        {
            _isInput
                .Subscribe(x => ActivateButton(!x))
                .AddTo(this);
        }

        private void InitMove()
        {
            var inputMoveLeft = this.UpdateAsObservable()
                .Where(_ => _playerInput.isMoveLeft);
            Observable
                .Merge(inputMoveLeft, moveLeft.onPush)
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    moveLeft.Push();
                    MovePlayer(MoveDirection.Left);
                    SetButtonAsync(_token).Forget();
                })
                .AddTo(this);

            var inputMoveRight = this.UpdateAsObservable()
                .Where(_ => _playerInput.isMoveRight);
            Observable
                .Merge(inputMoveRight, moveRight.onPush)
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    moveRight.Push();
                    MovePlayer(MoveDirection.Right);
                    SetButtonAsync(_token).Forget();
                })
                .AddTo(this);
        }

        private void InitRotate()
        {
            var inputRotateLeft = this.UpdateAsObservable()
                .Where(_ => _playerInput.isRotateLeft);
            Observable
                .Merge(inputRotateLeft, rotateLeft.onPush)
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    rotateLeft.Push();
                    ActivatePlayerCollider();
                    RotatePlayer(RotateDirection.Left);
                    SetButtonAsync(_token).Forget();
                })
                .AddTo(this);

            var inputRotateRight = this.UpdateAsObservable()
                .Where(_ => _playerInput.isRotateRight);
            Observable
                .Merge(inputRotateRight, rotateRight.onPush)
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    rotateRight.Push();
                    ActivatePlayerCollider();
                    RotatePlayer(RotateDirection.Right);
                    SetButtonAsync(_token).Forget();
                })
                .AddTo(this);
        }

        private async UniTaskVoid SetButtonAsync(CancellationToken token)
        {
            _isInput.Value = true;
            _stepCountModel.CountUp();

            await UniTask.Delay(TimeSpan.FromSeconds(Const.ROTATE_SPEED), cancellationToken: token);

            SetOnGravity();

            await UniTask.WaitUntil(IsGroundAllPlayer, cancellationToken: token);

            if (IsGoalAllPlayer())
            {
                clearView.Show();
            }
            else
            {
                _isInput.Value = false;
            }
        }

        private void ActivateButton(bool value)
        {
            moveLeft.Activate(value);
            moveRight.Activate(value);
            rotateLeft.Activate(value);
            rotateRight.Activate(value);
        }

        private void ActivatePlayerCollider()
        {
            ActivatePlayerCollider(false);
            Observable
                .Timer(TimeSpan.FromSeconds(Const.ROTATE_SPEED + 0.15f))
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

        private void SetOnGravity()
        {
            foreach (var player in _players)
            {
                player.isGround = false;
            }
        }

        private bool IsGroundAllPlayer()
        {
            return _players.All(player => player.isGround);
        }

        private void RotatePlayer(RotateDirection rotateDirection)
        {
            foreach (var player in _players)
            {
                player.Rotate(rotateDirection);
            }
        }

        private void MovePlayer(MoveDirection moveDirection)
        {
            foreach (var player in _players)
            {
                player.Move(moveDirection);
            }
        }

        private bool IsGoalAllPlayer()
        {
            return _players.All(player => player.IsGoal());
        }
    }
}
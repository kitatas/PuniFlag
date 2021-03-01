using System;
using System.Linq;
using System.Threading;
using Common;
using Common.Transition;
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
        [SerializeField] private GameButton moveLeft = default;
        [SerializeField] private GameButton moveRight = default;
        [SerializeField] private GameButton rotateLeft = default;
        [SerializeField] private GameButton rotateRight = default;
        [SerializeField] private GameButton resetButton = default;
        [SerializeField] private GameButton homeButton = default;
        [SerializeField] private ClearView clearView = default;
        private ReactiveProperty<bool> _isInput;
        private CancellationToken _token;

        private PlayerInput _playerInput;
        private StepCountModel _stepCountModel;
        private SceneLoader _sceneLoader;
        private PlayerCore[] _players;
        private StageRotator _stageRotator;

        [Inject]
        private void Construct(PlayerInput playerInput, StepCountModel stepCountModel, SceneLoader sceneLoader)
        {
            _isInput = new ReactiveProperty<bool>(false);
            _token = this.GetCancellationTokenOnDestroy();
            _playerInput = playerInput;
            _stepCountModel = stepCountModel;
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _players = FindObjectsOfType<PlayerCore>();
            _stageRotator = FindObjectOfType<StageRotator>();
        }

        private void Start()
        {
            DelayStartAsync(_token).Forget();
        }

        private async UniTaskVoid DelayStartAsync(CancellationToken token)
        {
            var delayTime = Const.FADE_TIME + Const.INTERVAL;
            await UniTask.Delay(TimeSpan.FromSeconds(delayTime), cancellationToken: token);

            InitButton();
            InitMove();
            InitRotate();
        }

        private void InitButton()
        {
            _isInput
                .Subscribe(x => ActivateButton(!x))
                .AddTo(this);

            var inputReset = this.UpdateAsObservable()
                .Where(_ => _playerInput.isReset);
            Observable
                .Merge(inputReset, resetButton.onPush)
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    resetButton.Push();
                    _isInput.Value = true;
                    _sceneLoader.LoadScene(SceneName.Main, LoadType.Reload);
                    _stepCountModel.CountUp();
                })
                .AddTo(this);

            homeButton.onPush
                .Where(_ => _isInput.Value == false)
                .Subscribe(_ =>
                {
                    homeButton.Push();
                    _isInput.Value = true;
                    _sceneLoader.LoadScene(SceneName.Title);
                })
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
                    Rotate(RotateDirection.Left);
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
                    Rotate(RotateDirection.Right);
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
                ClearAsync(_token).Forget();
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
            resetButton.Activate(value);
            homeButton.Activate(value);
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

        private void Rotate(RotateDirection rotateDirection)
        {
            _stageRotator.Rotate(rotateDirection);
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

        private async UniTaskVoid ClearAsync(CancellationToken token)
        {
            await clearView.ShowAsync(token);

            await UniTask.Delay(TimeSpan.FromSeconds(Const.INTERVAL), cancellationToken: token);

            _sceneLoader.LoadScene(SceneName.Main, LoadType.Next);
        }
    }
}
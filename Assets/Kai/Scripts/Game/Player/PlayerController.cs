using System;
using Common;
using Game.Stage;
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
        private ReactiveProperty<bool> _isInput;

        private PlayerInput _playerInput;
        private PlayerCore[] _players;

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
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
            _isInput = new ReactiveProperty<bool>(false);
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
                    SetButton();
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
                    SetButton();
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
                    InitActivatePlayer();
                    UpdatePlayerRotate(RotateDirection.Left);
                    SetButton();
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
                    InitActivatePlayer();
                    UpdatePlayerRotate(RotateDirection.Right);
                    SetButton();
                })
                .AddTo(this);
        }

        private void SetButton()
        {
            _isInput.Value = true;
            Observable
                .Timer(TimeSpan.FromSeconds(Const.ROTATE_SPEED + 0.15f))
                .Subscribe(_ =>
                {
                    _isInput.Value = false;
                    SetOnGravity();
                })
                .AddTo(this);
        }

        private void ActivateButton(bool value)
        {
            moveLeft.Activate(value);
            moveRight.Activate(value);
            rotateLeft.Activate(value);
            rotateRight.Activate(value);
        }

        private void InitActivatePlayer()
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

        private void UpdatePlayerRotate(RotateDirection rotateDirection)
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
    }
}
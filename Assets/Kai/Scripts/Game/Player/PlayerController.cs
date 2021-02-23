using Common;
using DG.Tweening;
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
            InitMove();
            InitRotate();
        }

        private void InitMove()
        {
            var inputMoveLeft = this.UpdateAsObservable()
                .Where(_ => _playerInput.isMoveLeft);
            Observable
                .Merge(inputMoveLeft, moveLeft.onPush)
                .Subscribe(_ =>
                {
                    //
                    moveLeft.Push();
                })
                .AddTo(this);

            var inputMoveRight = this.UpdateAsObservable()
                .Where(_ => _playerInput.isMoveRight);
            Observable
                .Merge(inputMoveRight, moveRight.onPush)
                .Subscribe(_ =>
                {
                    //
                    moveRight.Push();
                })
                .AddTo(this);
        }

        private void InitRotate()
        {
            var inputRotateLeft = this.UpdateAsObservable()
                .Where(_ => _playerInput.isRotateLeft);
            Observable
                .Merge(inputRotateLeft, rotateLeft.onPush)
                .Subscribe(_ =>
                {
                    rotateLeft.Push();
                    InitActivatePlayer();
                })
                .AddTo(this);

            var inputRotateRight = this.UpdateAsObservable()
                .Where(_ => _playerInput.isRotateRight);
            Observable
                .Merge(inputRotateRight, rotateRight.onPush)
                .Subscribe(_ =>
                {
                    rotateRight.Push();
                    InitActivatePlayer();
                })
                .AddTo(this);
        }

        private void InitActivatePlayer()
        {
            ActivatePlayerCollider(false);
            DOTween.Sequence()
                .AppendInterval(Const.ROTATE_SPEED)
                .AppendCallback(() =>
                {
                    ActivatePlayerCollider(true);
                    UpdateRotate();
                });
        }

        private void ActivatePlayerCollider(bool value)
        {
            foreach (var player in _players)
            {
                player.ActivateCollider(value);
            }
        }

        private void UpdateRotate()
        {
            foreach (var player in _players)
            {
                player.isGround = false;
            }
        }
    }
}
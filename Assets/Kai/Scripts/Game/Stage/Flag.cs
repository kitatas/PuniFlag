using Common.Extension;
using Game.Application;
using Game.Player;
using Game.Presentation.View;
using UnityEngine;

namespace Game.Stage
{
    public sealed class Flag : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;

        private PlayerRotator _playerRotator;

        private void Awake()
        {
            _playerRotator = new PlayerRotator(transform);
        }

        public void Rotate(RotateDirection rotateDirection)
        {
            _playerRotator.Rotate(rotateDirection);
        }

        public bool EqualPosition(Vector3 playerPosition) => transform.RoundPosition() == playerPosition;

        public override StageObjectType type => StageObjectType.Flag;
        public override ColorType color => colorType;
    }
}
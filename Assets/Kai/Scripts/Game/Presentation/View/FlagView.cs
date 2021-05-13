using Common.Extension;
using Game.Application;
using Game.Player;
using UnityEngine;

namespace Game.Presentation.View
{
    public sealed class FlagView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;

        private PlayerRotator _playerRotator;

        private void Awake()
        {
            _playerRotator = new PlayerRotator(transform);
        }

        public void Rotate(InputType inputType)
        {
            _playerRotator.Rotate(inputType);
        }

        public bool EqualPosition(Vector3 playerPosition) => transform.RoundPosition() == playerPosition;

        public override StageObjectType type => StageObjectType.Flag;
        public override ColorType color => colorType;
    }
}
using Common.Extension;
using Game.Player;
using UnityEngine;

namespace Game.Stage
{
    public sealed class Flag : MonoBehaviour
    {
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
    }
}
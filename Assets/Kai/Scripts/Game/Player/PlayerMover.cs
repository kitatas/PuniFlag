using System;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerMover
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Vector3 _gravity;
        private readonly float _rate = 98.0f;

        public PlayerMover(PlayerType playerType, Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _gravity = GetGravity(playerType) * _rate;
        }

        public void UpdateGravity()
        {
            _rigidbody2D.AddForce(_gravity, ForceMode2D.Force);
        }

        private static Vector3 GetGravity(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.Red:
                    return Vector3.right;
                case PlayerType.Blue:
                    return Vector3.down;
                case PlayerType.Green:
                    return Vector3.left;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null);
            }
        }
    }
}
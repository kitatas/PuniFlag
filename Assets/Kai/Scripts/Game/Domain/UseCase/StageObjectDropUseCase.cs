using System;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectDropUseCase : IStageObjectDropUseCase
    {
        private const float _gravityRate = 40.0f;
        private readonly Rigidbody2D _rigidbody2D;

        public StageObjectDropUseCase(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void UpdateGravity(ColorType colorType)
        {
            var gravity = GetGravityDirection(colorType) * _gravityRate;
            _rigidbody2D.AddForce(gravity, ForceMode2D.Force);
        }

        public void ResetVelocity()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        private static Vector2 GetGravityDirection(ColorType colorType)
        {
            return colorType switch
            {
                ColorType.Red    => Vector2.right,
                ColorType.Green  => Vector2.left,
                ColorType.Blue   => Vector2.down,
                ColorType.Purple => Vector2.up,
                _ => throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null)
            };
        }
    }
}
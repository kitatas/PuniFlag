using System;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectDropUseCase : IStageObjectDropUseCase
    {
        private const float _gravityRate = 49.0f;
        private readonly Rigidbody2D _rigidbody2D;

        public StageObjectDropUseCase(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void UpdateGravity(ColorType colorType)
        {
            _rigidbody2D.AddForce(GetGravity(colorType), ForceMode2D.Force);
        }

        public void ResetVelocity()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        private static Vector3 GetGravity(ColorType colorType)
        {
            return colorType switch
            {
                ColorType.Red    => _gravityRate * Vector3.right,
                ColorType.Green  => _gravityRate * Vector3.left,
                ColorType.Blue   => _gravityRate * Vector3.down,
                ColorType.Purple => _gravityRate * Vector3.up,
                _ => throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null)
            };
        }
    }
}
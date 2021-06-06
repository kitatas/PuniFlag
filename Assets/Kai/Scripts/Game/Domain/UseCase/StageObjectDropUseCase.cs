using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Extension;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageObjectDropUseCase : IStageObjectDropUseCase
    {
        private readonly Rigidbody2D _rigidbody2D;

        public StageObjectDropUseCase(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void UpdateGravity(ColorType colorType)
        {
            _rigidbody2D.AddForce(colorType.GetGravity(), ForceMode2D.Force);
        }

        public void ResetVelocity()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
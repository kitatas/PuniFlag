using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IPlayerMoveUseCase
    {
        void UpdateGravity();
        void ResetVelocity();
        TweenerCore<Vector3, Vector3, VectorOptions> Move(InputType inputType);
    }
}
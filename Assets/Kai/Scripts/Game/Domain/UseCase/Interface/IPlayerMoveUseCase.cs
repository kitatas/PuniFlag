using DG.Tweening;
using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IPlayerMoveUseCase
    {
        void UpdateGravity();
        void ResetVelocity();
        Tween Move(InputType inputType);
    }
}
using DG.Tweening;
using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IPlayerMoveUseCase
    {
        Tween Move(InputType inputType);
    }
}
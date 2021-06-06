using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IStageObjectDropUseCase
    {
        void UpdateGravity(ColorType colorType);
        void ResetVelocity();
    }
}
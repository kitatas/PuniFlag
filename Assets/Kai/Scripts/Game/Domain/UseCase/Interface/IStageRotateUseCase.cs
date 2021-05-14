using Game.Application;

namespace Game.Domain.UseCase.Interface
{
    public interface IStageRotateUseCase
    {
        void Rotate(InputType inputType);
    }
}
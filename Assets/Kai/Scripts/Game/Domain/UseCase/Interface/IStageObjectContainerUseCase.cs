using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Application;

namespace Game.Domain.UseCase.Interface
{
    public interface IStageObjectContainerUseCase
    {
        void Move(InputType inputType);
        void Rotate(InputType inputType);
        UniTask<bool> IsAllGoalAsync(CancellationToken token);
    }
}
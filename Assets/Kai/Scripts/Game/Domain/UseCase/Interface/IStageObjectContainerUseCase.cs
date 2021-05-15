using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IStageObjectContainerUseCase
    {
        void Move(InputType inputType);
        void Rotate(InputType inputType);
        UniTask<bool> IsAllGoalAsync(CancellationToken token);
    }
}
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IStageObjectContainerUseCase
    {
        UniTask MoveAsync(InputType inputType, CancellationToken token);
        UniTask RotateAsync(InputType inputType, CancellationToken token);
        UniTask<bool> IsAllGoalAsync(CancellationToken token);
    }
}
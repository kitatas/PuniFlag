using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;

namespace Kai.Game.Domain.UseCase.Interface
{
    public interface IStageRotateUseCase
    {
        UniTask RotateAsync(InputType inputType, CancellationToken token);
    }
}
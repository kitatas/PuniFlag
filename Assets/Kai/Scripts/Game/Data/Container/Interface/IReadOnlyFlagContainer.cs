using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container.Interface
{
    public interface IReadOnlyFlagContainer
    {
        IEnumerable<FlagView> flagViews { get; }
        UniTask RotateAllAsync(InputType inputType, CancellationToken token);
    }
}
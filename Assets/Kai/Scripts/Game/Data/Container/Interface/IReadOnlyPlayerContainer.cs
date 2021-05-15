using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container.Interface
{
    public interface IReadOnlyPlayerContainer
    {
        IEnumerable<PlayerView> playerViews { get; }
        UniTask MoveAllAsync(InputType inputType, CancellationToken token);
        void ActivateColliderAll(bool value);
        UniTask RotateAllAsync(InputType inputType, CancellationToken token);
        void SetGravityAll(bool value);
        bool IsGroundAll();
    }
}
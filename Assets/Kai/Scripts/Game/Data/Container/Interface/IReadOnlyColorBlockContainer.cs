using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;

namespace Kai.Game.Data.Container.Interface
{
    public interface IReadOnlyColorBlockContainer
    {
        void ActivateColliderAll(bool value);
        UniTask RotateAllAsync(InputType inputType, CancellationToken token);
        void SetGravityAll(bool value);
        bool IsGroundAll();
    }
}
using System.Collections.Generic;
using Kai.Game.Application;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container.Interface
{
    public interface IReadOnlyPlayerContainer
    {
        IEnumerable<PlayerView> playerViews { get; }
        void MoveAll(InputType inputType);
        void ActivateColliderAll(bool value);
        void RotateAll(InputType inputType);
        void SetGravityAll(bool value);
        bool IsGroundAll();
    }
}
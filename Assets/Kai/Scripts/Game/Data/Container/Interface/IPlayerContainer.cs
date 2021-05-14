using System.Collections.Generic;
using Game.Application;
using Game.Presentation.View;

namespace Game.Data.Container.Interface
{
    public interface IPlayerContainer
    {
        IEnumerable<PlayerView> playerViews { get; }
        void Add(PlayerView playerView);
        void MoveAll(InputType inputType);
        void ActivateColliderAll(bool value);
        void RotateAll(InputType inputType);
        void SetGravityAll(bool value);
        bool IsGroundAll();
    }
}
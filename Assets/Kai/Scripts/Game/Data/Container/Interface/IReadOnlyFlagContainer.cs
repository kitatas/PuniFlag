using System.Collections.Generic;
using Game.Application;
using Game.Presentation.View;

namespace Game.Data.Container.Interface
{
    public interface IReadOnlyFlagContainer
    {
        IEnumerable<FlagView> flagViews { get; }
        void RotateAll(InputType inputType);
    }
}
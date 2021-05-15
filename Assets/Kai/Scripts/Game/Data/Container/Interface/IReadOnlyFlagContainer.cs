using System.Collections.Generic;
using Kai.Game.Application;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container.Interface
{
    public interface IReadOnlyFlagContainer
    {
        IEnumerable<FlagView> flagViews { get; }
        void RotateAll(InputType inputType);
    }
}
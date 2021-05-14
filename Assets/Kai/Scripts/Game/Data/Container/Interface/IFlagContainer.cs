using System.Collections.Generic;
using Game.Application;
using Game.Presentation.View;

namespace Game.Data.Container.Interface
{
    public interface IFlagContainer
    {
        IEnumerable<FlagView> flagViews { get; }
        void Add(FlagView flagView);
        void RotateAll(InputType inputType);
    }
}
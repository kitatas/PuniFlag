using System.Collections.Generic;
using Game.Application;
using Game.Data.Container.Interface;
using Game.Presentation.View;

namespace Game.Data.Container
{
    public sealed class FlagContainer : IReadOnlyFlagContainer, IWriteOnlyFlagContainer
    {
        private readonly List<FlagView> _flagViews;

        public FlagContainer()
        {
            _flagViews = new List<FlagView>();
        }

        public IEnumerable<FlagView> flagViews => _flagViews;

        public void Add(FlagView flagView)
        {
            flagView.Init();
            _flagViews.Add(flagView);
        }

        public void RotateAll(InputType inputType)
        {
            foreach (var flagView in flagViews)
            {
                flagView.Rotate(inputType);
            }
        }
    }
}
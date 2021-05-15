using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container
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

        public async UniTask RotateAllAsync(InputType inputType, CancellationToken token)
        {
            await Enumerable
                .Select(flagViews, flagView => flagView.RotateAsync(inputType, token))
                .ToList();
        }
    }
}
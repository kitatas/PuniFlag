using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Presentation.View;

namespace Kai.Game.Data.Container
{
    public sealed class ColorBlockContainer : IReadOnlyColorBlockContainer, IWriteOnlyColorBlockContainer
    {
        private readonly List<ColorBlockView> _colorBlockViews;

        public ColorBlockContainer()
        {
            _colorBlockViews = new List<ColorBlockView>();
        }

        public void Add(ColorBlockView colorBlockView)
        {
            colorBlockView.Init();
            _colorBlockViews.Add(colorBlockView);
        }

        public void ActivateColliderAll(bool value)
        {
            foreach (var colorBlockView in _colorBlockViews)
            {
                colorBlockView.ActivateCollider(value);
            }
        }

        public async UniTask RotateAllAsync(InputType inputType, CancellationToken token)
        {
            await Enumerable
                .Select(_colorBlockViews, colorBlockView => colorBlockView.RotateAsync(inputType, token))
                .ToList();
        }

        public void SetGravityAll(bool value)
        {
            foreach (var colorBlockView in _colorBlockViews)
            {
                colorBlockView.isGround = value;
            }
        }

        public bool IsGroundAll() => _colorBlockViews.All(colorBlockView => colorBlockView.isGround);
    }
}
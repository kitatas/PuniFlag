using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public class BlockView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;

        public override StageObjectType type => StageObjectType.Block;
        public override ColorType color => colorType;
    }
}
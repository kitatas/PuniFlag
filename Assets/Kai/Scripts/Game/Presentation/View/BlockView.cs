using Game.Application;
using UnityEngine;

namespace Game.Presentation.View
{
    public sealed class BlockView : StageObjectView
    {
        [SerializeField] private ColorType colorType = default;

        public override StageObjectType type => StageObjectType.Block;
        public override ColorType color => colorType;
    }
}
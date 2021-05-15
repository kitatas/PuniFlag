using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public abstract class StageObjectView : MonoBehaviour
    {
        public abstract StageObjectType type { get; }
        public abstract ColorType color { get; }
    }
}
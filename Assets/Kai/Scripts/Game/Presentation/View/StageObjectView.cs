using Game.Application;
using UnityEngine;

namespace Game.Presentation.View
{
    public abstract class StageObjectView : MonoBehaviour
    {
        public abstract StageObjectType type { get; }
        public abstract ColorType color { get; }
    }
}
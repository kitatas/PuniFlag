using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    public sealed class GraphicFlasher : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Graphic>()
                .DOFade(0.0f, 0.2f)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(gameObject);
        }
    }
}
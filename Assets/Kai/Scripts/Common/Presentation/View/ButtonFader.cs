using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    public sealed class ButtonFader : MonoBehaviour
    {
        private Vector3 _buttonScale;
        [SerializeField] private Image buttonImage = default;

        public void Init()
        {
            _buttonScale = buttonImage.transform.localScale;
        }

        public void FadeIn(float animationTime = 0.0f)
        {
            DOTween.Sequence()
                .Append(buttonImage
                    .DOFade(0.0f, animationTime)
                    .SetEase(Ease.Linear))
                .Join(buttonImage.rectTransform
                    .DOScale(_buttonScale * 0.3f, animationTime)
                    .SetEase(Ease.OutQuart));
        }

        public void FadeOut(float animationTime = 0.0f)
        {
            DOTween.Sequence()
                .Append(buttonImage
                    .DOFade(1.0f, animationTime)
                    .SetEase(Ease.Linear))
                .Join(buttonImage.rectTransform
                    .DOScale(_buttonScale, animationTime)
                    .SetEase(Ease.OutBack));
        }
    }
}
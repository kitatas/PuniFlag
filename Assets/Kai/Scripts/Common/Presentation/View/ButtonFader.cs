using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    public sealed class ButtonFader : MonoBehaviour
    {
        private Vector3 _buttonScale;
        private Vector3 _iconScale;
        [SerializeField] private Image buttonImage = default;
        [SerializeField] private Image buttonIcon = default;

        public void Init()
        {
            _buttonScale = buttonImage.transform.localScale;
            _iconScale = buttonIcon.transform.localScale;
        }

        public void FadeIn(float animationTime = 0.0f)
        {
            DOTween.Sequence()
                .Append(buttonImage
                    .DOFade(0.0f, animationTime)
                    .SetEase(Ease.Linear))
                .Join(buttonImage.rectTransform
                    .DOScale(_buttonScale * 0.3f, animationTime)
                    .SetEase(Ease.OutQuart))
                .Join(buttonIcon
                    .DOFade(0.0f, animationTime)
                    .SetEase(Ease.Linear))
                .Join(buttonIcon.rectTransform
                    .DOScale(_iconScale * 0.3f, animationTime)
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
                    .SetEase(Ease.OutBack))
                .Join(buttonIcon
                    .DOFade(1.0f, animationTime)
                    .SetEase(Ease.Linear))
                .Join(buttonIcon.rectTransform
                    .DOScale(_iconScale, animationTime)
                    .SetEase(Ease.OutBack));
        }
    }
}
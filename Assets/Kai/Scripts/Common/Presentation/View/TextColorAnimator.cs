using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class TextColorAnimator : MonoBehaviour
    {
        [SerializeField] private bool isPlay = false;

        private void Start()
        {
            if (isPlay)
            {
                Play();
            }
        }

        public void Play()
        {
            var highlightColor = new Color(1.0f, 1.0f, 0.8f);

            var targetText = GetComponent<TextMeshProUGUI>();
            var textAnimation = new DOTweenTMPAnimator(targetText);
            for (int i = 0; i < textAnimation.textInfo.characterCount; i++)
            {
                var interval = i * 0.05f;
                DOTween.Sequence()
                    .AppendInterval(1.0f)
                    .Append(textAnimation
                        .DOColorChar(i, highlightColor, 0.1f)
                        .SetLoops(2, LoopType.Yoyo)
                        .SetDelay(interval))
                    .AppendInterval(2.0f - interval)
                    .SetLoops(-1)
                    .SetLink(gameObject);
            }
        }
    }
}
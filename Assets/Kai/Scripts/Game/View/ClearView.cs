using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public sealed class ClearView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clearText = default;

        private readonly float _animationTime = 0.4f;

        public async UniTask ShowAsync(CancellationToken token)
        {
            clearText.text = "clear";
            var offset = new Vector3(30.0f, 0.0f, 0.0f);
            var textAnimation = new DOTweenTMPAnimator(clearText);
            var charCount = textAnimation.textInfo.characterCount;
            for (int i = 0; i < charCount; i++)
            {
                DOTween.Sequence()
                    .Append(textAnimation
                        .DOOffsetChar(i, textAnimation.GetCharOffset(i) + offset, 0.0f))
                    .Append(textAnimation
                        .DOOffsetChar(i, textAnimation.GetCharOffset(i), _animationTime))
                    .Join(textAnimation
                        .DOFadeChar(i, 1.0f, _animationTime))
                    .SetDelay(0.05f * i);
            }

            await UniTask.Delay(TimeSpan.FromSeconds(_animationTime * 2.0f), cancellationToken: token);
        }
    }
}
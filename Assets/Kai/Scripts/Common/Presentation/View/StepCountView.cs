using DG.Tweening;
using Kai.Common.Application;
using TMPro;
using UnityEngine;

namespace Kai.Common.Presentation.View
{
    public sealed class StepCountView : MonoBehaviour
    {
        [SerializeField] private RectTransform background = default;
        [SerializeField] private TextMeshProUGUI stepCountText = default;

        public void TweenTop()
        {
            DOTween.Sequence()
                .Append(background
                    .DOAnchorPosY(0.0f, CommonViewConfig.FADE_TIME))
                .Join(stepCountText.rectTransform
                    .DOAnchorPosY(-100.0f, CommonViewConfig.FADE_TIME));
        }

        public void TweenCenter()
        {
            DOTween.Sequence()
                .Append(background
                    .DOAnchorPosY(-90.0f, CommonViewConfig.FADE_TIME))
                .Join(stepCountText.rectTransform
                    .DOAnchorPosY(0.0f, CommonViewConfig.FADE_TIME));
        }

        public void Hide(float animationTime = 0.0f)
        {
            background
                .DOAnchorPosY(20.0f, animationTime);
        }

        public void Display(int stepCount)
        {
            stepCountText.text = $"{stepCount}";
        }
    }
}
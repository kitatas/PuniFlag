using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.StepCount
{
    public sealed class StepCountView : MonoBehaviour
    {
        [SerializeField] private RectTransform background = default;
        [SerializeField] private TextMeshProUGUI stepCountText = default;
        [SerializeField] private TextMeshProUGUI scoreText = default;

        public void TweenBottom()
        {
            stepCountText.rectTransform
                .DOAnchorPosY(-100.0f, Const.FADE_TIME);
        }

        public void TweenCenter()
        {
            stepCountText.rectTransform
                .DOAnchorPosY(0.0f, Const.FADE_TIME);
        }

        public void Display(int stepCount)
        {
            stepCountText.text = $"{stepCount}";
        }

        public async UniTask ShowResultAsync(CancellationToken token)
        {
            await DOTween.Sequence()
                .Append(scoreText
                    .DOFade(1.0f, Const.UI_ANIMATION_TIME))
                .Append(background
                    .DOAnchorPosX(-100.0f, Const.UI_ANIMATION_TIME))
                .WithCancellation(token);
        }
    }
}
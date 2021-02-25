using Common;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.StepCount
{
    public sealed class StepCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stepCountText = default;

        public void TweenBottom()
        {
            stepCountText.rectTransform
                .DOAnchorPosY(-5.0f, Const.FADE_TIME);
        }

        public void TweenCenter()
        {
            stepCountText.rectTransform
                .DOAnchorPosY(2.0f, Const.FADE_TIME);
        }

        public void Display(int stepCount)
        {
            stepCountText.text = $"{stepCount}";
        }
    }
}
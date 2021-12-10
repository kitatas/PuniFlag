using System;
using Kai.Common.Presentation.View;
using TMPro;
using UniRx;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class StageButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText = default;

        public void Init(int level, Sprite sprite, Action action)
        {
            levelText.text = $"{level.ToString()}";

            var buttonAnimator = GetComponent<ButtonAnimator>();
            buttonAnimator.button.image.sprite = sprite;
            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    buttonAnimator.Play();
                    action?.Invoke();
                })
                .AddTo(this);
        }
    }
}
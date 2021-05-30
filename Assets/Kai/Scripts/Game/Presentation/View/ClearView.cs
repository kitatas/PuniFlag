using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public sealed class ClearView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clearText = default;

        private readonly float _animationTime = 0.3f;

        public void Init()
        {
            clearText.text = $"";
        }

        public async UniTask ShowAsync(CancellationToken token)
        {
            await clearText
                .DOText($"clear", _animationTime)
                .SetEase(Ease.Linear)
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(_animationTime), cancellationToken: token);
        }
    }
}
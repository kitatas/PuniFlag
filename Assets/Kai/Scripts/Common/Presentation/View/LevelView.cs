using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using TMPro;
using UnityEngine;
using Zenject;

namespace Kai.Common.Presentation.View
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stageText = default;
        [SerializeField] private TextMeshProUGUI stageLevelText = default;
        [SerializeField] private TextMeshProUGUI stageMaxLevelText = default;
        [SerializeField] private TextMeshProUGUI slash = default;

        private bool _isPlayLevelUpSe;
        private CancellationToken _token;
        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _seController = seController;
        }

        public void SetMaxStageCount(int value)
        {
            stageMaxLevelText.text = $"{value:00}";
        }

        public void SetPlayLevelUpSe(bool value)
        {
            _isPlayLevelUpSe = value;
        }

        public void DisplayLevel(int level)
        {
            UpdateLevelAsync(level, _token).Forget();
        }

        private async UniTaskVoid UpdateLevelAsync(int level, CancellationToken token)
        {
            if (level != 0 && _isPlayLevelUpSe)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.FADE_TIME), cancellationToken: token);

                await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.LOAD_INTERVAL * 0.5f), cancellationToken: token);

                _seController.PlaySe(SeType.LevelUp);
            }

            stageLevelText.text = $"{level + 1:00}";
        }

        public void ShowClear()
        {
            stageText.enabled = true;
            ActivateLevelText(false);
            stageText.text = $"";
            DOTween.Sequence()
                .AppendInterval(CommonViewConfig.FADE_TIME)
                .Append(stageText
                    .DOText($"game clear", CommonViewConfig.LOAD_INTERVAL * 0.5f)
                    .SetEase(Ease.Linear));

            _seController.DelayPlaySeAsync(SeType.GameClear, CommonViewConfig.FADE_TIME, _token).Forget();
        }

        public void Show()
        {
            stageText.text = $"stage";
            Activate(true);
        }

        public void Hide()
        {
            Activate(false);
        }

        private void Activate(bool value)
        {
            stageText.enabled = value;
            ActivateLevelText(value);
        }

        private void ActivateLevelText(bool value)
        {
            stageLevelText.enabled = value;
            stageMaxLevelText.enabled = value;
            slash.enabled = value;
        }
    }
}
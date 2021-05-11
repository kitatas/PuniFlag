using System;
using System.Threading;
using Common;
using Common.Application;
using Common.Presentation.Controller;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Stage.Level
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stageText = default;
        [SerializeField] private TextMeshProUGUI stageLevelText = default;

        private CancellationToken _token;
        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _seController = seController;
        }

        public void DisplayLevel(int level)
        {
            UpdateLevelAsync(level, _token).Forget();
        }

        private async UniTaskVoid UpdateLevelAsync(int level, CancellationToken token)
        {
            if (level != 0 && level < Const.STAGE_COUNT)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(Const.FADE_TIME), cancellationToken: token);

                await UniTask.Delay(TimeSpan.FromSeconds(Const.INTERVAL * 0.5f), cancellationToken: token);

                _seController.PlaySe(SeType.LevelUp);
            }

            stageLevelText.text = $"{level + 1:00} / {Const.STAGE_COUNT:00}";
        }

        public void ShowClear()
        {
            stageText.enabled = true;
            stageLevelText.enabled = false;
            stageText.text = $"";
            DOTween.Sequence()
                .AppendInterval(Const.FADE_TIME)
                .Append(stageText
                    .DOText($"game clear", Const.INTERVAL * 0.5f)
                    .SetEase(Ease.Linear));

            _seController.DelayPlaySeAsync(SeType.GameClear, Const.FADE_TIME, _token).Forget();
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
            stageLevelText.enabled = value;
        }
    }
}
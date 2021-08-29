using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Common.Presentation.View;
using TMPro;
using UniRx;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class StageButtonView : MonoBehaviour
    {
        [SerializeField] private int level = default;
        [SerializeField] private TextMeshProUGUI levelText = default;
        [SerializeField] private Sprite lockIcon = default;
        [SerializeField] private Sprite clearIcon = default;

        public void Init(SceneLoader sceneLoader, bool isClear)
        {
            levelText.text = $"{level}";

            var buttonAnimator = GetComponent<ButtonAnimator>();
            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    buttonAnimator.Play();
                    sceneLoader.LoadScene(GameType.FreePlay, SceneName.Main, LoadType.Direct, stageIndex);
                })
                .AddTo(this);

            buttonAnimator.button.image.sprite = isClear ? clearIcon : lockIcon;
        }

        public int stageIndex => level - 1;
    }
}
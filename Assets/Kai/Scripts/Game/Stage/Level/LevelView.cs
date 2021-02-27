using Common;
using TMPro;
using UnityEngine;

namespace Game.Stage.Level
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stageText = default;
        [SerializeField] private TextMeshProUGUI stageLevelText = default;

        public void DisplayLevel(int level)
        {
            stageLevelText.text = $"{level + 1:00} / {Const.STAGE_COUNT:00}";
        }

        public void ShowClear()
        {
            stageText.enabled = true;
            stageLevelText.enabled = false;
            stageText.text = $"game clear";
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
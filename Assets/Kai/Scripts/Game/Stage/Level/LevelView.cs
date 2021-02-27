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

        public void Hide()
        {
            stageText.enabled = false;
            stageLevelText.enabled = false;
        }
    }
}